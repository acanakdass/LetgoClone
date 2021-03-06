using Core.Entities.Abstract;

namespace Entity.DTOs.Advert;

public class AdvertAddDto:IDto
{
    public string title { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }
    public int status_id { get; set; }
    public bool is_new { get; set; }
    public bool is_active { get; set; }
    public int category_id { get; set; }
    public bool is_tradable { get; set; }
}