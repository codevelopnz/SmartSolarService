using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevelop.Service.Entities
{
    public class Device
    {

        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedDate{ get; set; }

        public DateTimeOffset LastServerContact { get; set; }

        public string FirmwareVersion { get; set; }
    }
}
