namespace wypozyczalnia;

public class Rental
{
    public User User { get; set; }
    public Device Device { get; set; }
    public DateTime StartDate { get; set; }
    public DateOnly PlannedReturnedDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public decimal ExtraFee { get; set; }
    
    public Rental(User user, Device device, DateTime startDate, DateOnly plannedReturnedDate)
    {
        User = user;
        Device = device;
        StartDate = startDate;
        PlannedReturnedDate = plannedReturnedDate;
    }

    public bool IsOverdue()
    {
        DateOnly dayToCheck;
        if (ActualReturnDate != null) dayToCheck = DateOnly.FromDateTime((DateTime)ActualReturnDate);
        else dayToCheck = DateOnly.FromDateTime(DateTime.Now);
        return dayToCheck > PlannedReturnedDate;
    }
}