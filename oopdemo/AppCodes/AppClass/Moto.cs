using oop.demo;
/// 機車的類別
public class Moto: Engine{

    /// 座墊
    public string SeatCushion { get; set; } = "";

    /// 煞車系統
    public enBrakeType BrakeType { get; set; } = enBrakeType.Disc;
}