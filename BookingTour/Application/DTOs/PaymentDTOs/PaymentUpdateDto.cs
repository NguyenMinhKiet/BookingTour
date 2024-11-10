namespace Application.DTOs.PaymentDTOs
{
    public class PaymentUpdateDto
    {
        public DateTime ModifyAt { get; set; }
        public string Method { get; set; }
        public bool Status { get; set; }
    }
}
