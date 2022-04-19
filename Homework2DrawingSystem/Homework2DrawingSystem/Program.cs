using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2DrawingSystem
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Model.Model model = new Model.Model();
            FormPresentationModel formPresentationModel = new FormPresentationModel(model);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DrawingForm(formPresentationModel, model));
        }
    }
}
