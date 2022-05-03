using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LearningWPF.Service
{
    public class WindowDialogService : IDialogService
    {
        public string OpenFile(string filter)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return null;
        }
        
        public string SaveFile()
        {
            var dialog = new SaveFileDialog();
            DateTime dateTime = DateTime.Now;

            dialog.FileName = $"Cooking_Book_Backup_{dateTime: dd/MM/yy_HH:mm:ss}";
            dialog.DefaultExt = "json";
            dialog.OverwritePrompt= true;
            if(dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return null;
        }
        public void ShowMessageBox(string message)
        {
            throw new NotImplementedException();
        }
    }
}
