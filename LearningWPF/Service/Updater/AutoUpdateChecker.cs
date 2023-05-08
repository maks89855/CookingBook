using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Input;
using LearningWPF;

namespace CookingBook.Service.Updater
{
    public class AutoUpdateChecker
    {
        public AutoUpdateChecker()
        {
            
        }
        private WebClient client = new WebClient();

        


        public void Update()
        {
            try
            {
                var s = client.DownloadString("");
                var versionNew = new Version(s);
                var versionOld = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
                if (versionOld < versionNew)
                {

                    var filePath = @"C:\Users\maks8\Downloads\Download\Новая папка";
                    client.DownloadFile("", filePath);
                    Process.Start(filePath);
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Обновление не требуется");
            }
        }
    }
}
