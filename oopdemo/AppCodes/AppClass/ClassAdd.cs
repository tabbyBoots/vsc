namespace oop.demo;

public class ClassAdd : BaseClass
{
    /// <summary>
    /// 加法-傳入一數字-int
    /// </summary>
    public int Add(int i)
    {
        return i + i;
    }
    /// <summary>
    /// 加法-傳入2數字-int
    /// </summary>
    public int Add(int i, int j)
    {
        return i + j;
    }
    /// <summary>
    /// 加法-傳入2數字 double
    /// </summary>
    public double Add(double i, double j)
    {
        return i + j;
    }

}