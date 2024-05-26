using heatermanager;
using heaterobj;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var heater_manager = HeatManager.Instance;

app.MapGet("/", () => "Hello World!");
app.MapPost("/heater/add", (HeaterObj heater) => heater_manager?.add(heater));

app.Run();
