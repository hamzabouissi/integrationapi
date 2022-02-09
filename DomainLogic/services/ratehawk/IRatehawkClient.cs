using CSharpFunctionalExtensions;
using DomainLogic.services.ratehawk.DTOS;

namespace DomainLogic.services.ratehawk;

public interface IRatehawkClient
{
    public Task<Result<List<SearchedHotel>>> list_hotels_by_region(SearchHotelByRegionRequest request);
    public Task<Result<SearchedHotel>> get_hotel_availability(SearchHotelByIdRequest request);
    public List<object> get_orders(LanguagesEnum language,object ordering);
    public object get_order(LanguagesEnum language, object ordering, string orderId);
    public Task<Result<OrderBookingCreateResponseData>> create_order_booking_form(
        OrderBookingCreate bookingCreateRequest);
    public Task<Result> finish_order_booking(OrderBookingFinishRequest finishRequest);
    public Task<OrderBookingStatusEnum> check_order_booking_status(CheckOrderStatusRequest orderStatusRequest);
}
