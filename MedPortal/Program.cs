using MedPortal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
builder.Services.AddTransient<IFindUsers, FindUser>();
builder.Services.AddTransient<IGetAllUsers, GetAll>();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/denied";
});

AuthorizationPolicyBuilder policyBuilder = new AuthorizationPolicyBuilder();
policyBuilder.RequireClaim("access-level", "admin");
AuthorizationOptions options = new AuthorizationOptions();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccess", policyBuilder.Build());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return ("/Index");
});


app.MapRazorPages();

app.UseStaticFiles();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

app.Run();
