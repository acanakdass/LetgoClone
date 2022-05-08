using Core.Entities.Abstract;

namespace Entity.DTOs.Category;
public class CategoryGetDto:IDto
{
    public int id { get; set; }
    public string name { get; set; }
}