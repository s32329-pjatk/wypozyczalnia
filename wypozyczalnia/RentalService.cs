namespace wypozyczalnia;

public class RentalService
{
    private static int RENTAL_LIMIT_FOR_STUDENT = 2;
    private static int RENTAL_LIMIT_FOR_EMPLOYEE = 5;
    
    private readonly List<Rental> rentals = [];
    private readonly Dictionary<UserType, int> _userTypeToLimit = new();
    private readonly IExtraFeeCalucatorStrategy _extraFeeCalucatorStrategy;
    
    
    public RentalService(IExtraFeeCalucatorStrategy extraFeeCalucatorStrategy)
    {
        _extraFeeCalucatorStrategy = extraFeeCalucatorStrategy;
        _userTypeToLimit.Add(UserType.Student, RENTAL_LIMIT_FOR_STUDENT);
        _userTypeToLimit.Add(UserType.Employee, RENTAL_LIMIT_FOR_EMPLOYEE);
    }
    
    
    public Rental rentDevice(User user, Device device, int duration)
    {
        int activeUserRentals = GetActiveUserRentals(user).Count;
        int limit = _userTypeToLimit[user.UserType];
        if (activeUserRentals >= limit)
        {
            throw new Exception("Limit of rentals exceeded");
        }

        if (device.AvailabilityStatus != AvailabilityStatus.Available)
        {
            throw new Exception("Device is not available");
        }
        
        DateOnly plannedReturnDate = DateOnly.FromDateTime(DateTime.Now).AddDays(duration);
        Rental rental =  new Rental(user, device, DateTime.Now, plannedReturnDate);
        rentals.Add(rental);
        device.AvailabilityStatus = AvailabilityStatus.Unavailable;
        return rental;
    }

    public void ReturnDevice(Rental rental)
    {
        if (rental.ActualReturnDate != null)
        {
            throw new Exception("Rental has already been returned");
        }

        rental.ActualReturnDate = DateTime.Now;
        decimal extraFee = _extraFeeCalucatorStrategy.CalculateExtraFee(rental);
        rental.ExtraFee = extraFee;
        rental.Device.AvailabilityStatus = AvailabilityStatus.Available;
    }

    public List<Rental> GetUsersRentals(User user)
    {
        return rentals.Where(rental => rental.User == user).ToList();
    }
    
    public List<Rental> GetActiveUserRentals(User user)
    {
        return rentals.Where(rental => rental.User == user && rental.ActualReturnDate == null).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return rentals
            .Where(rental => rental.ActualReturnDate == null && rental.IsOverdue())
            .ToList();
    }

    public List<Rental> GetAllRentals()
    {
        return rentals.ToList();
    }
}
