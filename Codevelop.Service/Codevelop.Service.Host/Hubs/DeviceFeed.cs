using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Codevelop.Service.Host.Hubs
{
    public class DeviceFeed: Hub
    {
        public void Hello(string message)
        {
            Clients.All.Hello(message);
        }

        public override Task OnConnected()
        {
            Debug.Write("PiHub connection from {0}", Context.ConnectionId);
            return base.OnConnected();
        }

        public  void DeviceConnect(Guid clientId)
        {
            Groups.Add(Context.ConnectionId, clientId.ToString());

            Hello("Hello : " + clientId.ToString());
        }
    }
}