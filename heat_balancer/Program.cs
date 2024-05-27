using heatermanager;
using heaterobj;
using dataspace;
using demand;
using state;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var Data = new DataSpace();
var heater_manager = new HeatManager(Data);

app.MapGet("/", () => "Hello World!");
app.MapPost("/heater/add", (HeaterObj heater) => heater_manager?.add(heater));
app.MapPost("/heater/remove", (int ID) => heater_manager?.remove(ID));
app.MapGet("/status", () => heater_manager?.getStatus());
app.MapPost("/data/add", (Demand Demand) => Data.AddDemand(Demand));
app.MapPost("/sim/start", (Simulation Mode) => heater_manager.Start(Mode));

app.Run();
