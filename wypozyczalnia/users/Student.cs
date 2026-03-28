namespace wypozyczalnia;

public class Student : User
{
    public Student (String firstName, String lastName) : base(firstName, lastName, UserType.Student)
    {
    }
}