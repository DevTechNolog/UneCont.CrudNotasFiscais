using Application.Interfaces;
using Application.Services;
using NotaFiscalApp.Domain.Interfaces;
using NotaFiscalApp.Infrastructure.Data.Repositories;
using NotaFiscalApp.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<INotaFiscalService, NotaFiscalService>();
builder.Services.AddSingleton<INotaFiscalRepository, NotaFiscalRepository>();

builder.Services.AddAutoMapper(c => c.AddProfile<AutoMapping>());

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
