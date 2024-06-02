using heatermanager;
using heaterobj;
using dataspace;
using demand;
using simulator;
using resultmanager;

var MyAllowSpecs = "allowspecs";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecs,
                    policy =>
                    {
                        policy.WithOrigins("*").AllowAnyHeader();
                    });
        });

var app = builder.Build();

app.UseCors(MyAllowSpecs);

var Data = new DataSpace();
var heater_manager = new HeaterManager();
var result_manager = new ResultManager();
var Simulator = new Simulator(Data, heater_manager, result_manager);

app.MapGet("/", () => "Hello World!");
app.MapPost("/heater/add", (HeaterObj heater) => heater_manager?.add(heater));
app.MapPost("/heater/remove", (int ID) => heater_manager?.remove(ID));
app.MapGet("/status", () => heater_manager?.getStatus());
app.MapPost("/data/add", (Demand Demand) => Data.AddDemand(Demand));
app.MapPost("/sim/start", async (int Time) => await Simulator.Start(Time));
app.MapGet("/sim/results", () => result_manager.GetResults());

app.Run();
