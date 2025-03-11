namespace oop.demo;

/// <summary>
/// 吐司類別
/// </summary>
public class Toast
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
    /// 吐司建構子
    /// </summary>
    public Toast()
    {
        ID = 0;
        Name = string.Empty;
    }
}
