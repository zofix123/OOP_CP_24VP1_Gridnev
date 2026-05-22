using QuestPDF.Infrastructure;
using System;
using System.IO;
using System.Windows.Forms;
using ООП_КР_24ВП1_Гриднев.UI;

namespace ООП_КР_24ВП1_Гриднев
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MessageBox.Show(
                "Курсовая работа по ООП.\nГриднев Э. 24ВП1\nБаза данных «Книги»",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            QuestPDF.Settings.License = LicenseType.Community;
            Application.Run(new MainForm());
        }
    }
}

