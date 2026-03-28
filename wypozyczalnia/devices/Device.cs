namespace wypozyczalnia;

public abstract class Device
{
    protected int _id;
    public AvailabilityStatus AvailabilityStatus { get; protected set;}
    public string Name { get; protected set; }
    public string Manufacturer { get; protected set; }
    private static int _idCounter = 0;

    protected Device(String name, String manufacturer)
    {
        _id = _idCounter++;
        AvailabilityStatus = AvailabilityStatus.Available;
        Name = name;
        Manufacturer = manufacturer;
    }

    public int Id => _id;
}