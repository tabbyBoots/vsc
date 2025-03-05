namespace oop.demo;

public class Child1 : Daddy
{
    public Child1()
    {
        Money = 0;
        //兒子每月工作的薪水
        Salary = 20000;
        Console.WriteLine($"兒子總財產初始值：{Money}");
    }

    /// <summary>
    /// 第一種繼承情形建構子
    /// </summary>
    /// <param name="money">兒子總財產初始值</param>
    public Child1(int money)
    {
        //兒子總財產初始值
        Money = money;
        //兒子每月工作的薪水
        Salary = 20000;
        Console.WriteLine($"兒子總財產初始值：{Money}");
    }
    /// <summary>
    /// 領薪水
    /// </summary>
    /// <param name="month">工作月份</param>
    public override void GetPaid(int month)
    {
        //兒子總財產加上繼承父親的財產(銀行存款+現金)
        base.GetPaid(month);
        Money += (Salary * month);
        Console.WriteLine($"兒子總財產加上工作 {month} 月, 每月薪資為 {Salary} = {(Salary * month)}");
    }
}