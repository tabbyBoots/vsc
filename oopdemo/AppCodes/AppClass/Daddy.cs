namespace oop.demo;

public class Daddy : BaseClass
{
    private int BankSavings { get; set; }
    private int Cash { get; set; }
    public int Salary { get; set; }
    public int Money { get; set; }

    public Daddy()
    {
        Money = 0;
        BankSavings = 20000;
        Cash = 50000;
        Salary = 0;
    }

    /// <summary>
    /// 領薪水
    /// </summary>
    /// <param name="month">工作月份</param>
    public virtual void GetPaid(int month){
        int int_amount = (BankSavings + Cash);
        Money += int_amount;
        Console.WriteLine($"繼承父親的財產：{int_amount}");
    }
    /// <summary>
    /// 顯示目前財產現狀
    /// </summary>
    public string Information()
    {
        return $"目前的財產金額為：{Money}";
    }
    
}