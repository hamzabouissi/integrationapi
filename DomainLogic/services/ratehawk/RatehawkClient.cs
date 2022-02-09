using CSharpFunctionalExtensions;
using DomainLogic.services.ratehawk.DTOS;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;

namespace DomainLogic.services.ratehawk;

public class RatehawkClient: IRatehawkClient
{
    private readonly ILogger<RatehawkClient> _logger;
    private string _regionRequestUrl =  "https://api.worldota.net/api/b2b/v3/{0}";
    private const string RATEHAWK_KEY_ID = "3212";
    private const string RATEHAWK_KEY_TOKEN = "ff9375d7-0198-4e58-873a-548f1d12ff2a";

    public RatehawkClient(ILogger<RatehawkClient> logger)
    {
        _logger = logger;
    }
    public async Task<Result<List<SearchedHotel>>> list_hotels_by_region(SearchHotelByRegionRequest request)
    {
        var url = new Url(String.Format(_regionRequestUrl,"search/serp/region/")).AllowAnyHttpStatus().WithBasicAuth(RATEHAWK_KEY_ID, RATEHAWK_KEY_TOKEN);
        var serializedContent = JsonConverterWithEnumAsString<SearchHotelByRegionRequest>.SerializeWithEnumConverter(request);
        var resp = await url.PostStringAsync(serializedContent).ReceiveJson<SearchHotelByRegionResponse>();;
        if (resp.status != "ok")
        {
            _logger.LogInformation($"list_hotel_by_region get a response:{resp.error}");
            return Result.Failure<List<SearchedHotel>>(resp.error);
        }
        return resp.data.hotels;
    }

    public async Task<Result<SearchedHotel>> get_hotel_availability(SearchHotelByIdRequest request)
    {
        var url = new Url(String.Format(_regionRequestUrl,"search/hp/")).AllowAnyHttpStatus().WithBasicAuth(RATEHAWK_KEY_ID, RATEHAWK_KEY_TOKEN);
        var serializedContent = JsonConverterWithEnumAsString<SearchHotelByIdRequest>.SerializeWithEnumConverter(request);
        var resp = await url.PostStringAsync(serializedContent).ReceiveJson<SearchHotelByRegionResponse>();;
        if (resp.status != "ok")
        {
            _logger.LogInformation($"get_hotel_by_id get a response:{resp.error}");
            return Result.Failure<SearchedHotel>(resp.error);
        }
        return resp.data.hotels.First();
    }

    public List<object> get_orders(LanguagesEnum language, object ordering)
    {
        throw new NotImplementedException();
    }

    public object get_order(LanguagesEnum language, object ordering, string orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<OrderBookingCreateResponseData>> create_order_booking_form(OrderBookingCreate bookingCreateRequest)
    {
        var url = new Url(String.Format(_regionRequestUrl,"hotel/order/booking/form/")).AllowAnyHttpStatus().WithBasicAuth(RATEHAWK_KEY_ID, RATEHAWK_KEY_TOKEN);
        var serializedContent = JsonConverterWithEnumAsString<OrderBookingCreate>.SerializeWithEnumConverter(bookingCreateRequest);
        var resp = await url.PostStringAsync(serializedContent).ReceiveJson<OrderBookingCreateResponse>();;
        if (resp.status != "ok")
        {
            _logger.LogInformation($"get_hotel_by_id get a response:{resp.error}");
            return Result.Failure<OrderBookingCreateResponseData>(resp.error);
        }

        return  Result.Success<OrderBookingCreateResponseData>(resp.data);
    }

    public async Task<Result> finish_order_booking(OrderBookingFinishRequest finishRequest)
    {
        var url = new Url(String.Format(_regionRequestUrl,"hotel/order/booking/finish/")).AllowAnyHttpStatus().WithBasicAuth(RATEHAWK_KEY_ID, RATEHAWK_KEY_TOKEN);
        var serializedContent = JsonConverterWithEnumAsString<OrderBookingFinishRequest>.SerializeWithEnumConverter(finishRequest);
        var resp = await url.PostStringAsync(serializedContent).ReceiveJson<OrderBookingFinishResponse>();
        if (resp.status != "ok")
        {
            _logger.LogInformation($"get_hotel_by_id get a response:{resp.error}");
            return Result.Failure(resp.error);
        }
        return Result.Success();
    }

    public async Task<OrderBookingStatusEnum> check_order_booking_status(CheckOrderStatusRequest orderStatusRequest)
    {
        var url = new Url(String.Format(_regionRequestUrl,"hotel/order/booking/form/")).AllowAnyHttpStatus().WithBasicAuth(RATEHAWK_KEY_ID, RATEHAWK_KEY_TOKEN);
        var serializedContent = JsonConverterWithEnumAsString<CheckOrderStatusRequest>.SerializeWithEnumConverter(orderStatusRequest);
        var resp = await url.PostStringAsync(serializedContent).ReceiveJson<CheckOrderStatusResponse>();
        if (resp.status != "ok")
        {
            _logger.LogInformation($"get_hotel_by_id get a response:{resp.error}");
            return OrderBookingStatusEnum.Processing;
        }
        return OrderBookingStatusEnum.OK;
    }
}