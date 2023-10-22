using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointLike
{
    public partial class PowerPointLike : Form
    {
        enum Data
        {
            DataDeleteIndex,
            DataNameIndex,
            DataCoordinateIndex
        }

        public const string EMPTY_STRING = "";
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
            if (_elementsChoicesBox.Text != EMPTY_STRING)
            {
                _presentationModel.AddItem(_elementsChoicesBox.Text);
                AddDataToTable();
            }
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
            _elementDataGrid.Rows.RemoveAt(_presentationModel.GetDeleteIndex(e.ColumnIndex, e.RowIndex));
        }

        /// <summary>
        /// Method <c>ClickLineButton</c>
        /// change the status of all buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickLineButton();
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
            _presentationModel.ClickRectangleButton();
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
            _presentationModel.ClickCircleButton();
            RefreshToolButtonClick();
            _canvas.Cursor = System.Windows.Forms.Cursors.Cross;
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
        }

        /// <summary>
        /// Method <c>HandleCanvasPressed</c>
        /// this function is to deal with the situation of the starting of the drawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
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
            AddDataToTable();
            _presentationModel.ResetAllButtonCheck();
            RefreshToolButtonClick();
            _canvas.Cursor = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>
        /// Method <c>HandleCanvasPaint</c>
        /// to display all the instances on the screen
        /// </summary>
        /// <param name="sender"></param>
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        /// <summary>
        /// Method <c>AddElementToDataRridView</c>
        /// add data whenever it's generated or painted
        /// </summary>
        public void AddDataToTable()
        {
            string[] element = _presentationModel.GetCurrentElement();
            _elementDataGrid.Rows.Add(element[(int)Data.DataDeleteIndex], element[(int)Data.DataNameIndex], element[(int)Data.DataCoordinateIndex]);
        }

        /// <summary>
        /// Method <c>HandleModelChanged</c>
        /// refresh when model is changed
        /// </summary>
        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}
