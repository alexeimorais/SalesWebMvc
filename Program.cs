﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SalesWebMvc.Data;
using SalesWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("SalesWebMvcContext");
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    //options.UseMySql(builder.Configuration.GetConnectionString("SalesWebMvcContext"),  builder => builder.MigrationsAssembly("SalesWebMvc")));
    options.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(connectionString)));
//options.UseSqlServer(builder.Configuration.GetConnectionString("SalesWebMvcContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMvcContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add service
builder.Services.AddScoped<SellerService>();

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
