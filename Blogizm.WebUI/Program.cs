using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Desteklenen kültürleri tanýmlayýn
var supportedCultures = new[] { "en", "tr", "fr" }; // Örneðin Ýngilizce, Türkçe, Fransýzca

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("tr"); 
    options.SupportedCultures = supportedCultures.Select(culture => new CultureInfo(culture)).ToList();
    options.SupportedUICultures = supportedCultures.Select(culture => new CultureInfo(culture)).ToList();

    // Tarayýcý Dilini Kullan
    options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed((host) => true)
.AllowCredentials();
    });
});
var app = builder.Build();
app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.Use(async (context, next) =>
{
    context.Items["SupportedCultures"] = localizationOptions.SupportedCultures;
    await next.Invoke();
});
app.UseRequestLocalization(localizationOptions);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
