 using oop.demo;
internal class Program
{
    private static void Main(string[] args)
    {
        Lite Vino50 = new Lite();
        Vino50.BrandName = "YAMAHA";
        Vino50.ModelName = "VINO";
        Vino50.CC = 50;
        Vino50.Color = enColors.Red;
        Vino50.OilType = enOilType.Type95;
        Console.WriteLine(Vino50.BaseInfo);

        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();

    }
}