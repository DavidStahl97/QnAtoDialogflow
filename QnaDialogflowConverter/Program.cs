using LTRSimulation.Common.Services;
using QnaDialogflowConverter.Dialogflow;
using QnaDialogflowConverter.QnA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QnaDialogflowConverter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var openFile = new OpenFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "QnA File"
            };

            var result = openFile.ShowDialog();
            if (result != DialogResult.OK)
            {
                Console.WriteLine("Choose QnA file");
                return;
            }

            var intents = QnaReader.ReadFile(openFile.FileName);


            using (var fbd = new FolderBrowserDialog())
            {
                var r = fbd.ShowDialog();

                if (r == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    DialogflowWriter.Write(intents, fbd.SelectedPath);
                }
                else
                {
                    Console.WriteLine("Choose Folder");
                    return;
                }
            }
        }
    }
}
