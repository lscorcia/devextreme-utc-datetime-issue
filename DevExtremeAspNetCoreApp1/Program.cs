using DevExtremeAspNetCoreApp1.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;

        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });

// Configure localization settings
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture("it-IT");
    options.AddSupportedCultures("it-IT", "en-US");
    options.AddSupportedUICultures("it-IT", "en-US");
    options.FallBackToParentUICultures = true;
});

var app = builder.Build();

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
