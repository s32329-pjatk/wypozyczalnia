using wypozyczalnia;

UserService userService = new UserService();
DeviceService deviceService = new DeviceService();
RentalService rentalService = new RentalService(new FlatRatePerDayFeeCalculatorStrategy());
ReportService reportService = new ReportService(userService, deviceService, rentalService);

Console.WriteLine("11. Dodanie kilku egzemplarzy sprzętu różnych typów.");
Laptop laptopDell = deviceService.AddLaptop("Latitude", "Dell", 16, 512);
deviceService.AddLaptop("ThinkPad T14s", "Lenovo", 64, 2048);
Camera cameraSony = deviceService.AddCamera("Alpha", "Sony", 5.0f, true);
deviceService.AddProjector("projektor", "Epson", 3600, 2.0f);

Console.WriteLine();
Console.WriteLine("### Cały sprzęt");
foreach (Device device in deviceService.GetAllDevices().OrderBy(device => device.Id))
{
    Console.WriteLine(device);
}

Console.WriteLine();
Console.WriteLine("12. Dodanie kilku użytkowników różnych typów.");


Student studentAnna = userService.AddStudent("Anna", "N");
userService.AddStudent("Jan", "Kowalski");
Employee employeeMaria = userService.AddEmployee("Pracownik", "Pilny");

Console.WriteLine();
Console.WriteLine("### Użytkownicy");
foreach (User user in userService.GetAllUsers().OrderBy(user => user.Id))
{
    Console.WriteLine(user);
}

Console.WriteLine();
Console.WriteLine("13. Poprawne wypożyczenie sprzętu.");
Rental annaRental = rentalService.rentDevice(studentAnna, laptopDell, 7);

Console.WriteLine();
Console.WriteLine("14. Próbę wykonania niepoprawnej operacji, np. wypożyczenia sprzętu niedostępnego albo przekroczenia limitu.");
Console.WriteLine();
Console.WriteLine("### Wypozyczenia uzytkownika przed niepoprawna operacja");
foreach (Rental rental in rentalService.GetActiveUserRentals(studentAnna))
{
    Console.WriteLine(rental);
}
try
{
    rentalService.rentDevice(employeeMaria, laptopDell, 3);
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}

Console.WriteLine();
Console.WriteLine("### Wypozyczenia po poprawnej operacji");
foreach (Rental rental in rentalService.GetActiveUserRentals(studentAnna))
{
    Console.WriteLine(rental);
}

Console.WriteLine();
Console.WriteLine("15. Zwrot sprzętu w terminie.");
rentalService.ReturnDevice(annaRental);

Console.WriteLine();
Console.WriteLine("16. Zwrot opóźniony skutkujący naliczeniem kary.");
Rental lateRental = rentalService.rentDevice(employeeMaria, cameraSony, 1);
lateRental.PlannedReturnedDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-2);

Console.WriteLine();
Console.WriteLine("### Przeterminowane wypożyczenia przed zwrotem");
foreach (Rental rental in rentalService.GetOverdueRentals())
{
    Console.WriteLine(rental);
}

rentalService.ReturnDevice(lateRental);
Console.WriteLine($"Zwrócono urządzenie {lateRental.Device.Name}. Dodatkowa opłata: {lateRental.ExtraFee}");

Console.WriteLine();
Console.WriteLine("Stan sprzętu po zwrotach");
foreach (Device device in deviceService.GetAllDevices())
{
    Console.WriteLine(device);
}

Console.WriteLine();
Console.WriteLine("17. Wyświetlenie raportu końcowego o stanie systemu.");
Console.WriteLine(reportService.GenerateReport());
