using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Model model = new Model();
            PresentationModel presentationModel = new PresentationModel(model);

            Application.Run(new PowerPointLike(presentationModel));
        }

    }
}
