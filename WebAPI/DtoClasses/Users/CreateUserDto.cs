
namespace ESOF.WebApp.WebAPI.Controller.Dto.Users;

public class CreateUserDto
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Address { get; set; }
    
    public string Email { get; set; }

    public DateTime BirthdayDate { get; set; }

    public string Password { get; set; }
}