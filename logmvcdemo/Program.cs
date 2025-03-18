using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 清除預設的日誌提供者並添加自訂的提供者
// builder.Logging.ClearProviders();
// builder.Logging.AddConsole(); // 添加主控台日誌

// 設定 Serilog //輸出成JSON格式
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}") // 可選：輸出至 Console,轉出 JSON 格式
    .WriteTo.File(new Serilog.Formatting.Json.JsonFormatter(), "logs/log.log", rollingInterval: RollingInterval.Day) // 輸出至 logs 資料夾
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // 忽略 Microsoft 大部分的日誌
    .MinimumLevel.Override("System", LogEventLevel.Warning) // 忽略 System 大部分的日誌
    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information) // 保留 Hosting 啟動日誌
    .Filter.ByExcluding(logEvent =>
        logEvent.Properties.ContainsKey("SourceContext") &&
        logEvent.Properties["SourceContext"].ToString().Contains("Microsoft.Hosting.Lifetime") &&
        (logEvent.MessageTemplate.Text.Contains("Content root path") ||
        logEvent.MessageTemplate.Text.Contains("Hosting environment:") ||
        logEvent.MessageTemplate.Text.Contains("Application started. Press Ctrl+C to shut down.")))
    .CreateLogger();


// 使用 Serilog 作為 Logging Provider
builder.Host.UseSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

//app.MapStaticAssets();
app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//    .WithStaticAssets();

// 記錄 HTTP 請求
app.UseSerilogRequestLogging(options =>
{
    options.GetLevel = (httpContext, elapsed, ex) =>
        ex != null || httpContext.Response.StatusCode >= 500
            ? LogEventLevel.Error    // 只有 500 以上錯誤才記錄
            : LogEventLevel.Verbose; // 其他請求不記錄
});

app.Run();
