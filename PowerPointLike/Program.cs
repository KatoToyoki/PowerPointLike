using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelAlias = PowerPointLike.Model;

namespace PowerPointLike
{
    static class Program
    {
        /// <summary>
        /// the enter point of the program
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ModelAlias.Model model = new ModelAlias.Model();

            Application.Run(new PowerPointLike(model));
        }

    }
}
