using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelAlias = PowerPointLike.Model;
using PresentationModelAlias = PowerPointLike.PresentationModel;

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
            PresentationModelAlias.PresentationModel presentationModel = new PresentationModelAlias.PresentationModel(model);

            Application.Run(new PowerPointLike(presentationModel));
        }

    }
}
