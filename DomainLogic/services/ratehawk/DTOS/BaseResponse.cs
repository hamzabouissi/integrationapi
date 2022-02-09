namespace DomainLogic.services.ratehawk.DTOS;

public  abstract record BaseResponse
{
    
    public string status { get; set; }
    public string error { get; set; }
}