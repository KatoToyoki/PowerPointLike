using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public const string EMPTY_STRING = "";
        public const int START_DATA_GRID_VIEW_INDEX = 2;
        private PresentationModel _presentationModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form"/> class.
        /// </summary>
        /// <param name="model"></param>
        public PowerPointLike(PresentationModel presentationModel)
        {
            InitializeComponent();
            _presentationModel = presentationModel;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);

            this.KeyPreview = true;
            this.KeyDown += ClickKey;

            _presentationModel.GetModelEvent()._modelChanged += HandleModelChanged;
        }

        /// <summary>
        /// Method <c>AddElement</c>
        /// when the button is clicked, add new item in the container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewElement(object sender, EventArgs e)
        {
            _presentationModel.AddItem(_elementsChoicesBox.Text);
            UpdateDataToTable();
        }

        /// <summary>
        /// Method <c>DeleteElement</c>
        /// if the button is clicked, delete the element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteElement(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.DeleteCertainElement(e.ColumnIndex, e.RowIndex);
            _presentationModel.ResetSelectIndex();
            UpdateDataToTable();
        }

        /// <summary>
        /// Method <c>ClickLineButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickLineButton(_lineButton.MergeIndex);
            RefreshToolButtonClick();
            _canvas.Cursor = System.Windows.Forms.Cursors.Cross;
        }

        /// <summary>
        /// Method <c>ClickRectangleButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickRectangleButton(_rectangleButton.MergeIndex);
            RefreshToolButtonClick();
            _canvas.Cursor = System.Windows.Forms.Cursors.Cross;
        }

        /// <summary>
        /// Method <c>ClickCircleButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickCircleButton(_circleButton.MergeIndex);
            RefreshToolButtonClick();
            _canvas.Cursor = System.Windows.Forms.Cursors.Cross;
        }

        /// <summary>
        /// Method <c>ClickMouseButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickMouseButton(object sender, EventArgs e)
        {
            _presentationModel.ClickMouseButton(_mouseButton.MergeIndex);
            RefreshToolButtonClick();
            _canvas.Cursor = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>
        /// Method <c>RefreshToolButtonClick</c>
        /// updates three toolbar buttons to be consisted with presentation model
        /// </summary>
        public void RefreshToolButtonClick()
        {
            _lineButton.Checked = _presentationModel.GetButtonChecked((int)PresentationModel.ShapeIndex.Line);
            _rectangleButton.Checked = _presentationModel.GetButtonChecked((int)PresentationModel.ShapeIndex.Rectangle);
            _circleButton.Checked = _presentationModel.GetButtonChecked((int)PresentationModel.ShapeIndex.Circle);
            _mouseButton.Checked = _presentationModel.GetButtonChecked((int)PresentationModel.ShapeIndex.Mouse);
        }

        /// <summary>
        /// Method <c>HandleCanvasPressed</c>
        /// this function is to deal with the situation of the starting of the drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _canvas.Invalidate();
            _presentationModel.PressPointer(e.X, e.Y);
        }

        /// <summary>
        /// Method <c>HandleCanvasMoved</c>
        /// this function is to deal with the situation of the the process of the drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.MovePointer(e.X, e.Y);
        }

        /// <summary>
        /// Method <c>HandleCanvasReleased</c>
        /// this function is to deal with the situation of the end of the drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.ReleasePointer(e.X, e.Y);

            UpdateDataToTable();

            _presentationModel.ResetAllButtonCheck();
            RefreshToolButtonClick();
            ClickMouseButton(sender, e);
            _presentationModel.SetStateSelect();
        }

        /// <summary>
        /// Method <c>HandleCanvasPaint</c>
        /// to display all the instances on the screen
        /// </summary>
        /// <param name="sender"></param>
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
            _canvas1.Image = GetScaleImage();
        }

        /// <summary>
        /// Method <c>AddElementToDataRridView</c>
        /// add data whenever it's generated or painted
        /// </summary>
        public void UpdateDataToTable()
        {
            DeleteAllDataGridViewData();

            List<string[]> tableData = _presentationModel.GetAllContainerData();

            foreach (var element in tableData)
            {
                _elementDataGrid.Rows.Add(element);
            }
        }

        /// <summary>
        /// Method <c>DeleteAllDataGridViewData</c>
        /// </summary>
        public void DeleteAllDataGridViewData()
        {
            for (int i = _elementDataGrid.RowCount - START_DATA_GRID_VIEW_INDEX; i >= 0; i--)
            {
                _elementDataGrid.Rows.RemoveAt(i);
            }
        }

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
        private Bitmap CaptureRegion(Control control, System.Drawing.Rectangle region)
        {
            Bitmap capturedImage = new Bitmap(region.Width, region.Height);
            using (Graphics g = Graphics.FromImage(capturedImage))
            {
                g.CopyFromScreen(
                    control.PointToScreen(new System.Drawing.Point(region.Left, region.Top)),
                    Point.Empty,
                    region.Size,
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
        private Bitmap ResizeImage(Bitmap originalImage, Size newSize)
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
        /// Method <c>HandleModelChanged</c>
        /// refresh when model is changed
        /// </summary>
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        /// <summary>
        /// Method <c>ChangeCanvas</c> 
        /// to deal with the situation of canvas's change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeCanvas(object sender, PaintEventArgs e)
        {
            CoordinateSet selectedOne = _presentationModel.GetSelectedOneCoordinate();
            selectedOne.DrawSelectFrame(e);
        }

        /// <summary>
        /// Method <c>ClickKey</c> 
        /// to deal with keyin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickKey(object sender, KeyEventArgs e)
        {
            _presentationModel.ClickKey(e);
            UpdateDataToTable();
            _canvas.Invalidate();
        }
    }
}
