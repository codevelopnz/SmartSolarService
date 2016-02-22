using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Codevelop.Client.Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private const string connectionString = "HostName=TgaMeetup.azure-devices.net;DeviceId=device88b92e2f1e13454d8df943eed76d60dc;SharedAccessKey=dUTQu+fDUr0F0FBWwjzvRel1JkI+qHo/PJ4hLLw5LGQ=;";
        public MainPage()
        {
            this.InitializeComponent();

            ReceiveDataFromAzure();


            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Http1);

            var text = "Hellow, Windows 10!";
            var msg = new Message(Encoding.UTF8.GetBytes(text));

            //await deviceClient.SendEventAsync(msg);
            deviceClient.SendEventAsync(msg);
        }


        public async static Task ReceiveDataFromAzure()
        {
            DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Http1);

            Message receivedMessage;
            string messageData;

            while (true)
            {
                receivedMessage = await deviceClient.ReceiveAsync();

                if (receivedMessage != null)
                {
                    messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                    await deviceClient.CompleteAsync(receivedMessage);
                }
            }
        }
    }
}
