namespace wypozyczalnia;

public class Laptop : Device
{
    public int RamAmount { get; set; }
    public int DiskStorageSize { get; set; }
    
    public Laptop(AvailabilityStatus availabilityStatus) : base(availabilityStatus)
    {
    }
}