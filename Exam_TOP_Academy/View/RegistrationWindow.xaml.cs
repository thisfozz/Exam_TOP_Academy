using Exam_TOP_Academy.ViewModels;
using System.Windows;

namespace Exam_TOP_Academy.View;

public partial class RegistrationWindow : Window
{
    public RegistrationWindow()
    {
        InitializeComponent();
        DataContext = new RegistrationViewModel();
    }
}
