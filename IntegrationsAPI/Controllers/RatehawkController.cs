using DomainLogic.services.ratehawk;
using DomainLogic.services.ratehawk.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RatehawkController : ControllerBase
{
    private readonly IRatehawkClient _integrationClient;

    public RatehawkController(IRatehawkClient integrationClient)
    {
        _integrationClient = integrationClient;
    }
    
    [HttpPost("hotel_by_region",Name = "GetHotelByRegion")]
    public async Task<ActionResult<SearchHotelByRegionResponse>> GetHotelByRegion(SearchHotelByRegionRequest request)
    {
       
        var resp = await _integrationClient.list_hotels_by_region(request);
        if (resp.IsSuccess)
            return Ok(resp.Value);
        return BadRequest(resp.Error);
    }
    [HttpPost("hotel_by_id",Name = "GetHotelByHotelId")]
    public async Task<ActionResult<SearchedHotel>> GetHotelByHotelId(SearchHotelByIdRequest request)
    {
      
        var resp = await _integrationClient.get_hotel_availability(request);
        if (resp.IsSuccess)
            return Ok(resp.Value);
        return BadRequest(resp.Error);
    }
    [HttpPost("create_order_booking",Name = "CreateOrderBooking")]
    public async Task<ActionResult<OrderBookingCreateResponseData>> CreateOrderBooking(OrderBookingCreate request)
    {
        var resp = await _integrationClient.create_order_booking_form(request);
        if (resp.IsSuccess)
            return Ok(resp.Value);
        return BadRequest(resp.Error);
    }
    [HttpPost("finish_order_booking",Name = "FinsihOrderBooking")]
    public async Task<ActionResult<OrderBookingFinishResponse>> FinsihOrderBooking(OrderBookingFinishRequest request)
    {
        var resp = await _integrationClient.finish_order_booking(request);
        if (resp.IsSuccess)
            return Ok();
        return BadRequest(resp.Error);
    }
}
