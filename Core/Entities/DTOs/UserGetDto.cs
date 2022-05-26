namespace Core.Entities.DTOs;

public class UserGetDto
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public int address_id { get; set; }
}