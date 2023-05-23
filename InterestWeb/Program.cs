using InterestWeb.Services;
using InterestWeb.Services.IServices;

namespace InterestWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddHttpClient<IInterestService, InterestService>();
            builder.Services.AddScoped<IInterestService, InterestService>();
            
            builder.Services.AddHttpClient<IPersonInterestService, PersonInterestService>();
            builder.Services.AddScoped<IPersonInterestService, PersonInterestService>();

            builder.Services.AddHttpClient<IPersonService, PersonService>();
            builder.Services.AddScoped<IPersonService, PersonService>();

            builder.Services.AddHttpClient<IInterestListService, InterestListService>();
            builder.Services.AddScoped<IInterestListService, InterestListService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}