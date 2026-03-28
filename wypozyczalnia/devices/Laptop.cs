namespace wypozyczalnia;

public class Laptop : Device
{
    public Laptop(string name, string manufacturer, int ramAmount, int diskStorageSize) : base(name, manufacturer)
    {
        RamAmount = ramAmount;
        DiskStorageSize = diskStorageSize;
    }

    public int RamAmount { get; set; }
    public int DiskStorageSize { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()} - RAM: {RamAmount} GB, storage: {DiskStorageSize} GB";
    }
}
