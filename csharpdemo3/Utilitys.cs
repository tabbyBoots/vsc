public static class Utilitys
{
    public static void ShowTitle(string titleName)
    {
        //顯示標題列
        Console.WriteLine(new String('-', 50));
        Console.WriteLine("題目：{0}", titleName);
        Console.WriteLine(new String('-', 50));
        Console.WriteLine();
    }

    public static void ShowEnding()
    {
        // 顯示結束列
        Console.WriteLine();
        Console.WriteLine(new String('-', 50));
    }

    public static void Waiting()
    {
        // 等待輸入任意鍵結束.
        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();
    }
}
