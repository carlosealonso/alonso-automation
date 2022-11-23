using System;

namespace Automation.WebApi.DTO
{
    public class HumidityDTO
    {
        public float Value { get; set; }
        public DateTime? DateCreated { get; set; }
        public string DeviceId { get; set; }
    }
}