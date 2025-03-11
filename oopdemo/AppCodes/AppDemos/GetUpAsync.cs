namespace oop.demo;

/// <summary>
/// 起床非同步作業
/// </summary>
public partial class GetUp : BaseClass
{
    /// <summary>
    /// 刷牙
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task BrushTeethTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }
    /// <summary>
    /// 洗臉
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task WashFaceTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }
    /// <summary>
    /// 洗澡
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task BathTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }
    /// <summary>
    /// 洗頭
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task ShampooTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }
    /// <summary>
    /// 喝牛奶
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task DrinkMilkTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }
    /// <summary>
    /// 吃麵包
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task EatBreadTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }
    /// <summary>
    /// 坐公車
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task TakeBusTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }
    /// <summary>
    /// 看書
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task ReadingTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }
}
