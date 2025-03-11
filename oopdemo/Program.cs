using oop.demo;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("----------------數字---------------");
        GenericDemo<int> intValue = new GenericDemo<int>();
        intValue.AddItem(1); intValue.AddItem(5); intValue.AddItem(3);
        int index = 0;
        foreach (var item in intValue.DataList)
        {
            index++;
            Console.WriteLine($"第{index}筆資料: {item}");
        }

        //文字
        Console.WriteLine();
        Console.WriteLine("----------------文字---------------");
        GenericDemo<string> strValue = new GenericDemo<string>();
        strValue.AddItem("A"); strValue.AddItem("B"); strValue.AddItem("C");
        index = 0;
        foreach(var item in strValue.DataList)
        {
            index++;
            Console.WriteLine($"第{index}筆資料: {item}");
        }

        //模型類別
        Console.WriteLine();
        Console.WriteLine("----------------模型類別---------------");
        GenericDemo<Users> users = new GenericDemo<Users>();
        users.AddItem(new Users { UserNo = "001", UserName = "A", Age =18 });
        users.AddItem(new Users { UserNo = "002", UserName = "B", Age = 20 });
        users.AddItem(new Users() { UserNo = "003", UserName = "王大華", Age = 20 });
        index = 0;
        foreach (var item in users.DataList)
        {
            index++;
            Console.WriteLine($"第{index}筆資料: {item.UserNo} {item.UserName} {item.Age}");    
        }


        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();
    }

}
