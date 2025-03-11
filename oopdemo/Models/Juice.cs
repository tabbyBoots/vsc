namespace oop.demo;

/// <summary>
/// 柳橙汁類別
/// </summary>
public class Juice
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; } = 0;
    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// 容量(單位：cc)
    /// </summary>
    public int Capacity { get; set; } = 0;
    /// <summary>
    /// 柳橙汁類別建構子
    /// </summary>
    public Juice()
    {
        ID = 0;
        Name = "柳橙汁";
        Capacity = 0;
    }
}
