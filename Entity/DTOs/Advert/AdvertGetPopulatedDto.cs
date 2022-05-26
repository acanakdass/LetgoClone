using Core.Entities.Abstract;
using Core.Entities.DTOs;

namespace Entity.DTOs.Advert;

public class AdvertGetPopulatedDto:IDto
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public UserGetDto User { get; set; }
    public decimal price { get; set; }
    public Status Status { get; set; }
    public bool is_new { get; set; }
    public bool is_active { get; set; }
    public bool is_sold { get; set; }
    public Entity.Category Category { get; set; }
    public bool is_tradable { get; set; }
    public DateTime created_date { get; set; }
}