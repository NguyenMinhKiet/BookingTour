namespace Domain.Entities
{
    public class Hotel
    {
        public Guid HotelID { get; set; }
        public string Name { get; set; }
        public int StarRating {  get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }

        public virtual ICollection<TourHotel> TourHotels { get; set; }

    }
}
