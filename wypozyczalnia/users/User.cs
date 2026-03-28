namespace wypozyczalnia;

public abstract class User
{
    private int _id;
    public string FirstName{get;set;}
    public string LastName{get;set;}
    public UserType UserType{get;}
    
    protected User (string firstName, string lastName, UserType userType)
    {
        FirstName = firstName;
        LastName = lastName;
        UserType = userType;
    }
}