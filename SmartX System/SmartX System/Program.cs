using Microsoft.AspNetCore.Components.WebAssembly.Server;
using SmartX.Shared;
using SmartX.System.Services; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddSingleton<DeviceManager>();
builder.Services.AddSingleton<DataStorage>();
builder.Services.AddSingleton<PredictiveEngine>();
builder.Services.AddSingleton<TelemetryService>();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseCors("AllowAll");
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.MapGet("/api/menu", () => new[] {
    "Sensor Data Ingestion and Telemetry",
    "Real-Time Command Stream (Disabled)",
    "Network Topology (Disabled)"
});

app.MapPost("/api/telemetry/ingest", (TelemetryPacket<object> packet, TelemetryService service) =>
{
    try
    {
        
        service.ProcessPacket(packet);
        return Results.Ok();
    }
    catch (System.Exception)
    {
        return Results.BadRequest();
    }
});

app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();