using Automation.WebApi.Data;
using Automation.WebApi.Data.Entities;
using Automation.WebApi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Automation.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DeviceController : ControllerBase
{

    private readonly ILogger<DeviceController> _logger;
    private readonly AutomationDBContext _db;

    public DeviceController(ILogger<DeviceController> logger, AutomationDBContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public IEnumerable<Device> Get()
    {
        return _db.Devices.ToList();
    }

    [HttpPost]
    public IResult Post(DeviceDTO device)
    {
        if( _db.Devices.Any(a => a.DeviceExternalId.Equals(device.DeviceId)))
            return Results.Accepted();

        _db.Add<Device>(new Device
            {
                DateCreated = DateTime.Now,
                DeviceExternalId = device.DeviceId
            });
        _db.SaveChanges();

        return Results.Ok();
    }
}
