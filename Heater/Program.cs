using heater;
using state;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var heater = Heater.Instance;

app.MapPost("/start", () => heater.start());
app.MapPost("/stop", () => heater.stop());
app.MapGet("/state", () => heater.state());
app.MapGet("/ok", () => StateConnection.connected);

app.Run();
