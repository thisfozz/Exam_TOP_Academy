using Exam_TOP_Academy.ViewModels;
using System.Windows;

namespace Exam_TOP_Academy;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}