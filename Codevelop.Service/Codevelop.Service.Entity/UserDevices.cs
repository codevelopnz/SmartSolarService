using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevelop.Service.Entities
{
    public class UserDevices
    {
        public Guid UserId { get; set; }

        public Guid DeviceId { get; set; }
    }
}
