using System;
using System.ComponentModel.DataAnnotations;

namespace Codevelop.Shared.Entity
{
   
    


    public class DeviceFeedReportSummaryDay
    {

        private const int SamplesPerDay = 24; // (24 * 60) / 5; // 5 min increments

        public DeviceFeedReportSummaryDay()
        {
            HeaterOn = new int[SamplesPerDay];
            AtTargetTemp = new int[SamplesPerDay];
        }

        
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public int[] HeaterOn { get; set; }

        public int[] AtTargetTemp { get; set; }


    }
}
