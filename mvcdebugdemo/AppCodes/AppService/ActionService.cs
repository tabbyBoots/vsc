/// <summary>
/// Action 服務類別
/// </summary>
public static class ActionService
{
    /// <summary>
    /// HttpContextAccessor 物件
    /// </summary>
    /// <returns></returns>
    public static IHttpContextAccessor _contextAccessor { get; set; } = new HttpContextAccessor();
    /// <summary>
    /// HttpContext 物件
    /// </summary> 
    public static HttpContext? _context { get { return _contextAccessor.HttpContext; } }
    /// <summary>
    /// 取得目前的 Area 名稱
    /// </summary>
    public static string Area
    {
        get
        {
            object value = _context.GetRouteData().Values["Area"];
            return (value == null) ? "" : value.ToString();
        }
    }
    /// <summary>
    /// 取得目前的 Controller 名稱
    /// </summary>
    public static string Controller
    {
        get
        {
            object value = _context.GetRouteData().Values["Controller"];
            return (value == null) ? "" : value.ToString();
        }
    }
    /// <summary>
    /// 取得目前的 Action 名稱
    /// </summary>
    public static string Action
    {
        get
        {
            object value = _context.GetRouteData().Values["Action"];
            return (value == null) ? "" : value.ToString();
        }
    }
    /// <summary>
    /// 設定目前的 Action 名稱(或自行指定)
    /// </summary>
    /// <param name="action">Action 代號</param>
    public static void SetActionName(enAction action = enAction.None)
    {
        SessionService.ActionName = "";
        if (action == enAction.None)
        {
            var currentAction = (enAction)Enum.Parse(typeof(enAction), Action);
            SessionService.ActionName = SessionService.GetActionName(currentAction);
        }
        else
        {
            SessionService.ActionName = SessionService.GetActionName(action);
        }
    }
    /// <summary>
    /// 設定Action 名稱
    /// </summary>
    /// <param name="actionName">Action 名稱</param>
    public static void SetActionName(string actionName)
    {
        SessionService.ActionName = actionName;
    }
    /// <summary>
    /// 設定事件副標題
    /// </summary>
    /// <param name="subActionName">副標題</param>
    public static void SetSubActionName(string subActionName = "")
    {
        SessionService.SubActionName = subActionName;
    }
    /// <summary>
    /// Action 初始化
    /// </summary>
    public static void ActionInit()
    {
        SessionService.ActionName = "";
        SessionService.SubActionName = "";
        SessionService.SearchText = "";
        SessionService.SortColumn = "";
        SessionService.SortDirection = "asc";
        SessionService.CardSize = "card-size-max";
    }
    /// <summary>
    /// 設定動作卡片寛度
    /// </summary>
    /// <param name="cardSize">卡片寛度</param>
    public static void SetActionCardSize(enCardSize cardSize = enCardSize.Max)
    {
        string str_size = Enum.GetName(typeof(enCardSize), cardSize).ToLower();
        SessionService.CardSize = $"card-size-{str_size}";
    }
    /// <summary>
    /// 設定排序欄位及方式
    /// </summary>
    /// <param name="id">欄位名稱</param>
    public static void SetActionSort(string id = "")
    {
        if (SessionService.SortColumn == id)
        {
            SessionService.SortDirection = (SessionService.SortDirection == "asc") ? "desc" : "asc";
        }
        else
        {
            SessionService.SortColumn = id;
            SessionService.SortDirection = "asc";
        }
    }
    /// <summary>
    /// 取得目前的 id 值
    /// </summary>
    public static string id
    {
        get
        {
            object value = _context.GetRouteData().Values["id"];
            return (value == null) ? "" : value.ToString();
        }
    }
    /// <summary>
    /// 取得目前的頁數
    /// </summary>
    public static string Page
    {
        get
        {
            object value = _context.GetRouteData().Values["id"];
            return (value == null) ? "1" : value.ToString();
        }
    }
    /// <summary>
    /// 取得目前的 Http 通訊協定是 Http 還是 Https，如 https
    /// </summary>
    public static string Http
    {
        get { return _context.Request.Scheme.ToString(); }
    }
    /// <summary>
    /// 取得目前的 Domain Name，如 localhsot:2283
    /// </summary>
    public static string Host
    {
        get { return _context.Request.Host.ToString(); }
    }
    /// <summary>
    /// 取得目前的 Http 及 Domain Name 組合，如 https://localhsot:2283
    /// </summary>
    /// <value></value>
    public static string HttpHost
    {
        get { return $"{Http}://{Host}"; }
    }
    /// <summary>
    /// Row ID
    /// </summary>
    /// <value></value>
    public static int RowId
    {
        get
        {
            int int_value = 0;
            string str_value = "0";
            if (_context != null) str_value = _context.Session.Get<string>("RowId");
            if (str_value == null) str_value = "0";
            if (!int.TryParse(str_value, out int_value)) int_value = 0;
            return int_value;
        }
        set
        { _context?.Session.Set<string>("RowId", value.ToString()); }
    }
    /// <summary>
    /// Row Data
    /// </summary>
    /// <value></value>
    public static string RowData
    {
        get
        {
            string str_value = "0";
            if (_context != null) str_value = _context.Session.Get<string>("RowData");
            if (str_value == null) str_value = "0";
            return str_value;
        }
        set
        { _context?.Session.Set<string>("RowData", value); }
    }
    /// <summary>
    /// View Action 名稱
    /// </summary>
    /// <value></value>
    public static string ViewActionName
    {
        get
        {
            string str_value = "";
            if (_context != null) str_value = _context.Session.Get<string>("ViewActionName");
            if (str_value == null) str_value = "";
            return str_value;
        }
        set
        { _context?.Session.Set<string>("ViewActionName", value); }
    }
    /// <summary>
    /// Home Action 名稱
    /// </summary>
    public static string Home { get { return "Home"; } }

