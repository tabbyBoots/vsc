
namespace oopdemo.AppCodes.AppClass;
public class CallByV_CallByR
{
    public static void A(){ ///傳址呼叫會加上 ref 關鍵字
        int X = 0;
        int W = B(ref X);
        Console.WriteLine($"X = {X}, W = {W}");
    }

    public static int B(ref int Y){
        Y += 100;
        return Y;
    }
}
