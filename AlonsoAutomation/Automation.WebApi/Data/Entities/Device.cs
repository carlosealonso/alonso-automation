using System;

namespace Automation.WebApi.Data.Entities
{
    public class Device
    {
        public long Id { get; set; }
        public string DeviceExternalId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}