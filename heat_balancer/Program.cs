using heatermanager;
using heaterobj;
using dataspace;
using demand;
using state;
using simulator;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var Data = new DataSpace();
var heater_manager = new HeaterManager();
var Simulator = new Simulator(Data, heater_manager);

app.MapGet("/", () => "Hello World!");
app.MapPost("/heater/add", (HeaterObj heater) => heater_manager?.add(heater));
app.MapPost("/heater/remove", (int ID) => heater_manager?.remove(ID));
app.MapGet("/status", () => heater_manager?.getStatus());
app.MapPost("/data/add", (Demand Demand) => Data.AddDemand(Demand));
app.MapPost("/sim/start", async (Simulation Mode) => await Simulator.Start(Mode));

app.Run();
