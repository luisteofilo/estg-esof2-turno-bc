namespace Frontend.Services;

public class UserDto
{
    public Guid UserId { get; set; }
    
    public string Email { get; set; }
    
    public string Address { get; set; }
    
    public DateTime BirthdayDate { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Password { get; set; }
}