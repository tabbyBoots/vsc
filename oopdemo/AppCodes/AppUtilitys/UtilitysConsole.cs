namespace oop.demo;

/// <summary>
/// 輔助工具類別-主控台相關
/// </summary>
public partial class Utilitys
{
    /// <summary>
    /// 直線的長度
    /// </summary>
    public static int LineLength { get; set; } = 50;
    /// <summary>
    /// 顯示直線(固定為50)
    /// </summary>
    public static void ShowLine()
    {
        ShowLine(LineLength);
    }
    /// <summary>
    /// 顯示虛線(固定為50)
    /// </summary>
    public static void ShowDashLine()
    {
        ShowDashLine(LineLength);
    }
    /// <summary>
    /// 顯示直線
    /// </summary>
    /// <param name="length">長度</param>
    public static void ShowLine(int length)
    {
        LineLength = (length == 0 ? LineLength : length);
        Console.WriteLine(new String('-', LineLength));
    }
    /// <summary>
    /// 顯示虛線
    /// </summary>
    /// <param name="length">長度</param>
    public static void ShowDashLine(int length)
    {
        LineLength = (length == 0 ? LineLength : length);
        for (int i = 0; i < length; i += 2)
        {
            Console.Write("- ");
        }
        Console.WriteLine();
    }
    /// <summary>
    /// 顯示標題列
    /// </summary>
    /// <param name="titleName">標題名稱</param>
    public static void ShowTitle(string titleName)
    {
        ShowTitle(titleName, 0);
    }
    /// <summary>
    /// 顯示標題列
    /// </summary>
    /// <param name="titleName">標題名稱</param>
    /// <param name="lineLength">直線的長度</param>
    public static void ShowTitle(string titleName, int lineLength)
    {
        if (lineLength > 0)
            ShowLine(lineLength);
        else
            ShowLine();
        Console.WriteLine("題目：{0}", titleName);
        ShowLine();
    }
    /// <summary>
    /// 等待輸入任意鍵結束.
    /// </summary>
    public static void ShowEnding()
    {
        Console.WriteLine();
        ShowLine();
    }
}
