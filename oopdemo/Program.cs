 using oop.demo;
internal class Program
{
    private static void Main(string[] args)
    {
        using var person = new Person();
        using var daming = new Daming();
        using var xiaohua = new Xiaohua();

        Console.WriteLine(person.PersonInfo());
        Console.WriteLine(daming.PersonInfo());
        Console.WriteLine(xiaohua.PersonInfo());

        Console.WriteLine();       

        Console.WriteLine();
        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();

    }
}
