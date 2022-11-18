using Automation.WebApi.Data;
using Automation.WebApi.Data.Entities;
using Automation.WebApi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Automation.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
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
    public IEnumerable<Humidity> Get()
    {
        return _db.Humidities.ToList();
    }

    [HttpPost]
    public IResult Post(HumidityDTO humidity)
    {
        _db.Add<Humidity>(new Humidity
            {
                DateCreated = DateTime.Now,
                DateInserted = DateTime.Now,
                DeviceId = _db.Devices.First(f => f.DeviceExternalId.Equals(humidity.DeviceId) ).Id,
                Value = humidity.Value
            });
        
        _db.SaveChanges();

        return Results.Ok();
    }
}
