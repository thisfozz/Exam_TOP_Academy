using Exam_TOP_Academy.Settings;
using Exam_TOP_Academy.View;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Windows;

namespace Exam_TOP_Academy;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        string filePath = @"appsettings.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            var mainSettings = JsonConvert.DeserializeObject<MainSettings>(jsonData);

            var langCode = mainSettings?.languageSettings.LangCode;

            if (langCode != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(langCode);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);
            }
            else
            {
                CultureInfo before = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = before;
                Thread.CurrentThread.CurrentUICulture = before;
            }


            base.OnStartup(e);
            var mainWindow = new AuthorizationWindow();
            mainWindow.Show();
        }
    }
}
