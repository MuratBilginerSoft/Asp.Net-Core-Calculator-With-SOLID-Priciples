using Calculator_With_SOLID_Principles.BlueWhale.Process;
using Calculator_With_SOLID_Principles.BlueWhale.Services;
using Calculator_With_SOLID_Principles.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
builder.Services.AddTransient<Addition>();
builder.Services.AddTransient<Subtraction>();
builder.Services.AddTransient<Multiplation>();
builder.Services.AddTransient<Division>();

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
