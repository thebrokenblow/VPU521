using Lesson4.Model;
using Lesson4.ViewModel.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lesson4.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private decimal _result1;
    public decimal Result1
    {
        get => _result1;
        set
        {
            _result1 = value;
            OnPropertyChanged();
        }
    }

    private decimal _result2;
    public decimal Result2
    {
        get => _result2;
        set
        {
            _result2 = value;
            OnPropertyChanged();
        }
    }

    public decimal Number1 { get; set; }
    public decimal Number2 { get; set; }

    public RelayCommand CalculateSum1 { get; }
    public CancelCommand CancelSum1 { get; }

    public RelayCommand CalculateSum2 { get; }
    public CancelCommand CancelSum2 { get; }

    public MainViewModel(Action<Action> changeStateView)
    {
        var calculate = new Calculate();

        CancelSum1 = new CancelCommand(
            changeStateView,
            _ => calculate.CancelParallelSum());

        CalculateSum1 = new RelayCommand(
            CancelSum1,
            changeStateView,
            _ => calculate.CalculateParallelSumNumber(
                Number1,
                result =>
                {
                    Result1 = result;
                    CalculateSum1?.IsCanExecute = true;
                    CancelSum1.IsCanExecute = false;
                }));

        CancelSum2 = new CancelCommand(
            changeStateView,
            _ => calculate.CancelParallelSum());

        CalculateSum2 = new RelayCommand(
            CancelSum2,
            changeStateView,
            _ => calculate.CalculateParallelSumNumber(
                Number2,
                result =>
                {
                    Result2 = result;
                    CalculateSum2?.IsCanExecute = true;
                    CancelSum2.IsCanExecute = false;
                }));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}