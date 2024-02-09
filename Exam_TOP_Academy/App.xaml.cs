using Exam_TOP_Academy.View;
using System.Globalization;
using System.Windows;

namespace Exam_TOP_Academy
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            string langCode = "ru-RU";
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(langCode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);

            base.OnStartup(e);
            var mainWindow = new AuthorizationWindow();
            mainWindow.Show();
        }
    }
}
