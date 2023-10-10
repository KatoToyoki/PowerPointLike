using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelAlias = PowerPointLike.Model;

namespace PowerPointLike
{
    public partial class PowerPointLike : Form
    {
        public const string EMPTY_STRING = "";
        public const int DATA_DELETE_INDEX = 0;
        public const int DATA_NAME_INDEX = 1;
        public const int DATA_COORDINATE_INDEX = 2;
        private ModelAlias.Model _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form"/> class.
        /// </summary>
        /// <param name="model"></param>
        public PowerPointLike(ModelAlias.Model model)
        {
            InitializeComponent();
            _model = model;
        }

        /// <summary>
        /// Method <c>AddElement</c>
        /// when the button is clicked, add new item in the container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewElement(object sender, EventArgs e)
        {
            _model.AddItem(_elementsChoicesBox.Text);
            string[] element = _model.GetCurrentElement();
            _elementDataGrid.Rows.Add(element[DATA_DELETE_INDEX], element[DATA_NAME_INDEX], element[DATA_COORDINATE_INDEX]);
        }

        /// <summary>
        /// Method <c>DeleteElement</c>
        /// if the button is clicked, delete the element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteElement(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DATA_DELETE_INDEX)
            {
                _model.DeleteCertainElement(e.RowIndex);
                _elementDataGrid.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
