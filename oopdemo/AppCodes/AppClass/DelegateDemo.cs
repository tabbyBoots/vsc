namespace oop.demo;

public class DelegateDemo : BaseClass
{
    public delegate void Arithmetic(int a, int b);
    public int int_value = 0;
    public string str_value ="";

    public void Run()
    {
        Arithmetic myevent;
        int_value = 0;
        myevent = Add;
        myevent(10, 7);
        myevent = Sub;
        myevent(10, 7);

        myevent = Add;
        myevent += Sub;
        myevent(10, 7);
    }
    public void Add(int a, int b)
    {
        int_value += (a + b);
        str_value = "事件：Add ";
        str_value += $"{a} + {b} = {(a + b)} ";
        str_value += $"累計：{int_value}";
        Console.WriteLine(str_value);
    }
    public void Sub(int a, int b)
    {
        int_value += (a - b);
        str_value = "事件：Sub ";
        str_value += $"{a} - {b} = {(a - b)} ";
        str_value += $"累計：{int_value}";
        Console.WriteLine(str_value);
    }
}