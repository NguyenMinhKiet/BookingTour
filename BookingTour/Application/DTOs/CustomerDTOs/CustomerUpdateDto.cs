namespace Application.DTOs.CustomerDTOs
{
    public class CustomerUpdateDto
    {
        public int customer_id { get;set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
}
