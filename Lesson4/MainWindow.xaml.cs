using System.Windows;
using System.Windows.Controls;

namespace Lesson4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click1(object sender, RoutedEventArgs e)
    {
        var value = decimal.Parse(Number1.Text);

        var thread = new Thread(() => CalculateSumNumber(
            value,
            isEnabled => Button1.IsEnabled = isEnabled,
            result => { Result1.Text = result; }));

        thread.Start();
    }

    private void Button_Click2(object sender, RoutedEventArgs e)
    {
        var value = decimal.Parse(Number2.Text);

        var thread = new Thread(() => CalculateSumNumber(
            value,
            isEnabled => Button2.IsEnabled = isEnabled,
            result => { Result2.Text = result; }));

        thread.Start();
    }


    private static void CalculateSumNumber(decimal value, Action<bool> setEnabledButton, Action<string> setResult)
    {
        var sum = 0m;

        Application.Current.Dispatcher.BeginInvoke(() => setEnabledButton.Invoke(false));

        for (int i = 1; i < value; i++)
        {
            sum += value;
        }

        Application.Current.Dispatcher.BeginInvoke(() => setEnabledButton.Invoke(true));
        Application.Current.Dispatcher.BeginInvoke(() => setResult.Invoke(sum.ToString()));
    }
}