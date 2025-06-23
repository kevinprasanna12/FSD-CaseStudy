var builder = WebApplication.CreateBuilder(args);

// Add MVC support
builder.Services.AddControllersWithViews();

// Register HttpClient with matching name to your controller usage
builder.Services.AddHttpClient("CaseStudyAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7224/"); 
});

// Add session support
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserInfo}/{action=LoginPage}/{id?}");

app.Run();
