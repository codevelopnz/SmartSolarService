using System;

namespace Codevelop.Shared.Entity
{
    /// <summary>
    /// Rollup of DeviceFeed
    /// </summary>
    public class DeviceFeedSummary
    {
        public Guid FeedSummaryId { get; set; }
        public Guid DeviceId{ get; set; }
      
        public DateTimeOffset Date { get; set; } // time ignored, just date and UTC component

        public TimeSpan HeatDuration { get; set; }

        public int PumpDuration { get; set; }

        public int MaximumTemp { get; set; }

        public int MinimumTemp { get; set; }

        public TimeSpan BoostDuration { get; set; }
    }
}
