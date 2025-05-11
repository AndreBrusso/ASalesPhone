using ASalesPhone.Data;
using Microsoft.EntityFrameworkCore;
using ASalesPhone.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // <- Adiciona sessão aqui

string mySqlConnection = builder.Configuration.GetConnectionString("ASalesPhoneContext");

builder.Services.AddDbContext<ASalesPhoneContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<CadastroService>();
builder.Services.AddScoped<EstoqueCelularesService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // <- Antes da autorização
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cadastros}/{action=Index}/{id?}");

app.Run();
