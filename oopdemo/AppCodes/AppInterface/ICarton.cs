namespace oop.demo;
/// <summary>
/// 紙箱介面
/// </summary>
public interface ICarton
{
    int Length { get; set; }
    int Width { get; set; }
    int Height { get; set; }
    int Weight { get; set; }
    string CartonInfo { get;}
    /// <summary>
    /// 打包
    /// </summary>
    void Package();

}