    /// <summary>
    /// Init Action 名稱
    /// </summary>
    public static string Init { get { return "Init"; } }

    /// <summary>
    /// DetailPage Action 名稱
    /// </summary>
    public static string DetailPage { get { return "DetailPage"; } }

    /// <summary>
    /// Init Action 名稱
    /// </summary>
    public static string AfterInit { get { return "AfterInit"; } }

    /// <summary>
    /// Index Action 名稱
    /// </summary>
    public static string BeforeIndex { get { return "BeforeIndex"; } }

    /// <summary>
    /// Indexed Action 名稱
    /// </summary>
    public static string Index { get { return "Index"; } }

    /// <summary>
    /// Create Action 名稱
    /// </summary>
    public static string Create { get { return "Create"; } }

    /// <summary>
    /// CreateMaster Action 名稱
    /// </summary>
    public static string CreateMaster { get { return "CreateMaster"; } }

    /// <summary>
    /// Detail Action 名稱
    /// </summary>
    public static string Detail { get { return "Detail"; } }

    /// <summary>
    /// Edit Action 名稱
    /// </summary>
    public static string Edit { get { return "Edit"; } }

    /// <summary>
    /// EditMaster Action 名稱
    /// </summary>
    public static string EditMaster { get { return "EditMaster"; } }

    /// <summary>
    /// CreateEdit Action 名稱
    /// </summary>
    public static string BeforeCreateEdit { get { return "BeforeCreateEdit"; } }

    /// <summary>
    /// CreateEdit Action 名稱
    /// </summary>
    public static string BeforeCreateMasterEdit { get { return "BeforeCreateMasterEdit"; } }

    /// <summary>
    /// CreateEdited Action 名稱
    /// </summary>
    public static string CreateEdit { get { return "CreateEdit"; } }

    /// <summary>
    /// CreateEdited Action 名稱
    /// </summary>
    public static string CreateEditMaster { get { return "CreateEditMaster"; } }

    /// <summary>
    /// Delete Action 名稱
    /// </summary>
    public static string Delete { get { return "Delete"; } }

