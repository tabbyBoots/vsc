internal class Program
{
    private static void Main(string[] args)
    {
        int int_x = 0;
        int int_y = 0;
        if (args == null || args.Length != 2)
        {
            Console.WriteLine("執行時請傳入兩個參數(x 及 y)!!");
            Console.WriteLine("例如：myconsole 10 15");
        }
        else
        {
            bool bln_x = int.TryParse(args[0], out int_x);
            bool bln_y = int.TryParse(args[1], out int_y);
            if (!bln_x || !bln_y)
            {
                Console.WriteLine("傳入的參數必須為整數數值!!");
                Console.WriteLine("例如：myconsole 10 15");
            }
            else
            {
                Console.WriteLine($"x = {int_x} , y = {int_y} , x + y = {int_x + int_y}");
            }
        }
    }
}
