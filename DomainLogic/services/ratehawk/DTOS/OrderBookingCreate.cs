using System.ComponentModel.DataAnnotations;

namespace DomainLogic.services.ratehawk.DTOS;

public class OrderBookingCreate
{
    [Required]
    public string book_hash { get; set; }
    public LanguagesEnum language { get; set; }
    public string user_ip { get; } = "156.55.12.10";
    public Guid partner_order_id { get; } = Guid.NewGuid();
}