using Exam_TOP_Academy.ViewModels;
using System.Windows;

namespace Exam_TOP_Academy.View;
public partial class AuthorizationWindow : Window
{
    public AuthorizationWindow()
    {
        InitializeComponent();
        DataContext = new AuthorizationViewModel();
    }
}