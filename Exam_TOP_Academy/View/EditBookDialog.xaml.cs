using Exam_TOP_Academy.ViewModels;
using System.Windows;

namespace Exam_TOP_Academy.View;
public partial class EditBookDialog : Window
{
    public EditBookDialog()
    {
        InitializeComponent();
        DataContext = new EditBookViewModel();
    }
}
