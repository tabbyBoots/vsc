internal class Program
{
    private static void Main(string[] args)
    {
        var bmi = new BMICalculator();
        Console.Write("請輸入身高(公分): ");
        bmi.Height = double.Parse(Console.ReadLine());
        Console.Write("請輸入體重(公斤): ");
        bmi.Weight = double.Parse(Console.ReadLine());
        Console.WriteLine($"BMI 指數: {bmi.Calculate()}");
        Console.WriteLine($"BMI 結果: {bmi.Result()}");
        Console.ReadKey();
    }
}
