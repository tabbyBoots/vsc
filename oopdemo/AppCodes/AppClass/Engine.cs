/// 引擎的類別
public class Engine: Car{
    /// <summary>
    /// 車號
    /// </summary>
    public string CarNo { get; set; } = "";
    /// <summary>
    /// 引擎編號
    /// </summary>
    public string EngineNo { get; set; } = "";
    /// <summary>
    /// 進氣量(cc)
    /// </summary>
    public int CC { get; set; } = 2000;
    /// <summary>
    /// 汽油類型
    /// </summary>
    public enOilType OilType { get; set; } = enOilType.Type92;
    /// <summary>
    /// 汽油的基本資訊
    /// </summary>
    public string BaseInfo
    {
        get
        {
            string str_color = Enum.GetName(typeof(enColors), Color);
            string str_oil = "九二無鉛";
            if (OilType == enOilType.Type95) str_oil = "九五無鉛";
            if (OilType == enOilType.Type98) str_oil = "九八無鉛";
            return $"廠牌：{BrandName} 型號：{ModelName} CC數：{CC} 顏色：{str_color} 汽油類型：{str_oil}";
        }
    }
}