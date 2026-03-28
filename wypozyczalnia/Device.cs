namespace wypozyczalnia;

public abstract class Device
{
    protected int _id;
    public AvailabilityStatus AvailabilityStatus { get; protected set;}
    public string Name { get; protected set; }
    public string Manufacturer { get; protected set; }
    private static int _idCounter = 0;

    protected Device(AvailabilityStatus availabilityStatus)
    {
        _id = _idCounter++;
        AvailabilityStatus = availabilityStatus;
    }

    public int Id => _id;
}