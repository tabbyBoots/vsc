using oop.demo;
internal class Program
{
    private static void Main(string[] args)
    {
        using var fruit = new FruitCarton();
        fruit.Package();
        Console.WriteLine(fruit.CartonInfo);



        Console.WriteLine();       

        Console.WriteLine();
        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();

    }
}
