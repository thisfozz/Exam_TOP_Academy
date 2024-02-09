using Exam_TOP_Academy.ViewModels;
using System.Windows;

namespace Exam_TOP_Academy.View;
public partial class LanguageSelectionDialog : Window
{
    public LanguageSelectionDialog()
    {
        InitializeComponent();
        DataContext = new LanguageSelectionViewModel();
    }
}
