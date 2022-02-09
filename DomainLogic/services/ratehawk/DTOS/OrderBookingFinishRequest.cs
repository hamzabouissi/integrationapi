namespace DomainLogic.services.ratehawk.DTOS;

public record OrderBookingFinishRequest
{
    public class Partner
    {
        public string partner_order_id { get; set; }
    }

    public class Rooms
    {
        public class RoomsGuest
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
        }
        public List<RoomsGuest> guests { get; set; }
    }

    public class PaymentType
    {
        public string type { get; set; }
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class User
    {
        public string email { get; set; }
        public string phone { get; set; }
    }
    //LanguagesEnum language, object partner, object paymentType, object rooms, object user
    public LanguagesEnum language { get; } = LanguagesEnum.ar;
    public PaymentType payment_type { get; set; }
    public User user { get; set; }
    public List<Rooms> rooms { get; set; }
    public Partner partner { get; set; }
}