using Core.InterFaces;
using Core.Repositories;
using Data.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Application>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IFirst, RFirst>();
builder.Services.AddScoped<IAboutMe,RAboutMe>();
builder.Services.AddScoped<IStatics , RStatics>();
builder.Services.AddScoped<IAllAboutMe , RAllAboutMe>();
builder.Services.AddScoped<ISerrvices , RSerrvices>();
builder.Services.AddScoped<IComments , RComments>();
builder.Services.AddScoped<IBlog , RBlog>();
builder.Services.AddScoped<IContactUsAdmin , RContactUsAdmin>();
builder.Services.AddScoped<IContactUsClient , RContactUsClient>();
builder.Services.AddScoped<IUser , RUser>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services
.AddAuthentication (options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie (options =>
{
    options.LoginPath = "/admin/login/login";
    options.LogoutPath = "/Home/index";
    options.ExpireTimeSpan = TimeSpan.FromMinutes (120);
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
app.UseAuthentication ();
app.UseAuthorization ();
app.UseSession();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
