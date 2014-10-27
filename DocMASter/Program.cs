using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocMASter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                #if (DEBUG)
                args = new string[] { "APInvoice", "1" };
                #else
                System.Windows.Forms.MessageBox.Show("Usage: DocMASter.exe objectType objectId", "Error");
                return 1;
                #endif
                }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DocsForObjectForm(args[0], args[1]));

            return 0;
        }
    }
}
