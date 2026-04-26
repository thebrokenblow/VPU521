using System.Runtime.InteropServices;

public class Program
{

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern int Foo(IntPtr hWnd, string text, string caption, uint type);


    [DllImport("SimpleMath.dll", EntryPoint = "Add")]
    public static extern int Add(int a, int b);

    public static void Main()
    {
        Example2();
    }

    public static void Example1()
    {
        var result = Foo(0, "你好世界！", "你好世界！", 0);
        Console.WriteLine(result);
    }

    public static void Example2()
    {
        Console.WriteLine("Введите первое число");
        var firstNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите второе число");
        var secondNumber = int.Parse(Console.ReadLine());

        var result = Add(firstNumber, secondNumber);

        Console.WriteLine(result);
    }
}