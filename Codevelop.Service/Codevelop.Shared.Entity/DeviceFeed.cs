using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codevelop.Shared.Entity
{
    public class DeviceFeed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FeedId { get; set; }
        public Guid DeviceId{ get; set; }

        public DateTimeOffset Timestamp { get; set; }

        public bool IsHeating { get; set; }

        public bool IsPumpOn { get; set; }

        public int TankLowerTemp { get; set; }

        public int TankUpperTemp { get; set; }

        public int PanelTemp { get; set; }


    }
}
