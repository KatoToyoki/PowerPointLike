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
        private ModelAlias.Model _model;

        public PowerPointLike(ModelAlias.Model model)
        {
            InitializeComponent();
            _model = model;
        }

        private void AddNewElement(object sender, EventArgs e)
        {
            _model.AddItem(_elementsChoicesBox.Text);
            string[] element = _model.GetOneElement(_model.GetContainerLength() - 1);
            _elementDataGrid.Rows.Add(element[0], element[1], element[2]);
        }
    }
}
