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
using PowerPointLike.Models;

namespace PowerPointLike
{
    public partial class PowerPointLike : Form
    {
        public const int START_DATA_GRID_VIEW_INDEX = 2;
        public const int HEIGHT_SIZE = 9;
        public const int WIDTH_SIZE = 16;
        public const float BASE_FOR_WINDOWS = 96f;
        public const double X_Y_FACTOR = 1.2;
        public const double WIDTH_FACTOR = 1.35;
        public const double HEIGHT_FACTOR = 1.45;
        public const string SHAPE_NAME = "_shapeName";

        public PresentationModel _presentationModel
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form"/> class.
        /// </summary>
        /// <param name="model"></param>
        public PowerPointLike(PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            _presentationModel._model.SetAllCanvasSize(_canvas.Width, _canvas.Height);
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;

            this.KeyPreview = true;
            this.KeyDown += ClickKey;

            _canvas1.Height = AdjustHeight(_canvas1.Width);
            _canvas.Height = AdjustHeight(_canvas.Width);
            _presentationModel.GetModelEvent()._modelChanged += HandleModelChanged;

            RefreshRedoUndoUI();
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
        /// Method <c>ClickKey</c> 
        /// to deal with keyin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickKey(object sender, KeyEventArgs e)
        {
            _presentationModel.ClickKey(e);
            UpdateDataToTable();
            _canvas.Invalidate();
        }

        // data =====================================================================
        /// <summary>
        /// Method <c>AddElement</c>
        /// when the button is clicked, add new item in the container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddNewElement(object sender, EventArgs e)
        {
            _presentationModel.AddItem(_elementsChoicesBox.Text, (int)DataModel.DATA_DELETE_INDEX, _elementDataGrid.RowCount);
            UpdateDataToTable();
            RefreshRedoUndoUI();
        }

        /// <summary>
        /// Method <c>DeleteElement</c>
        /// if the button is clicked, delete the element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteElement(object sender, DataGridViewCellEventArgs e)
        {
            string shapeName = _elementDataGrid.Rows[e.RowIndex].Cells[SHAPE_NAME].Value.ToString();
            _presentationModel.DeleteCertainElement(shapeName, e.ColumnIndex, e.RowIndex);
            _presentationModel.ResetSelectIndex();
            UpdateDataToTable();
            RefreshRedoUndoUI();
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

        // button ===================================================================
        /// <summary>
        /// Method <c>ClickLineButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickLineButton(_lineButton.MergeIndex);
            RefreshToolButtonClick();
            _presentationModel.DetectButtonDraw();
            _canvas.Cursor = _presentationModel._cursor;
        }

        /// <summary>
        /// Method <c>ClickRectangleButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickRectangleButton(_rectangleButton.MergeIndex);
            RefreshToolButtonClick();
            _presentationModel.DetectButtonDraw();
            _canvas.Cursor = _presentationModel._cursor;
        }

        /// <summary>
        /// Method <c>ClickCircleButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickCircleButton(_circleButton.MergeIndex);
            RefreshToolButtonClick();
            _presentationModel.DetectButtonDraw();
            _canvas.Cursor = _presentationModel._cursor;
        }

        /// <summary>
        /// Method <c>ClickMouseButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickMouseButton(object sender, EventArgs e)
        {
            _presentationModel.ClickMouseButton(_mouseButton.MergeIndex);
            RefreshToolButtonClick();
            _presentationModel.DetectButtonDraw();
            _canvas.Cursor = _presentationModel._cursor;
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
            RefreshRedoUndoUI();
        }

        // state ====================================================================
        /// <summary>
        /// Method <c>HandleCanvasPressed</c>
        /// this function is to deal with the situation of the starting of the drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _canvas.Invalidate();

            _presentationModel.DetectScale(e.X, e.Y);
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
            _presentationModel.DetectScale(e.X, e.Y);
            _canvas.Cursor = _presentationModel._cursor;
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
            _presentationModel.ResetStateSelect();
            RefreshRedoUndoUI();
        }

        /// <summary>
        /// Method <c>HandleCanvasPaint</c>
        /// to display all the instances on the screen
        /// </summary>
        /// <param name="sender"></param>
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            IGraphics graphicsAdaptor = new GraphicsAdaptor(e.Graphics);
            _presentationModel.Draw(graphicsAdaptor);
            _presentationModel._model._state.DrawTempShape(graphicsAdaptor);
            _canvas1.Image = GetScaleImage();
        }

        /// <summary>
        /// Method <c>ChangeCanvas</c> 
        /// to deal with the situation of canvas's change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChangeCanvas(object sender, PaintEventArgs e)
        {
            _presentationModel.DrawSelectFrame(e);
        }
    }
}
