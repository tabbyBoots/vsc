internal class Program
{
    private static void Main(string[] args)
    {
        //demo01("設計一個九九乘法表");
        //demo02("設計一個九九乘法表 , 每三個一組");
        //demo03("設計一個由 * 號組成的三角形 5 x 5 左靠,由小至大");
        //demo04("設計一個由 * 號組成的三角形 5 x 5 置中,由大至小");
        demo05("設計一個由 * 號組成的三角形 5 x 5 置中,由小至大");

        // 等待輸入任意鍵結束.
        Waiting();
    }

    #region //demo01("設計一個九九乘法表");
    static void demo01(string titleName){
        // 顯示標題列
        ShowTitle(titleName);

        for(int i=1; i<=9; i++){
            for(int j=1; j<=9; j++){
                Console.Write("{0}x{1}={2}\t", i, j, i*j);
            }
            Console.WriteLine();
        }

        // 顯示結束線條.
        ShowEnding();
    }
    #endregion

    #region //demo02("設計一個九九乘法表 , 每三個一組");
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

        // 顯示結束線條.
        ShowEnding();
    }
    #endregion

    #region //demo03("設計一個由 * 號組成的三角形 5 x 5 左靠,由小至大");
    static void demo03(string titleName)
    {
        // 顯示標題列
        ShowTitle(titleName);

        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        // 顯示結束線條.
        ShowEnding();
    }
    #endregion

    #region //demo04("設計一個由 * 號組成的三角形 5 x 5 置中,由大至小");
    static void demo04(string titleName)
    {
        // 顯示標題列
        ShowTitle(titleName);

        // 變數宣告
        string str_data = "";

        //for (int i = 5; i >= 1; i--)  //這個是倒三角形
        for (int i = 1; i <= 5; i++)    //這個是正向的三角形
        {
            str_data = "".PadLeft((5 - i), ' ');
            Console.Write(str_data);
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        // 顯示結束線條.
        ShowEnding();
    }
    #endregion

    #region //demo05("設計一個由 * 號組成的三角形 5 x 5 置中,由小至大");
    static void demo05(string titleName)
    {
        // 顯示標題列
        ShowTitle(titleName);

        // 變數宣告
        string str_data = "";

        for (int i = 5; i >= 1; i--)  //這個是倒三角形
        {
            str_data = "".PadLeft((5 - i), ' ');
            Console.Write(str_data);
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        // 顯示結束線條.
        ShowEnding();
    }
    #endregion

    #region //標題列跟結束列的功能
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
        Console.WriteLine("cool");

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
    #endregion
}