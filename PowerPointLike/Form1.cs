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
        private ModelAlias.Model _model;

        public PowerPointLike(ModelAlias.Model model)
        {
            InitializeComponent();
            _model = model;
        }
    }
}
