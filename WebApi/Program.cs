using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Services.FileService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AplicationDbContext>(config=>config.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<ICarService,CarServices>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<AplicationDbContext>();
await context.Database.MigrateAsync();

app.UseCors(
    corsPolicyBuilder => corsPolicyBuilder
        .WithOrigins(
        "http://127.0.0.1:5500",
        "http://localhost:3000",
        "https://localhost:3000")
        .SetIsOriginAllowed(_ => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
);

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Prod"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();

