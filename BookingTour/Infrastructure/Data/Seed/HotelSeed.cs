
using Domain.Entities;

namespace Infrastructure.Data.Seed
{
    public class HotelSeed
    {
        public static async Task SeedHotelsAsync(ApplicationDbContext context)
        {
            // Kiểm tra xem bảng Destination đã có dữ liệu chưa
            if (!context.Hotels.Any())
            {
                var hotels = new List<Hotel>
{
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "The Reverie Saigon",
        StarRating = 5,
        Description = "Khách sạn sang trọng bậc nhất tại trung tâm TP.HCM.",
        Image = "reverie_saigon.jpg",
        Address = "22-36 Nguyễn Huệ, Bến Nghé",
        City = "Hồ Chí Minh",
        District = "Quận 1",
        Ward = "Bến Nghé"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Vinpearl Resort & Spa Hạ Long",
        StarRating = 5,
        Description = "Khách sạn cao cấp với tầm nhìn toàn cảnh vịnh Hạ Long.",
        Image = "vinpearl_ha_long.jpg",
        Address = "Đảo Rều, Bãi Cháy",
        City = "Quảng Ninh",
        District = "Hạ Long",
        Ward = "Bãi Cháy"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Dalat Palace Heritage Hotel",
        StarRating = 5,
        Description = "Khách sạn cổ điển mang phong cách châu Âu tại Đà Lạt.",
        Image = "dalat_palace.jpg",
        Address = "12 Trần Phú",
        City = "Lâm Đồng",
        District = "Đà Lạt",
        Ward = "Phường 3"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "InterContinental Nha Trang",
        StarRating = 5,
        Description = "Khách sạn hiện đại nằm sát bờ biển Nha Trang.",
        Image = "intercontinental_nha_trang.jpg",
        Address = "32-34 Trần Phú",
        City = "Khánh Hòa",
        District = "Nha Trang",
        Ward = "Lộc Thọ"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Salinda Resort Phú Quốc Island",
        StarRating = 5,
        Description = "Khu nghỉ dưỡng ven biển sang trọng trên đảo Phú Quốc.",
        Image = "salinda_resort.jpg",
        Address = "Cửa Lấp, Dương Tơ",
        City = "Kiên Giang",
        District = "Phú Quốc",
        Ward = "Dương Tơ"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Hanoi Daewoo Hotel",
        StarRating = 5,
        Description = "Khách sạn cao cấp với phong cách phục vụ chuyên nghiệp tại Hà Nội.",
        Image = "hanoi_daewoo.jpg",
        Address = "360 Kim Mã, Ngọc Khánh",
        City = "Hà Nội",
        District = "Ba Đình",
        Ward = "Ngọc Khánh"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Victoria Can Tho Resort",
        StarRating = 4,
        Description = "Khu nghỉ dưỡng thanh bình bên dòng sông Hậu.",
        Image = "victoria_can_tho.jpg",
        Address = "Cái Khế, Ninh Kiều",
        City = "Cần Thơ",
        District = "Ninh Kiều",
        Ward = "Cái Khế"
    },

    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "InterContinental Hanoi Westlake",
        StarRating = 5,
        Description = "Khách sạn sang trọng với view Hồ Tây tuyệt đẹp tại Hà Nội.",
        Image = "intercontinental_hanoi.jpg",
        Address = "5 Từ Hoa, Quảng An",
        City = "Hà Nội",
        District = "Tây Hồ",
        Ward = "Quảng An"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Sheraton Phu Quoc Resort",
        StarRating = 5,
        Description = "Khu nghỉ dưỡng cao cấp nằm trên bãi biển đẹp ở Phú Quốc.",
        Image = "sheraton_phuquoc.jpg",
        Address = "Cửa Lấp, Dương Tơ",
        City = "Kiên Giang",
        District = "Phú Quốc",
        Ward = "Dương Tơ"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Sapa Highland Resort & Spa",
        StarRating = 4,
        Description = "Khách sạn với khung cảnh núi rừng hùng vĩ tại Sapa.",
        Image = "sapa_highland.jpg",
        Address = "Vườn Quốc Gia Hoàng Liên",
        City = "Lào Cai",
        District = "Sapa",
        Ward = "Sapa"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Mövenpick Resort Cam Ranh",
        StarRating = 5,
        Description = "Khu nghỉ dưỡng sang trọng tại Bãi Dài, Cam Ranh.",
        Image = "moevenpick_cam_ranh.jpg",
        Address = "Bãi Dài, Cam Ranh",
        City = "Khánh Hòa",
        District = "Cam Ranh",
        Ward = "Cam Nghĩa"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Park Hyatt Saigon",
        StarRating = 5,
        Description = "Khách sạn sang trọng tọa lạc tại trung tâm Sài Gòn.",
        Image = "park_hyatt_sg.jpg",
        Address = "2 Công Trường Lam Sơn",
        City = "Hồ Chí Minh",
        District = "Quận 1",
        Ward = "Bến Nghé"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Novotel Phu Quoc Resort",
        StarRating = 4,
        Description = "Khu nghỉ dưỡng cao cấp với bãi biển tuyệt đẹp ở Phú Quốc.",
        Image = "novotel_phuquoc.jpg",
        Address = "Bãi Trường, Dương Tơ",
        City = "Kiên Giang",
        District = "Phú Quốc",
        Ward = "Dương Tơ"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Vinpearl Resort Nha Trang",
        StarRating = 5,
        Description = "Resort cao cấp ngay tại bãi biển Nha Trang.",
        Image = "vinpearl_nha_trang.jpg",
        Address = "Hon Tre Island",
        City = "Khánh Hòa",
        District = "Nha Trang",
        Ward = "Vĩnh Nguyên"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "JW Marriott Hotel Hanoi",
        StarRating = 5,
        Description = "Khách sạn đẳng cấp quốc tế tại Hà Nội, gần các địa điểm du lịch nổi tiếng.",
        Image = "jw_marriott_hanoi.jpg",
        Address = "8 Do Duc Duc, My Dinh",
        City = "Hà Nội",
        District = "Nam Từ Liêm",
        Ward = "Mỹ Đình 1"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "Sunrise Premium Resort Hoi An",
        StarRating = 5,
        Description = "Resort sang trọng với view biển tuyệt đẹp tại Hội An.",
        Image = "sunrise_resort_hoian.jpg",
        Address = "Dai Loc, Cua Dai Beach",
        City = "Quảng Nam",
        District = "Hội An",
        Ward = "Cửa Đại"
    },
    new Hotel
    {
        HotelID = Guid.NewGuid(),
        Name = "The Grand Ho Tram Strip",
        StarRating = 5,
        Description = "Khu nghỉ dưỡng ven biển nổi tiếng tại Vũng Tàu.",
        Image = "grand_ho_tram.jpg",
        Address = "Phước Thuận, Xuyên Mộc",
        City = "Bà Rịa Vũng Tàu",
        District = "Xuyên Mộc",
        Ward = "Phước Thuận"
    }
};
                await context.Hotels.AddRangeAsync(hotels);
                await context.SaveChangesAsync();
            }
        }
    }
}
