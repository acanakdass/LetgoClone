using Core.Entities.Abstract;

namespace Entity.DTOs.Category;

public class CategoryAddDto:IDto
{
    public string name { get; set; }
}