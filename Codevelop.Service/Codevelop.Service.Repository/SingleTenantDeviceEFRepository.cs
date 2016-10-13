using Codevelop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codevelop.Shared.Entity;

namespace Codevelop.Service.Repository
{
    public class SingleTenantDeviceEFRepository : IDeviceRepository
    {
        public void AddDeviceFeed(DeviceFeed deviceFeed)
        {
            using (var db = new CodevelopDBContext())
            {
                db.DeviceFeed.Add(deviceFeed);
                db.SaveChanges();
            }
        }

        public void AddDeviceSettings(DeviceSettings deviceSettings)
        {
            throw new NotImplementedException();
        }
    }
}
