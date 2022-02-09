namespace DomainLogic.services.ratehawk.DTOS;

public class SearchHotelByIdRequest
{
    public string id { get; set; }
    public string checkin { get; set; }
    public string checkout { get; set; }
    public LanguagesEnum language { get; set; }
    public List<Guest> guests { get; set; }
}