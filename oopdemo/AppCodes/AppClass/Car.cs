/// <summary>
/// 車子的類別
/// </summary>
public class Car
{
    /// <summary>
    /// 廠牌名稱
    /// </summary>
    public string BrandName { get; set; } = "";
    /// <summary>
    /// 型號
    /// </summary>
    public string ModelName { get; set; } = "";
    /// <summary>
    /// 車重(噸)
    /// </summary>
    public int Weight { get; set; }
    /// <summary>
    /// 顏色
    /// </summary>
    public enColors Color { get; set; } = enColors.Red;
    /// <summary>
    /// 長度(M)
    /// </summary>
    public int Length { get; set; }
    /// <summary>
    /// 寛度(M)
    /// </summary>
    public int Width { get; set; }
    /// <summary>
    /// 高度(M)
    /// </summary>
    public int Height { get; set; }
}
