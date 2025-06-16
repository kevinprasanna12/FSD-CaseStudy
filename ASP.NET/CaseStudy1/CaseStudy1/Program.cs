namespace CaseStudy1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=ShowAllClientDetails}/{id?}");

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/client/all");
                return Task.CompletedTask;
            });

            app.Run();
        }
    }
}
