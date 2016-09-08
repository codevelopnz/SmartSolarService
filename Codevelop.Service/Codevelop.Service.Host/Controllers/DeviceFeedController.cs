using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Codevelop.Service.Host.Controllers
{
    public class DeviceFeedController : ApiController
    {
        [Route("api/deviceFeed")]
        
        public IEnumerable<string> Get()
        {

            var x = ClaimsPrincipal.Current.Claims;
            var y = User.Identity.IsAuthenticated;
            var layers = new List<string>();
            return layers;
        }


    }
}
