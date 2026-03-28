namespace wypozyczalnia;

public abstract class User
{
    private int _id;
    public string FirstName{get;set;}
    public string LastName{get;set;}
    public UserType UserType{get;}
    
    private static int _idCounter = 0;
    
    protected User (string firstName, string lastName, UserType userType)
    {
        _id = _idCounter++;
        FirstName = firstName;
        LastName = lastName;
        UserType = userType;
    }

    public int Id => _id;

    public override string ToString()
    {
        return $"{Id} {FirstName} {LastName} ({UserType})";
    }
}
