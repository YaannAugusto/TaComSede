using BebidaAppl.Context;
using BebidaAppl.Models;
using BebidaAppl.Repositories;
using BebidaAppl.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BebidaAppl;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        //basicamente, crio um container para registrar um serviço de injeção de dependencia e liberar a participação dela
        services.AddTransient<IDrinkRepository, DrinkRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IBrandRepository, BrandRepository>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //em sua vifa, cria uma instância a cada pedido
        services.AddScoped(sp => ShopCart.GetCart(sp));

        services.AddControllersWithViews();

        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();
        app.UseAuthorization();
       

        app.UseEndpoints(endpoints =>
        {
            

            endpoints.MapControllerRoute(
                name: "BrandFilter",
                pattern: "Bebida/{action}/{brand?}",
                defaults: new {Controller="Bebida", action= "Drinks" });


            endpoints.MapControllerRoute(
               name: "CategoryFilter",
               pattern: "Bebida/{action}/{category?}",
               defaults: new { Controller = "Bebida", action = "Categories" });

          

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}