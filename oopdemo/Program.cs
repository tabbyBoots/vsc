// using Demo.Data;
// using oop.demo;
internal class Program
{
    private static void Main(string[] args)
    {
        // Person person1 = new Person();
        // Students st1 = new Students();
        // Console.WriteLine("Info: {0}", st1.FullDescription);

        // Console.WriteLine("顏色枚舉類型所有元素為:");
        // foreach(string s in Enum.GetNames(typeof(enColors))){
        //     Console.WriteLine(s);
        // }

        // Console.WriteLine("顏色枚舉類型所有元素值為:");
        // foreach(var s in Enum.GetValues(typeof(enColors))){
        //     Console.WriteLine(s);            
        // }
        // Console.WriteLine();
        // Enum mColors = enColors.Yellow;
        // Console.WriteLine("這個實例的值是:{0}", mColors.ToString());
        Lite Vino50 = new Lite();
        Vino50.BrandName = "YAMAHA";
        Vino50.ModelName = "VINO";
        Vino50.CC = 50;
        Vino50.Color = enColors.Red;
        Vino50.OilType = enOilType.Type95;
        Console.WriteLine(Vino50.BaseInfo);

        Console.WriteLine();
        Utility.Waiting();
    }
}