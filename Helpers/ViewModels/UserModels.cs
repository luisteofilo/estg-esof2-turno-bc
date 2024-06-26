using System.ComponentModel;

namespace Helpers.ViewModels;

[TypeConverter(typeof(UserConverter))]
public class ResponseUserDto
{
    public Guid UserId { get; set; }
    
    public string Email { get; set; }
    
}

public class UserList
{
    public List<ResponseUserDto> Users { get; set; } = new List<ResponseUserDto>();
}