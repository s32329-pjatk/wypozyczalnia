namespace wypozyczalnia;

public class ReportService
{
    private readonly UserService _userService;
    private readonly DeviceService _deviceService;
    private readonly RentalService _rentalService;

    public ReportService(UserService userService, DeviceService deviceService, RentalService rentalService)
    {
        _userService = userService;
        _deviceService = deviceService;
        _rentalService = rentalService;
    }

    public string GenerateReport()
    {
        List<User> users = _userService.GetAllUsers();
        List<Device> devices = _deviceService.GetAllDevices();
        List<Rental> rentals = _rentalService.GetAllRentals();
        List<Rental> overdueRentals = _rentalService.GetOverdueRentals();
        
        int studentsCount = users.Count(user => user.UserType == UserType.Student);
        int employeesCount = users.Count(user => user.UserType == UserType.Employee);
        int availableDevicesCount = devices.Count(device => device.AvailabilityStatus == AvailabilityStatus.Available);
        int unavailableDevicesCount = devices.Count(device => device.AvailabilityStatus == AvailabilityStatus.Unavailable);
        int maintenanceDevicesCount = devices.Count(device => device.AvailabilityStatus == AvailabilityStatus.Maintenance);
        int activeRentalsCount = rentals.Count(rental => rental.ActualReturnDate == null);

        return string.Join(Environment.NewLine,
        [
            "Rental summary report",
            $"Total users: {users.Count}",
            $"Students: {studentsCount}",
            $"Employees: {employeesCount}",
            $"Total devices: {devices.Count}",
            $"Available devices: {availableDevicesCount}",
            $"Unavailable devices: {unavailableDevicesCount}",
            $"Maintenance devices: {maintenanceDevicesCount}",
            $"Total rentals: {rentals.Count}",
            $"Active rentals: {activeRentalsCount}",
            $"Overdue rentals: {overdueRentals.Count}"
        ]);
    }
}
