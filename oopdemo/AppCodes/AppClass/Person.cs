namespace oop.demo;

public class Person : BaseClass
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person()
    {
        Name = "no name";
        Age = 0;
    }

    public virtual string hobby(){
        return "no hobby";
    }

    public string PersonInfo(){
        string str_hobby = hobby();
        return $"姓名：{Name} 年齡：{Age} 興趣：{str_hobby}";
    }
}