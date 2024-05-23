using KoshelekClient.ActionResult;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting();

builder.Services.AddControllers();

builder.Services.AddTransient(provider =>
{
    return new Func<string, HtmlResult>(
        path => ActivatorUtilities.CreateInstance<HtmlResult>(provider, path));
});

var app = builder.Build();

app.MapControllers();

app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();