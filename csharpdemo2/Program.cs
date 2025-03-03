internal class Program
{
    private static void Main(string[] args)
    {
        //demo01("設計一個九九乘法表");
        demo02("設計一個九九乘法表 , 每三個一組");
        // 等待輸入任意鍵結束.
        Waiting();
    }

    static void demo01(string titleName){
        // 顯示標題列
        ShowTitle(titleName);

        for(int i=1; i<=9; i++){
            for(int j=1; j<=9; j++){
                Console.Write("{0}x{1}={2}\t", i, j, i*j);
            }
            Console.WriteLine();
        }
    }

    static void demo02(string titleName){
        // 顯示標題列
        ShowTitle(titleName);

        for(int k =1; k<=9; k+=3){
            for(int i=1; i<=9; i++){
                for(int j=0; j<3; j++){
                    Console.Write("{0} x {1} = {2}\t", k+j, i, (k + j)*i);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    static void ShowTitle(string titleName)
    {
        //顯示標題列
        Console.WriteLine(new String('-', 50));
        Console.WriteLine("題目：{0}", titleName);
        Console.WriteLine(new String('-', 50));
        Console.WriteLine();
    }
    static void ShowEnding()
    {
        // 顯示結束列
        Console.WriteLine();
        Console.WriteLine(new String('-', 50));
    }
    static void Waiting()
    {
        // 等待輸入任意鍵結束.
        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();
    }
}