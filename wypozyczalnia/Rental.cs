namespace wypozyczalnia;

public class Rental
{
    public User User { get; set; }
    public Device Device { get; set; }
    public DateTime StartDate { get; set; }
    public DateOnly PlannedReturnedDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    
    public Rental(User user, Device device, DateTime startDate, DateOnly plannedReturnedDate)
    {
        User = user;
        Device = device;
        StartDate = startDate;
        PlannedReturnedDate = plannedReturnedDate;
    }
}