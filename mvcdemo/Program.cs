using System.Text.Encodings.Web;
using System.Text.Unicode;
using mvcdemo.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
        .AddJsonOptions(options =>
        {
            //原本是 JsonNamingPolicy.CamelCase，強制頭文字轉小寫，我偏好維持原樣，設為null
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //允許基本拉丁英文及中日韓文字維持原字元
            options.JsonSerializerOptions.Encoder =
                JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs);
        });
// 設定 Session
// 需先加入 Guget Package "Microsoft.AspNetCore.Session"
// 將 Session 存在 ASP.NET Core 記憶體中
builder.Services.AddDistributedMemoryCache();
// 設定加入 AddHttpContextAccessor
builder.Services.AddHttpContextAccessor();
// 設定 Session 參數值
builder.Services.AddSession(options =>
    {
        // 設定 Session 過期時間, 單位為秒 , 20分鐘 = 20*60 = 1,200秒
        //options.IdleTimeout = TimeSpan.FromSeconds(1200);
        // 設定 Session 過期時間, 單位為分鐘
        options.IdleTimeout = TimeSpan.FromMinutes(20);
        // 限制只有在 HTTPS 連線的情況下，才允許使用 Session
        //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.Name = "mvcdemo";
        // 表示此 Cookie 限伺服器讀取設定，document.cookie 無法存取
        options.Cookie.HttpOnly = true;
    });

//enable the session-based TempData provider
builder.Services.AddRazorPages().AddSessionStateTempDataProvider();
builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();       // 啟用 Session  
app.UseCookiePolicy();  // 啟用 Cookie Policy
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
//app.MapStaticAssets();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "Remark",
    pattern: "Demo/Remark");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//    .WithStaticAssets();


app.Run();
