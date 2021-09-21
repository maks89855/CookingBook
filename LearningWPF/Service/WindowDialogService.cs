using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningWPF.Service
{
    public class WindowDialogService : IDialogService
    {
        public string FilePath { get ; set; }

        public string OpenFile(string filter)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return null;
        }
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}
