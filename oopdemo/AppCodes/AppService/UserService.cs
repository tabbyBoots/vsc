/// <summary>
/// 管理登入使用者的服務類別
/// </summary>
public class UserService : BaseClass
{
    private static bool _IsLogin = false;
    public static bool IsLogin { get{ return _IsLogin; } }
    public static string UserNo { get; set; } = "";
    public static string UserName { get; set; } = "";

    public static string LoginInfo
    {
        get
        {
            if (_IsLogin) return $"登入者：{UserNo} {UserName}";
            return $"未登入";
        }
    }

    public void Login()
    {
        _IsLogin = true;
    }

    public void Login(string userNo, string userName)
    {
        UserNo = userNo;
        UserName = userName;
        _IsLogin = true;
    }

    public void Logout()
    {
        _IsLogin = false;
        UserNo = "None";
        UserName = "遊客";
    }

}