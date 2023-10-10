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
            string chosenText = _elementsChoicesBox.Text;

            if (chosenText == EMPTY_STRING)
            {
                return;
            }

            Console.WriteLine(chosenText);

            _model.AddItem(chosenText);

            _model.PrintTest();
        }
    }
}
