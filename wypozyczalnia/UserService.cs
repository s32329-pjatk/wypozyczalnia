namespace wypozyczalnia;

public class UserService
{
    private readonly LinkedList<User> _users = [];

    public Employee AddEmployee(string firstName, string lastName)
    {
        Employee employee = new Employee(firstName, lastName);
        _users.AddLast(employee);
        return employee;
    }
    
    public Student AddStudent(string firstName, string lastName)
    {
        Student student = new Student(firstName, lastName);
        _users.AddLast(student);
        return student;
    }

    public List<User> GetAllUsers()
    {
        return _users.ToList();
    }
}
