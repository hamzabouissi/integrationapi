namespace DomainLogic.services.ratehawk.DTOS;

public record Guest
{
    public int adults { get; set; }
    public List<int> children { get; set; }
}