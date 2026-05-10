ThreadPool.QueueUserWorkItem(_ => DoWork1());
ThreadPool.QueueUserWorkItem(_ => DoWork2());


Console.ReadLine();
//8 -> 16

static void DoWork1()
{
    for (int i = 0; i < 10; i++)   
    {
        Console.WriteLine($"DoWork1");
        Thread.Sleep(100);
    }
}

static void DoWork2()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"DoWork2");
        Thread.Sleep(100);
    }
}
