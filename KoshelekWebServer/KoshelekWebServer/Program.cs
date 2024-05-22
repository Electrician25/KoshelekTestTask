using KoshelekWebServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddMvc();

builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddRouting();

builder.AddApplicationContext();

builder.Services.AddApplicationtServices();

var app = builder.Build();

app.UseCors(options =>
    options.WithOrigins("https://localhost:7248/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthorization();

app.MapRazorPages();

app.Run();