using System;

namespace Automation.WebApi.Data.Entities
{
    public class Humidity
    {
        public long Id { get; set; }
        public float Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateInserted { get; set; }
        public long DeviceId { get; set; }
    }
}