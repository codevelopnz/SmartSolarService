using Codevelop.Client.Test.Helpers;
using Microsoft.AspNet.SignalR.Client;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
        private int _counter;
        private HubConnection _hubConnection;
        private IHubProxy _hubProxy;
        private bool _connectionStable;

        private readonly CoreDispatcher _dispatcher;


       // private const string connectionString = "HostName=TgaMeetup.azure-devices.net;DeviceId=device88b92e2f1e13454d8df943eed76d60dc;SharedAccessKey=dUTQu+fDUr0F0FBWwjzvRel1JkI+qHo/PJ4hLLw5LGQ=;";
        public MainPage()
        {
            this.InitializeComponent();
            _dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;


            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();

        }

        private async void ConnectToServices()
        {
            await Start();
            //await WaitForConnection();

            // TODO get device MAC address for now a guid will do 
            var deviceId = Guid.NewGuid();

            try
            {
                _hubProxy.Invoke("DeviceConnect", deviceId);
            }
            catch (Exception ex)
            {

                LogMessage("Invoke Failed : "+ ex.Message);
            }
            
        }

        public async Task Start()
        {
            _hubConnection = new HubConnection("http://192.168.1.155/CodevelopService");
            //_hubConnection = new HubConnection(@"http://smartsolar.azurewebsites.net");
            var writer = new DebugTextWriter();
            _hubConnection.TraceLevel = TraceLevels.All;
            _hubConnection.TraceWriter = writer;
            _hubConnection.Error += _hubConnection_Error;
            _hubConnection.StateChanged += _hubConnection_StateChanged;

           
            // set up backchannel
            _hubProxy = _hubConnection.CreateHubProxy("DeviceFeed");
            
            _hubProxy.On<string>("hello", message =>
                LogMessage(message)
            );


            LogMessage("Starting");
            await _hubConnection.Start();
        }


            void _hubConnection_StateChanged(StateChange obj)
        {

            LogMessage(_hubConnection.State.ToString());

            if (_hubConnection.State == ConnectionState.Connected )
            {
                _connectionStable = true;
            }
        }

        public async Task WaitForConnection()
        {
            while (!_connectionStable)
            {
               await Task.Delay(100);
            }
            LogMessage("Connection stable!");
        }

        private void _hubConnection_Error(Exception err)
        {
            LogMessage(err.Message);
        }

        private async void LogMessage(string s)
        {
            await _dispatcher.RunAsync(CoreDispatcherPriority.High, () => serverFeed.Items.Add(s)); //add to listbox
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            

            textBlock.Text = _counter.ToString();
            _counter++;

            try
            {
                if (_hubConnection.State == ConnectionState.Connected)
                    _hubProxy.Invoke("Hello", textBlock.Text);
            }
            catch (Exception ex)
            {

                LogMessage("Invoke Failed : " + ex.Message);
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ConnectToServices();
        }

        
    }
}
