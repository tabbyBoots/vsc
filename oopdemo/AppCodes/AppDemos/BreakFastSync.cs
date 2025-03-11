namespace oop.demo;

/// <summary>
/// 早餐同步作業
/// </summary>
public partial class BreakFast : BaseClass
{
    /// <summary>
    /// 倒杯咖啡
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public Coffee PourCoffee(int delay)
    {
        Utilitys.DelaySync(delay);
        return new Coffee();
    }

    /// <summary>
    /// 熱鍋
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    public void HeatingPot(int delay)
    {
        Utilitys.DelaySync(delay);
    }

    /// <summary>
    /// 煎蛋
    /// </summary>
    /// <param name="howMany">蛋數</param>
    /// <param name="delay">每粒蛋耗時時間(單位:秒)</param>
    /// <returns></returns>
    public Egg FryEggs(int howMany, int delay)
    {
        string str_name = "";
        for (int i = 1; i <= howMany; i++)
        {
            str_name = string.Format(" 煎第{0}粒", i);
            Utilitys.JobName += str_name;
            Console.Write(str_name);
        }
        Utilitys.DelaySync(delay);
        return new Egg();
    }

    /// <summary>
    /// 煎培根
    /// </summary>
    /// <param name="delay1">切片耗時時間(單位:秒)</param>
    /// <param name="delay2">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public Bacon FryBacon(int delay1, int delay2)
    {
        string str_name = "";

        str_name = " 切培根";
        Utilitys.JobName += str_name;
        Console.Write(str_name);
        Utilitys.DelaySync(delay1);

        str_name = " 煎培根";
        Utilitys.JobName += str_name;
        Console.Write(str_name);
        Utilitys.DelaySync(delay2);

        return new Bacon();
    }

    /// <summary>
    /// 烤吐司
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public Toast ToastBread(int delay)
    {
        Utilitys.DelaySync(delay);
        return new Toast();
    }

    /// <summary>
    /// 塗果醬
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void ApplyJam(int delay)
    {
        Utilitys.DelaySync(delay);
    }

    /// <summary>
    /// 塗奶油
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public void ApplyButter(int delay)
    {
        Utilitys.DelaySync(delay);
    }

    /// <summary>
    /// 倒柳橙汁
    /// </summary>
    /// <param name="delay">耗時時間(單位:秒)</param>
    /// <returns></returns>
    public Juice PourOrangeJuice(int delay)
    {
        Utilitys.DelaySync(delay);
        return new Juice();
    }
}
