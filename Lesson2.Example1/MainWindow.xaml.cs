using System.Diagnostics;
using System.Windows;

namespace Lesson2.Example1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Process? _currentProcess;

    public MainWindow()
    {
        InitializeComponent();

        AppDomain domain = AppDomain.CreateDomain("MyDomain");
    }

    private void CreateProcess_Button_Click(object sender, RoutedEventArgs e)
    {
        _currentProcess = Process.Start("D:\\projects\\source\\repos\\VPU521\\Lesson2.Example2\\bin\\Debug\\net10.0-windows\\Lesson2.Example2.exe");
    }

    private void KillProcess_Button_Click(object sender, RoutedEventArgs e)
    {
        _currentProcess?.Kill();
        _currentProcess = null;
    }
}