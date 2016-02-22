using System;

namespace Codevelop.Shared.Entity
{
    public class DeviceFeed
    {
        public Guid FeedId { get; set; }
        public Guid DeviceId{ get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public bool IsHeating { get; set; }

        public int IsPumpOn { get; set; }

        public int TankLowerTemp { get; set; }

        public int TankUpperTemp { get; set; }

        public int PanelTemp { get; set; }


    }
}
