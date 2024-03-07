using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteLanches.Context;
using SiteLanches.Models;
using SiteLanches.Repositories;
using SiteLanches.Repositories.Interfaces;
using SiteLanches.Services;
using ReflectionIT.Mvc.Paging;
using SiteLanches.Areas.Admin.Servicos;


var builder = WebApplication.CreateBuilder(args);





builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer("Server=localhost;Database=SiteLanches;Trusted_Connection=True;");
//});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<ILanchesRepository, LancheRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
        politica =>
        {
            politica.RequireRole("Admin");
        });
});

builder.Services.AddPaging(options =>
{
    options.ViewName = "Bootstrap5";
    options.PageParameterName = "pageindex";
});


//esse eu vi no arquivo do cara mas nao vi sendo usado em nenhuma aula,
//pode ter passado batifo mas ate agora nao deu em nada
builder.Services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/home/AccessDenied");


builder.Services.Configure<ConfigurationImages>(builder.Configuration.GetSection("ConfigurationPastaImages"));



builder.Services.AddScoped<RelatorioVendasService>(); //geralmente nao se faz assim


builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


CriarPerfisUsuarios(app);


/*
//cjat gpt que fez 
mas da erro na hora de buildar
var seedUserRoleService = app.Services.GetRequiredService<ISeedUserRoleInitial>();
seedUserRoleService.SeedRoles();
seedUserRoleService.SeedUsers();
*/

/*
 * 
 * TAVA PADARAO ESSE VOU USAR ENDPOITS COMO NO CURSO 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

*/

app.UseEndpoints(endpoints =>
{
    /*
     * utilizado apenas pra mostrar fuincionanemto
    endpoints.MapControllerRoute(
       name: "teste",
       pattern: "testeme",
       defaults: new { Controller = "teste", action = "Index" });

    endpoints.MapControllerRoute(
       name: "admin",
       pattern: "admin/{action=Index}/{id?}",
       defaults: new { Controller = "admin"});


    */

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");





    endpoints.MapControllerRoute(
       name: "categoriaFiltro",
       pattern: "Lanche/{action}/{categoria?}",
       defaults: new { Controller = "Lanche", action = "List" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();


//ver isso aqui melhor depois
void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        service.SeedRoles();
        service.SeedUsers();
        //service.SeedRolesAsync().Wait();
    }
}