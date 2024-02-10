using System.ComponentModel;

namespace Exam_TOP_Academy.ViewModels;
public class MainViewModel : INotifyPropertyChanged
{
    private string _beginRangePrice;
    public string BeginRangePrice
    {
        get { return _beginRangePrice; }
        set
        {
            if (_beginRangePrice != value)
            {
                _beginRangePrice = value;
                OnPropertyChanged(nameof(BeginRangePrice));
            }
        }
    }

    private string _endRangePrice;
    public string EndRangePrice
    {
        get { return _endRangePrice; }
        set
        {
            if (_endRangePrice != value)
            {
                _endRangePrice = value;
                OnPropertyChanged(nameof(EndRangePrice));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
