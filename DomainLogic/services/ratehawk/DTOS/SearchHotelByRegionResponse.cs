using DomainLogic.services.ratehawk.DTOS;

namespace DomainLogic.services.ratehawk;

public record SearchHotelByRegionResponse: BaseResponse
{
    public SearchHotelByRegionResponseData data { get; set; }
 
}

public record SearchHotelByRegionResponseData
{
    public List<SearchedHotel> hotels { get; set; }
    public int total_hotels { get; set; }
}