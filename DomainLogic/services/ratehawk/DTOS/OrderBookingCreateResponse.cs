namespace DomainLogic.services.ratehawk.DTOS;

public record OrderBookingCreateResponseData
{
    public class PaymentTypes
    {
        public decimal amount { get; set; }
        public string currency_code { get; set; }
        public string type { get; set; }
    }
    public string item_id { get; set; }
    public string order_id { get; set; }
    public string partner_order_id { get; set; }
    public List<PaymentTypes> payment_types { get; set; }
}

public record OrderBookingCreateResponse:BaseResponse
{
    public OrderBookingCreateResponseData data { get; set; }
}