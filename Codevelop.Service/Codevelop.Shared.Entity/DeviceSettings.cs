using System;

namespace Codevelop.Shared.Entity
{
    public class DeviceSettings
    {
        public Guid Id { get; set; }

        public Guid DeviceId { get; set; }

        public int MinimumTemp { get; set; }

        public int TargetTemp { get; set; }
    }
}
