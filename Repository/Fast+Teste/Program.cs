using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.EF;
using Repository.Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

//Referencia para EntityFramework SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<GenericRepository<Conferente>>();
builder.Services.AddScoped<ConferenteServices>(provider =>
{
    var repo = provider.GetRequiredService<GenericRepository<Conferente>>();
    var context = provider.GetRequiredService<Context>();
    return new ConferenteServices(repo, context);
});

builder.Services.AddScoped<EntregadorServices>(provider =>
{
    var repo = provider.GetRequiredService<GenericRepository<Entregador>>();
    var context = provider.GetRequiredService<Context>();
    return new EntregadorServices(repo, context);
});
builder.Services.AddScoped<GenericRepository<Entregador>>();
builder.Services.AddScoped<GenericRepository<Entrega>>();
builder.Services.AddScoped<EntregaServices>(provider =>
{
    var repo = provider.GetRequiredService<GenericRepository<Entrega>>();
    var context = provider.GetRequiredService<Context>();
    return new EntregaServices(repo, context);
});

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

app.UseSession();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
        var context = services.GetRequiredService<Context>();
        DBInitializer.Initialize(context);
}
catch (Exception ex)
{
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while initializing the database.");
}

app.Run();
