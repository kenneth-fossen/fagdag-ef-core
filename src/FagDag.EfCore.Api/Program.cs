using FagDag.EfCore.Api.Services;
using FagDag.EfCore.Database;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<EpicEventsDbContext>(options =>
{
    options.UseInMemoryDatabase("EpicEvents");
});
builder.Services.AddScoped<IEpicEventsService, EpicEventsService>();

builder.Services.AddOpenApi();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
