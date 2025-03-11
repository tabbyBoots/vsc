using System.Security.Cryptography.X509Certificates;
using oop.demo;

internal class Program
{
    public delegate void Score();
    public static int TotalScore = 0;
    private static void Main(string[] args)
    {
        using var demo = new DelegateDemo();
        demo.Run();

        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();
    }

    
}
