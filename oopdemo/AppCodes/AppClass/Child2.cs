namespace oop.demo;

public class Child2 : Daddy
{
    public Child2()
    {
        //兒子總財產初始值
        Money = 0;
        //兒子每月工作的薪水
        Salary = 20000;
        Console.WriteLine($"兒子總財產初始值：{Money}");
    }

    public Child2(int money)
    {
        //兒子總財產初始值
        Money = money;
        //兒子每月工作的薪水
        Salary = 20000;
        Console.WriteLine($"兒子總財產初始值：{Money}");
    }

    public sealed override void GetPaid(int month)
    {
        //兒子總財產加上自己工作的薪資
        Money += (Salary * month);
        Console.WriteLine($"兒子總財產加上工作 {month} 月, 每月薪資為 {Salary} = {(Salary * month)}");
    }
}