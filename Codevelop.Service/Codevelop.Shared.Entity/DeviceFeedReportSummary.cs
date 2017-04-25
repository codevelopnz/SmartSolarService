using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codevelop.Shared.Entity
{
    
    public class DeviceFeedReportSummary
    {
        public DeviceFeedReportSummary()
        {
            //MonthSummary = new List<DeviceFeedReportSummaryDay>();
        }
       
        public Guid DeviceId{ get; set; }
        public string DeviceName { get; set; }

        public int Day { get; set; }// just makes it easier
        public DateTime Date { get; set; }

        public int Bucket { get; set; } // currently hours 0 -23

        public int HeaterOnMins { get; set; }
        public int AtTargetTempMins { get; set; }

        //public int Year { get; set; }
        //public int Month { get; set; }
        //public int Day { get; set; }
        //public List<DeviceFeedReportSummaryDay> MonthSummary { get; set; }


    }
}
