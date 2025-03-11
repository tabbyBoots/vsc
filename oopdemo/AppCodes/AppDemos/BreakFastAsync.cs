namespace oop.demo;

/// <summary>
/// 早餐非同步作業
/// </summary>
public partial class BreakFast : BaseClass
{
    /// <summary>
    /// 倒杯咖啡
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task<Coffee> PourCoffeeTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
        return new Coffee();
    }

    /// <summary>
    /// 熱鍋
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    public async Task HeatingPotTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }

    /// <summary>
    /// 煎蛋
    /// </summary>
    /// <param name="delay">每粒蛋耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task<Egg> FryEggsTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
        return new Egg();
    }

    /// <summary>
    /// 煎培根
    /// </summary>
    /// <param name="delay1">切片耗時時間(單位:秒)</param>
    /// <param name="delay2">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task<Bacon> FryBaconTask(int delay1, int delay2)
    {
        await Utilitys.DelayAsync(delay1);
        await Utilitys.DelayAsync(delay2);
        return new Bacon();
    }

    /// <summary>
    /// 烤吐司
    /// </summary>
    /// <param name="slices">吐司片數</param>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task<Toast> ToastBreadTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
        return new Toast();
    }

    /// <summary>
    /// 從烤箱拿出吐司。
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    public async Task TakeOutToastTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }

    /// <summary>
    /// 在吐司塗上奶油和果醬
    /// </summary>
    /// <param name="jobStep">作業序號</param>
    /// <param name="model">作業列表</param>
    /// <returns></returns>
    public async Task<Toast> MakeToastWithButterAndJamTask(int jobStep, List<Job> model)
    {
        //在吐司塗上奶油
        jobStep++;
        Utilitys.SetJobStepStart(jobStep, model[jobStep].JobName, model[jobStep].JobDelay, false);
        await ApplyButterTask(model[jobStep].JobDelay);
        Utilitys.SetJobStepEnd();

        //在吐司塗上果醬
        jobStep++;
        Utilitys.SetJobStepStart(jobStep, model[jobStep].JobName, model[jobStep].JobDelay, false);
        await ApplyJamTask(model[jobStep].JobDelay);
        Utilitys.SetJobStepEnd();
        return new Toast();
    }

    /// <summary>
    /// 塗果醬
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task ApplyJamTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }

    /// <summary>
    /// 塗奶油
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task ApplyButterTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
    }

    /// <summary>
    /// 倒柳橙汁
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public async Task<Juice> PourOrangeJuiceTask(int delay)
    {
        await Utilitys.DelayAsync(delay);
        return new Juice();
    }
}
