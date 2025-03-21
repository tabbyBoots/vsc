var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//註冊營業稅計算 DI
builder.Services.AddScoped<ICountry, CountryTaiwan>();

builder.Services.AddScoped<IScoped, ScopedClass>();
builder.Services.AddSingleton<ISingleton, SingletonClass>();
builder.Services.AddTransient<ITransient, TransientClass>();
builder.Services.AddTransient<SampleService, SampleService>();


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


app.Run();