    /// <summary>
    /// DeleteMaster Action 名稱
    /// </summary>
    public static string DeleteMaster { get { return "DeleteMaster"; } }

    /// <summary>
    /// Sort Action 名稱
    /// </summary>
    public static string Sort { get { return "Sort"; } }

    /// <summary>
    /// Search Action 名稱
    /// </summary>
    public static string Search { get { return "Search"; } }

    /// <summary>
    /// SearchText 名稱
    /// </summary>
    public static string SearchText { get { return "SearchText"; } }

    /// <summary>
    /// Select Action 名稱
    /// </summary>
    public static string Select { get { return "Select"; } }

    /// <summary>
    /// Confirm Action 名稱
    /// </summary>
    public static string Confirm { get { return "Confirm"; } }

    /// <summary>
    /// Close Action 名稱
    /// </summary>
    public static string Close { get { return "Close"; } }

    /// <summary>
    /// Print Action 名稱
    /// </summary>
    public static string Print { get { return "Print"; } }

    /// <summary>
    /// Upload Action 名稱
    /// </summary>
    public static string Upload { get { return "Upload"; } }

    /// <summary>
    /// Doenload Action 名稱
    /// </summary>
    public static string Doenload { get { return "Doenload"; } }

    /// <summary>
    /// First 名稱
    /// </summary>
    public static string First { get { return "First"; } }

    /// <summary>
    /// Last 名稱
    /// </summary>
    public static string Last { get { return "Last"; } }

    /// <summary>
    /// Prior 名稱
    /// </summary>
    public static string Prior { get { return "Prior"; } }

    /// <summary>
    /// Next 名稱
    /// </summary>
    public static string Next { get { return "Next"; } }

    /// <summary>
    /// List 名稱
    /// </summary>
    public static string List { get { return "List"; } }

    /// <summary>
    /// BeforeList 名稱
    /// </summary>
    public static string BeforeList { get { return "BeforeList"; } }

    /// <summary>
    /// ErrorMessage Action 名稱
    /// </summary>
    public static string ErrorMessage { get { return "ErrorMessage"; } }

    /// <summary>
    /// 無權限執行
    /// </summary>
    public static string SecurityError { get { return "SecurityError"; } }

    /// <summary>
    /// PageInfo 名稱
    /// </summary>
    public static string PageInfo(int page = 1, int PageCount = 1) { return $"第 {page} 頁，共 {PageCount}頁"; ; }

    /// <summary>
    /// 設定 Action 程式參數
    /// </summary>
    /// <param name="prgNo">程式代號</param>
    /// <param name="prgName">程式名稱</param>
    public static void SetPrgInfo(string prgNo, string prgName)
    {
        SessionService.PrgNo = prgNo;
        SessionService.PrgName = prgName;
    }

    /// <summary>
    /// 取得目前控制器的指定 Action 的網址 
    /// </summary>
    /// <param name="actionName">Action 名稱</param>
    /// <returns></returns>
    public static string CurrentActionLinkUrl(string actionName)
    {
        string str_area = string.IsNullOrEmpty(Area) ? "" : $"/{Area}";
        string str_controller = string.IsNullOrEmpty(Controller) ? "" : $"/{Controller}";
        string str_action = $"/{actionName}";
        string str_url = $"{HttpHost}{str_area}{str_controller}{str_action}";
        var location = new Uri(str_url);
        return location.ToString();
    }

    /// <summary>
    /// 取得錯誤作業訊息文字
    /// </summary>
    /// <param name="actionName">錯誤作業名稱</param>
    /// <returns></returns>
    public static string GetErrorMessage(string actionName)
    {
        string str_message = "";
        switch (actionName)
        {
            case "None":
                str_message = "無此功能"; break;
            case "NotFound":
                str_message = "資料找不到"; break;
            case "Unauthorized":
                str_message = "此功能未經授權"; break;
            case "Forbidden":
                str_message = "此功能禁止使用"; break;
            case "":
                str_message = "錯誤作業"; break;
        }
        return str_message;
    }
}