using System.Runtime.InteropServices;

[DllImport("user32.dll", CharSet = CharSet.Unicode)] 
static extern int Foo(IntPtr hWnd, string text, string caption, uint type);

var result = Foo(0, "你好世界！", "你好世界！", 0);
Console.WriteLine(result);  