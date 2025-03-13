using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ASalesPhone.Data;
using ASalesPhone.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
string mySqlConnection =
              builder.Configuration.GetConnectionString("ASalesPhoneContext");

builder.Services.AddDbContext<ASalesPhoneContext>(options =>
                options.UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));

var app = builder.Build();

// registrar serviço (eu)

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//eu


// Executa o seeding ao iniciar a aplicação
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cadastros}/{action=Index}/{id?}");

app.Run();

