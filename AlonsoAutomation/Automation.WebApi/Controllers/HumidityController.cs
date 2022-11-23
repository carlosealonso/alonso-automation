using Automation.WebApi.Data;
using Automation.WebApi.Data.Entities;
using Automation.WebApi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Automation.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class HumidityController : ControllerBase
{

    private readonly ILogger<HumidityController> _logger;
    private readonly AutomationDBContext _db;

    public HumidityController(ILogger<HumidityController> logger, AutomationDBContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public IEnumerable<Humidity> Get(DateTime? dataInicio, DateTime? dataFim)
    {
        if(dataInicio.HasValue && dataFim.HasValue)
        {
            return _db.Humidities
                .Where(w => w.DateCreated >= dataInicio && w.DateCreated <= dataFim)
                .ToList();
        }
        else
        {
            return _db.Humidities
                .ToList();
        }
    }

    [HttpPost]
    public IResult Post(HumidityDTO humidity)
    {
        var device = _db.Devices.FirstOrDefault(f => f.DeviceExternalId.Equals(humidity.DeviceId) );
        
        if(device == null)
            return Results.NotFound($"Device {humidity.DeviceId} not found!");

        var humidityBase = new Humidity
        {
            DateCreated =  humidity.DateCreated ?? DateTime.Now,
            DateInserted = DateTime.Now,
            DeviceId = device.Id,
            Value = humidity.Value
        };

        _db.Add<Humidity>(humidityBase);
        
        device.LastCommunication = humidityBase.DateCreated;

        _db.SaveChanges();

        return Results.Ok();
    }
}
