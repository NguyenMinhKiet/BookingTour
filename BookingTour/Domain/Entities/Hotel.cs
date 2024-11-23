namespace Domain.Entities
{
    public class Hotel
    {
        public Guid HotelID { get; set; }
        public string Name { get; set; }
        public int Star {  get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public virtual ICollection<TourHotel> TourHotels { get; set; }

    }
}
