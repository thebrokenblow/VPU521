using Lesson4.ViewModel;
using System.Windows;

namespace Lesson4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel(ChangeStateView);
    }

    private void ChangeStateView(Action action)
    {
        Application.Current.Dispatcher.BeginInvoke(action);
    }
}