using Microsoft.EntityFrameworkCore;
using MyApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HTTPS em produção
}
else
{
    // Em desenvolvimento, não redireciona para HTTPS
    // Isso permite acessar pelo celular via HTTP sem warnings
    // app.UseHttpsRedirection(); // comentado intencionalmente
}

// Em produção, redireciona para HTTPS
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseRouting();

app.UseAuthorization();

// Mapeamento de assets estáticos
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
