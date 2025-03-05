 using oop.demo;
internal class Program
{
    private static void Main(string[] args)
    {
        UserService.UserNo = "001";
        UserService.UserName = "王小明";

        using var user = new UserService();
        user.Login();
        Console.WriteLine(UserService.LoginInfo);

        user.Login("002", "李小華");
        Console.WriteLine(UserService.LoginInfo);

        user.Logout();
        Console.WriteLine(UserService.LoginInfo);


        Console.WriteLine();       

        Console.WriteLine();
        Console.Write("按任意鍵結束 ...");
        Console.ReadKey();

    }
}
