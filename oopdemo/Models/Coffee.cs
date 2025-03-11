namespace oop.demo;

/// <summary>
/// 咖啡的類別
/// </summary>
public class Coffee
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 容量(單位：cc)
    /// </summary>
    public int Capacity { get; set; }
    public Coffee()
    {
        ID = 0;
        Name = string.Empty;
        Capacity = 0;
    }
}
