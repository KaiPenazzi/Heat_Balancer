using heater;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var heater = Heater.Instance;

app.MapGet("/start", () => heater.start());
app.MapGet("/stop", () => heater.stop());
app.MapGet("/state", () => heater.state());

app.Run();
