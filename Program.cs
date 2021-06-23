using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RainWorldStateEdit
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        public static Main Form;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form = new Main();

            if (args.Length == 1) 
            {
                RainWorldStateEdit.Main.AutoloadFile = args[0];
            }
            Application.Run(Form);
        }

    }
}
