namespace wypozyczalnia;

public class Employee : User
{
    public Employee (String firstName, String lastName) : base(firstName, lastName, UserType.Employee)
    {
    }
}