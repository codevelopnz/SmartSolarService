using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;
using Codevelop.Shared.Entity;
using Codevelop.Service.Host.App_Start;
using Ninject;
using Codevelop.Service.Interfaces;

namespace Codevelop.Service.Host.Hubs
{
    public class DeviceFeedHub: Hub
    {
        [Inject]
        public IDeviceRepository DeviceRepository { get; set; }

        public void Hello(string message)
        {
            Clients.All.Hello(message);
        }

        public void SendFeedData(DeviceFeed feed)
        {
            Debug.Write("SendFeedData");

            // AC TODO add this back in DeviceRepository.AddDeviceFeed(feed);
            //Clients.Group(feed.DeviceId.ToString()).SendFeedData(feed);
            Clients.All.SendFeedData(feed); //TODO need to only do correct ones.. web client needs to belong to this same group

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