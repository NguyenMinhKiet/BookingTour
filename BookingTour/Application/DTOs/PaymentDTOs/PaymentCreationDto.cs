namespace Application.DTOs.PaymentDTOs
{
    public class PaymentCreationDto
    {
        public Guid BookingID { get; set; }
        public string Method { get; set; }
        public bool Status { get; set; }
    }
}
