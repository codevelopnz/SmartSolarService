using Codevelop.Service.Interfaces;
using Codevelop.Shared.Entity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Codevelop.Service.Host.Controllers
{
    public class DeviceSummaryController : ApiController
    {
        [Inject]
        public IDeviceRepository DeviceRepository { get; set; }


        public static Random _random = new Random();

        private void SetMockAtTemp(DeviceFeedReportSummaryDay dfrs)
        {
            var start = 14; // 2pm
            var end = 18; //6pm


            for (int i = start; i < end; i++)
            {
                dfrs.AtTargetTemp[i] = _random.Next(60); 
            }
        }


        private void SetMockHeating(DeviceFeedReportSummaryDay dfrs)
        {
            var start = 5 ; // 5am
            var end = 10; // 10am


            for (int i = start; i < end; i++)
            {
                dfrs.HeaterOn[i] = _random.Next(60);
            }

        }

        [Route("api/DeviceSummary/Summary")]
        public List<DeviceFeedReportSummary> GetDeviceDataSummary(Guid deviceId, int year, int month)
        {
            // DeviceRepository.
            // Mock something for the moment 
            var data = new List<DeviceFeedReportSummary>();

            
            var daysInMonth = DateTime.DaysInMonth(year, month);
            for (int i = 1; i < daysInMonth; i++)
            {

                for (int hours = 0; hours < 24; hours++)
                {
                    var item = new DeviceFeedReportSummary { Date = new DateTime(year, month, i), Day = i ,Bucket = hours, HeaterOnMins = _random.Next(60), AtTargetTempMins = _random.Next(60) };
                    data.Add(item);
                }
            }

            return data;


        }


    }
}
