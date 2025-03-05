namespace oop.demo;/// 車子的類別
public class Car : BaseClass
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

    /// <summary>
    /// 設定車子體積參數事件
    /// </summary>
    public void SetCarData(int length, int width, int height){
        Length = length;
        Width = width;
        Height = height;
    }

    private string CarData1 { get; set; } = "";
    protected string CarData2 { get; set; } = "";


    /// <summary>
    /// 取得車子體積函數範例
    /// </summary>
    public int GetCarVolume(){
        int int_volume = Length * Width * Height;
        return int_volume;
    }
}