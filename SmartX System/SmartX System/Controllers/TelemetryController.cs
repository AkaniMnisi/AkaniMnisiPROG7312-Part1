using Microsoft.AspNetCore.Mvc;
using SmartX.Shared; 
using SmartX.Shared.Models;
using SmartX.System.Services;

namespace SmartX.System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetryController : ControllerBase
    {
        private readonly DeviceManager _deviceManager;
        private readonly DataStorage _dataStorage;
        private readonly PredictiveEngine _predictiveEngine;

        public TelemetryController(DeviceManager deviceManager, DataStorage dataStorage, PredictiveEngine predictiveEngine)
        {
            _deviceManager = deviceManager;
            _dataStorage = dataStorage;
            _predictiveEngine = predictiveEngine;
        }

        [HttpPost("ingest")]
        public IActionResult IngestData([FromBody] TelemetryPacket<object> packet)
        {
            
            var macAddress = packet?.MacAddress;


            return Ok(new { Message = "Data Ingested", Mac = macAddress });
        }

        [HttpPost("command")]
        public IActionResult IssueCommand([FromBody] ManualCommand command)
        {
            _deviceManager.ExecuteCommand(command.CommandName);
            return Ok($"Command '{command.CommandName}' executed.");
        }

        [HttpPost("undo")]
        public IActionResult UndoCommand()
        {
            return Ok(_deviceManager.UndoLastCommand());
        }
    }
}