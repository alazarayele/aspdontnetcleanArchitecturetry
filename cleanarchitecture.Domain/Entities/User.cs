namespace cleanarchitecture.Domain;

public class User
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string EMail {get;set;}
     public string Password {get;set;}
}