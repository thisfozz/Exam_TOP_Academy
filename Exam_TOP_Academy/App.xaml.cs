using Exam_TOP_Academy.View;
using System.Windows;

namespace Exam_TOP_Academy
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new AuthorizationWindow();
            mainWindow.Show();
        }
    }
}
