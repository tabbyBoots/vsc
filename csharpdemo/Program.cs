internal class Program
{
    static double length =0;
    static double width =0;
    private static void Main(string[] args)
    {
        Config();
        Display();
        Console.WriteLine("Enter any key to stop.");
        Console.ReadKey();

    }

    static void Config(){
        length = 4.0;
        width = 3.0;
    }

    static void Display(){
        Console.WriteLine("Length: {0}", length);
        Console.WriteLine("Width: {0}", width);
        Console.WriteLine("Area: {0}", GetArea());
    }

    static double GetArea(){
        return length * width;
    }
}