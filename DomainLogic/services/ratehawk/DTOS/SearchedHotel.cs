namespace DomainLogic.services.ratehawk;

public record SearchedHotel
{
    public string Id { get; set; }
    public List<Rates> rates { get; set; }
    
}
public record Rates
{
    public int allotment { get; set; }
    public string match_hash { get; set; }
    public List<string> daily_prices { get; set; }
    public string meal { get; set; }
    public string room_name { get; set; }
    public List<string> amenities_data  { get; set; }
    public string? book_hash { get; set; }
}