/// 機車的類別
public class Moto: Engine{
    /// <summary>
    /// 座墊
    /// </summary>
    public string SeatCushion { get; set; } = "";
    /// <summary>
    /// 煞車系統
    /// </summary>
    public enBrakeType BrakeType { get; set; } = enBrakeType.Disc;

}