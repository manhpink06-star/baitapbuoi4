namespace baitapbuoi4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Đăng ký MVC
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Cấu hình xử lý lỗi
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Static files
            app.MapStaticAssets();

            // Route mặc định
            // Khi F5 sẽ chạy HomeController -> Index()
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}