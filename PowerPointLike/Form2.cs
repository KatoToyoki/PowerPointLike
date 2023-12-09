using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointLike
{
    public partial class PowerPointLike : Form
    {
        // thumbnail ================================================================
        /// <summary>
        /// Method <c>GetscaleImage</c>
        /// to get change the button's image to the panel's thumbnail
        /// why Dr.Smell doesn't recognize the word "thunbmail" ???
        /// </summary>
        /// <returns></returns>
        public Bitmap GetScaleImage()
        {
            System.Drawing.Rectangle captureRegion = new System.Drawing.Rectangle(_canvas.Location.X, _canvas.Location.Y, _canvas.Width, _canvas.Height);
            Bitmap scaleImage = new Bitmap(_canvas1.Width, _canvas1.Height);
            using (Graphics g = Graphics.FromImage(scaleImage))
            {
                Bitmap capturedImage = CaptureRegion(_canvas, captureRegion);
                capturedImage = ResizeImage(capturedImage, _canvas1.Size);
                g.DrawImage(capturedImage, Point.Empty);
            }

            return scaleImage;
        }

        /// <summary>
        /// Method <c>CaptureRegion</c>
        /// get the origin capture region of panel
        /// </summary>
        /// <param name="control">the panel</param>
        /// <param name="region">the rectangle that represent panel</param>
        /// <returns></returns>
        public Bitmap CaptureRegion(Control control, System.Drawing.Rectangle region)
        {
            float xFactor = control.DeviceDpi / BASE_FOR_WINDOWS;
            float yFactor = control.DeviceDpi / BASE_FOR_WINDOWS;

            System.Drawing.Rectangle adjustedRegion = new System.Drawing.Rectangle(
                (int)(region.X * xFactor * X_Y_FACTOR),
                (int)(region.Y * yFactor * X_Y_FACTOR),
                (int)(region.Width * xFactor * WIDTH_FACTOR),
                (int)(region.Height * yFactor * HEIGHT_FACTOR)
            );

            return CaptureImage(control, adjustedRegion);
        }

        /// <summary>
        /// Method <c>CaptureImage</c>
        /// generate the image of thumbnail
        /// </summary>
        /// <param name="control"></param>
        /// <param name="adjustedRegion"></param>
        /// <returns></returns>
        public Bitmap CaptureImage(Control control, System.Drawing.Rectangle adjustedRegion)
        {
            Bitmap capturedImage = new Bitmap(adjustedRegion.Width, adjustedRegion.Height);
            using (Graphics g = Graphics.FromImage(capturedImage))
            {
                g.ResetTransform();

                g.CopyFromScreen(
                    control.PointToScreen(new System.Drawing.Point(adjustedRegion.Left, adjustedRegion.Top)),
                    Point.Empty,
                    adjustedRegion.Size,
                    CopyPixelOperation.SourceCopy);
            }
            return capturedImage;
        }

        /// <summary>
        /// Method <c>ResizeImage</c>
        /// to fit the width and height of panel and button, the captured img need to scale to the proper size
        /// </summary>
        /// <param name="originalImage">the origin capture img</param>
        /// <param name="newSize">the size of button</param>
        /// <returns></returns>
        public Bitmap ResizeImage(Bitmap originalImage, Size newSize)
        {
            float percentWidth = ((float)newSize.Width / (float)originalImage.Width);
            float percentHeight = ((float)newSize.Height / (float)originalImage.Height);
            float percent = Math.Min(percentWidth, percentHeight);
            int finalWidth = (int)(originalImage.Width * percent);
            int finalHeight = (int)(originalImage.Height * percent);

            Bitmap resizedImage = new Bitmap(finalWidth, finalHeight);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, finalWidth, finalHeight);
            }

            return resizedImage;
        }

        /// <summary>
        /// Method <c>MoveSplitDrawingViewContainer</c>
        /// to deal with when splitter is moved, Dr.Smell doesn't regonize the word "splitter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveSplitDrawingViewContainer(object sender, SplitterEventArgs e)
        {
            _canvas1.Height = AdjustHeight(_canvas1.Width);
            _canvas.Height = AdjustHeight(_canvas.Width);
            _canvas1.Image = GetScaleImage();
            _presentationModel.ChangeCanvasSize(_canvas.Width, _canvas.Height);
            UpdateDataToTable();
        }

        /// <summary>
        /// Method <c>MoveSplitDrawingDataContainer</c>
        /// to deal with when splitter is moved, Dr.Smell doesn't regonize the word "splitter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveSplitDrawingDataContainer(object sender, SplitterEventArgs e)
        {
            _canvas1.Height = AdjustHeight(_canvas1.Width);
            _canvas.Height = AdjustHeight(_canvas.Width);
            _canvasElementsData.Height = AdjustHeight(_canvasElementsData.Width);
            _presentationModel.ChangeCanvasSize(_canvas.Width, _canvas.Height);
            UpdateDataToTable();
        }

        /// <summary>
        /// Method <c>AdjustHeight</c>
        ///  adjust the size
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public int AdjustHeight(int width)
        {
            return width * HEIGHT_SIZE / WIDTH_SIZE;
        }

        /// <summary>
        /// Method <c>ClickUndo</c>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickUndo(object sender, EventArgs e)
        {
            _presentationModel._model.Undo();
            _presentationModel.ResetSelectIndex();
            UpdateDataToTable();
            _canvas.Invalidate();
            RefreshRedoUndoUI();
        }

        /// <summary>
        /// Method <c>ClickRedo</c>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickRedo(object sender, EventArgs e)
        {
            _presentationModel._model.Redo();
            _presentationModel.ResetSelectIndex();
            UpdateDataToTable();
            _canvas.Invalidate();
            RefreshRedoUndoUI();
        }

        private void RefreshRedoUndoUI()
        {
            _redoButton.Enabled = _presentationModel._model._commandManager.IsRedoEnabled;
            _undoButton.Enabled = _presentationModel._model._commandManager.IsUndoEnabled;
            Invalidate();
        }

    }
}
