using Codevelop.Shared.Entity;

namespace Codevelop.Service.Interfaces
{
    /// <summary>
    /// Storage of device related streams
    /// </summary>
    public interface IDeviceRepository
    {
        void AddDeviceFeed(DeviceFeed deviceFeed);

        void AddDeviceSettings(DeviceSettings deviceSettings);
    }
}
