 using oop.demo;
internal class Program
{
    private static void Main(string[] args)
    {
        using var YamahaYY61 = new Lite();
        YamahaYY61.BrandName = "Yamaha";
        YamahaYY61.ModelName = "YY61";
        YamahaYY61.Color = enColors.Blue;
        YamahaYY61.CC = 125;
        YamahaYY61.OilType = enOilType.Type98;
        Console.WriteLine(YamahaYY61.BaseInfo);

        Console.WriteLine();
        
        using var YamahaYY62 = new Lite("Yamaha", "YY62", enColors.Red);
        YamahaYY62.CC = 150;
        YamahaYY62.OilType = enOilType.Type95;
        Console.WriteLine(YamahaYY62.BaseInfo);

        Console.WriteLine();
        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();

    }
}
