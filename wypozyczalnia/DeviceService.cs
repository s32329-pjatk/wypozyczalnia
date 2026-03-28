namespace wypozyczalnia;

public class DeviceService
{
    private readonly Dictionary<int, Device> _devices = [];

    public Laptop AddLaptop(string name, string manufacturer, int ramAmount, int diskStorageSize)
    {
        Laptop laptop = new Laptop(name, manufacturer, ramAmount, diskStorageSize);
        _devices.Add(laptop.Id, laptop);
        return laptop;
    }

    public Camera AddCamera(string name, string manufacturer, float zoom, bool isDigital)
    {
        Camera camera = new Camera(name, manufacturer, zoom, isDigital);
        _devices.Add(camera.Id, camera);
        return camera;
    }

    public Projector AddProjector(string name, string manufacturer, int power, float recommendedDistance)
    {
        Projector projector = new Projector(name, manufacturer, power, recommendedDistance);
        _devices.Add(projector.Id, projector);
        return projector;
    }

    public List<Device> GetAllDevices()
    {
        return _devices.Values.ToList();
    }

    public List<Device> GetAvailableDevices()
    {
        return _devices.Values
            .Where(device => device.AvailabilityStatus == AvailabilityStatus.Available)
            .ToList();
    }

    public void SetDeviceAsMaintenance(int deviceId)
    {
        if (!_devices.TryGetValue(deviceId, out Device? device))
        {
            throw new Exception("Device not found");
        }

        device.AvailabilityStatus = AvailabilityStatus.Maintenance;
    }
}
