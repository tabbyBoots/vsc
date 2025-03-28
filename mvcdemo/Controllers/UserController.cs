using Microsoft.AspNetCore.Mvc;

namespace mvcdemo.Controllers
{
    public class UserController : BaseController
    {
        /// <summary>
        /// 使用者首頁
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            // 取得使用者名稱
            ViewBag.UserName = GetSessionValue("UserName", "");
            return View();
        }
        /// <summary>
        /// 使用者註冊輸入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            vmRegister model = new vmRegister();
            // 設定輸入預設值
            model.GenderCode = "M";
            model.IsMember = true;
            return View(model);
        }
        /// <summary>
        /// 使用者註冊確認
        /// </summary>
        /// <param name="model">使用者註冊資料</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(vmRegister model)
        {
            // 驗證模型狀態
            // 這是標準Ｍeta data 驗證
            if (!ModelState.IsValid) return View(model);
            // 自定義驗證密碼長度
            if (model.Password.Length < 5)
            {
                // 這是自訂義 Ｍeta data 驗證
                ModelState.AddModelError("Password", "登入密碼長度需要至少5個字元!!");
                return View(model);
            }
            // 自定會員性別
            // 這是自訂義 Ｍeta data 驗證
            if (model.IsMember && model.GenderCode != "F")
            {
                ModelState.AddModelError("", "會員性別必須為女性!!");
                return View(model);
            }
            // 註冊成功
            TempData["MessageText"] = $"使用者 {model.UserNo} {model.UserName} 註冊成功";
            return RedirectToAction("MessageText", "User", new { area = "" });
        }
        /// <summary>
        /// 顯示訊息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MessageText()
        {
            ViewBag.MessageText = TempData["MessageText"];
            return View();
        }

        /// <summary>
        /// 使用者登入輸入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            // 讀取使用者登入 Cookie
            var model = GetLoginCookie();
            return View(model);
        }
        /// <summary>
        /// 使用者登入確認
        /// </summary>
        /// <param name="model">使用者登入資料</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(vmLogin model)
        {
            // 驗證模型狀態
            if (!ModelState.IsValid) return View(model);
            // 驗證使用者登入
            if (model.UserName != "admin" || model.Password != "12345")
            {
                ModelState.AddModelError("UserName", "使用者名稱或密碼錯誤!!");
                return View(model);
            }
            // 設定或刪除使用者登入 Cookie
            if (model.RememberMe)
                SetLoginCookie(model);
            else
                DeleteLoginCookie();
            // 登入成功
            // TempData["MessageText"] = $"使用者 {model.UserName} 登入成功";
            // return RedirectToAction("MessageText", "User", new { area = "" });

            // 登入成功
            SetSessionValue("UserName", model.UserName);
            return RedirectToAction("Index", "User", new { area = "" });
        }
        /// <summary>
        /// 設定使用者登入 Cookie
        /// </summary>
        /// <param name="model">使用者登入資料</param>
        private void SetLoginCookie(vmLogin model)
        {
            if (model.RememberMe)
            {
                // 設定 Cookie 的值和選項
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true, // 只有透過 HTTP 存取，避免 JavaScript 存取
                    Secure = true, // 僅限 HTTPS 傳輸
                    Expires = DateTime.UtcNow.AddDays(30) // 設定過期時間
                };
                Response.Cookies.Append("MvcDemoUserName", model.UserName, cookieOptions);
                Response.Cookies.Append("MvcDemoPassword", model.Password, cookieOptions);
                Response.Cookies.Append("MvcDemoRememberMe", model.RememberMe ? "1" : "0", cookieOptions);
            }
        }
        /// <summary>
        /// 讀取使用者登入 Cookie
        /// </summary>
        public vmLogin GetLoginCookie()
        {
            string str_user_name = "";
            string str_password = "";
            string str_remember_me = "0";
            if (!Request.Cookies.TryGetValue("MvcDemoUserName", out str_user_name)) str_user_name = "";
            if (!Request.Cookies.TryGetValue("MvcDemoPassword", out str_password)) str_password = "";
            if (!Request.Cookies.TryGetValue("MvcDemoRememberMe", out str_remember_me)) str_remember_me = "0";
            vmLogin model = new vmLogin();
            model.UserName = str_user_name;
            model.Password = str_password;
            model.RememberMe = str_remember_me == "1";
            return model;
        }
        /// <summary>
        /// 刪除使用者登入 Cookie
        /// </summary>
        public void DeleteLoginCookie()
        {
            Response.Cookies.Delete("MvcDemoUserName");
            Response.Cookies.Delete("MvcDemoPassword");
            Response.Cookies.Delete("MvcDemoRememberMe");
        }






    }
}