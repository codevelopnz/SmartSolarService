using System;
using System.Collections.Generic;

namespace Codevelop.Shared.Entity
{
    public class DeviceSettings
    {
        public DeviceSettings()
        {
            TargetTempAt = new List<DateTimeOffset>();
        }

        public Guid Id { get; set; }

        public Guid DeviceId { get; set; }

        public bool Active { get; set; }

        public string SettingsDescription { get; set; }

        public int MinimumTemp { get; set; }

        public int TargetTemp { get; set; }


        public List<DateTimeOffset> TargetTempAt { get; set; }

        public DateTimeOffset? BoostUntil { get; set; }


    }
}
