using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationModelAlias = PowerPointLike.PresentationModel;

namespace PowerPointLike
{
    public partial class PowerPointLike : Form
    {
        public const string EMPTY_STRING = "";
        public const int DATA_DELETE_INDEX = 0;
        public const int DATA_NAME_INDEX = 1;
        public const int DATA_COORDINATE_INDEX = 2;
        private PresentationModelAlias.PresentationModel _presentationModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form"/> class.
        /// </summary>
        /// <param name="model"></param>
        public PowerPointLike(PresentationModelAlias.PresentationModel presentationModel)
        {
            InitializeComponent();
            _presentationModel = presentationModel;
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
                string[] element = _presentationModel.GetCurrentElement();
                _elementDataGrid.Rows.Add(element[DATA_DELETE_INDEX], element[DATA_NAME_INDEX], element[DATA_COORDINATE_INDEX]);

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

        private void ClickLineButton(object sender, EventArgs e)
        {
            _lineButton.Checked = true;
            _canvas.Cursor = System.Windows.Forms.Cursors.Cross;
        }

        private void ClickRectangleButton(object sender, EventArgs e)
        {

        }

        private void ClickCircleButton(object sender, EventArgs e)
        {

        }
    }
}
