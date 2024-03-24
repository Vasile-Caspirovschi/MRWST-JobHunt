using JobHunt.Application;
using JobHunt.Application.Common.Interfaces;
using JobHunt.Infrastracture;
using JobHunt.Infrastracture.Persistence;
using JobHunt.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastracture(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    using var scope = app.Services.CreateScope();
    using var dbContext = scope.ServiceProvider.GetRequiredService<IJobHuntDbContext>();
    dbContext.Migrate();
    await DbSeeder.SeedRoles(scope.ServiceProvider);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
