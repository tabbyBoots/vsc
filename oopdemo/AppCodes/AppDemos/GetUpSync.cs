namespace oop.demo;

/// <summary>
/// 起床同步作業
/// </summary>
public partial class GetUp : BaseClass
{
    /// <summary>
    /// 刷牙
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void BrushTeeth(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 洗臉
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void WashFace(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 洗澡
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void Bath(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 洗頭
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void Shampoo(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 吹乾頭髮
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void BlowDryHair(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 穿衣服
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void WearClothes(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 喝牛奶
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void DrinkMilk(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 吃麵包
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void EatBread(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 坐公車
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void TakeBus(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
    /// <summary>
    /// 看書
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void Reading(int delay)
    {
        Utilitys.DelayAsync(delay).Wait();
    }
}
