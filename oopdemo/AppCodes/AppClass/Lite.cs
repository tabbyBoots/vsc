namespace oop.demo;
/// 輕型機車的類別
public class Lite: Moto{
    
    /// <summary>
    /// 輕型機車建構子
    /// </summary>
    public Lite()
    {
        LiteNo = "";
        LiteName = "";
    }

    public Lite(string brandName, string modelName, enColors color)
    {
        BrandName = brandName;
        ModelName = modelName;
        Color = color;
    }

    /// 輕型機車編號
    public string LiteNo { get; set; } = "";

    /// 輕型機車名稱
    public string LiteName { get; set; } = "";
}