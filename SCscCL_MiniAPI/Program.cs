using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

#region 4种请求方法基本结构

app.MapGet("/", () => "This is a GET");
app.MapPost("/", () => "This is a POST");
app.MapPut("/", () => "This is a PUT");
app.MapDelete("/", () => "This is a DELETE");

#endregion

//TODO:微软官方教程继续尝试Demo:https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-7.0
class Service { }
record Person(string Name, int Age);
//app.MapGet("SCsc/{id}", ([FromRoute] int id,
//                     [FromQuery(Name = "p")] int page,
//                     [FromServices] Service service,
//                     [FromHeader(Name = "Content-Type")] string contentType)
//                     => { });



#region 
app.MapMethods("/options-or-head", new[] { "OPTIONS", "HEAD" }, () => "这是一个选项或头请求");
app.MapMethods("/get-or-post-or-put-delete-options-or-head", new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS", "HEAD" }, () => "这是一个选项或头请求");
app.MapGet("/lambda", () => "这是一个内联 lambda");
Func<string> handler = () => "这是一个 lambda 变量";
app.MapGet("/func", handler);
HelloHandler helloHandler = new HelloHandler();
app.MapGet("/hello", helloHandler.Hello);
app.MapGet("/staticHello", HelloHandler.StaticHello);
#endregion

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
