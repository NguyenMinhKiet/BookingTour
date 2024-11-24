using Domain.Entities;
using Infrastructure.Static;

namespace Infrastructure.Data.Seed
{
    public class DestinationSeed
    {
        public static async Task SeedDestinationsAsync(ApplicationDbContext context)
        {
            // Kiểm tra xem bảng Destination đã có dữ liệu chưa
            if (!context.Destinations.Any())
            {
                var destinations = new List<Destination>
            {

new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Fansipan",
            Description = "Nóc nhà Đông Dương, ngọn núi cao nhất Việt Nam.",
            Country = "Việt Nam",
            Category = "Mountain",
            Address = "Thị trấn Sa Pa",
            City = "Lào Cai",
            District = "Sa Pa",
            Ward = "Trung tâm"
        },
        new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Bãi biển Mỹ Khê",
            Description = "Một trong những bãi biển đẹp nhất hành tinh.",
            Country = "Việt Nam",
            Category = "Beach",
            Address = "Đường Võ Nguyên Giáp",
            City = "Đà Nẵng",
            District = "Sơn Trà",
            Ward = "Phước Mỹ"
        },
        new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Hoàng thành Thăng Long",
            Description = "Di sản văn hóa thế giới với lịch sử lâu đời.",
            Country = "Việt Nam",
            Category = "Cultural",
            Address = "Quán Thánh",
            City = "Hà Nội",
            District = "Ba Đình",
            Ward = "Điện Biên"
        },
        new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Địa đạo Củ Chi",
            Description = "Di tích lịch sử nổi tiếng thời kháng chiến.",
            Country = "Việt Nam",
            Category = "Historical",
            Address = "Ấp Phú Hiệp",
            City = "Hồ Chí Minh",
            District = "Củ Chi",
            Ward = "Phú Mỹ Hưng"
        },
        new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Vườn quốc gia Cúc Phương",
            Description = "Khu bảo tồn thiên nhiên nổi tiếng với đa dạng sinh học.",
            Country = "Việt Nam",
            Category = "EcoTourism",
            Address = "Xã Cúc Phương",
            City = "Ninh Bình",
            District = "Nho Quan",
            Ward = "Cúc Phương"
        },
        new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Hang Sơn Đoòng",
            Description = "Hang động lớn nhất thế giới, điểm đến mạo hiểm.",
            Country = "Việt Nam",
            Category = "Adventure",
            Address = "Xã Sơn Trạch",
            City = "Quảng Bình",
            District = "Bố Trạch",
            Ward = "Sơn Trạch"
        },
        new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Hồ Gươm",
            Description = "Trái tim của thủ đô Hà Nội, nổi bật với nét cổ kính.",
            Country = "Việt Nam",
            Category = "CityTour",
            Address = "Hàng Trống",
            City = "Hà Nội",
            District = "Hoàn Kiếm",
            Ward = "Tràng Tiền"
        },
        new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Lễ hội Đền Hùng",
            Description = "Lễ hội văn hóa tưởng nhớ các Vua Hùng.",
            Country = "Việt Nam",
            Category = "Festival",
            Address = "Xã Hy Cương",
            City = "Phú Thọ",
            District = "Việt Trì",
            Ward = "Hy Cương"
        },
        new Destination
        {
            DestinationID = Guid.NewGuid(),
            Name = "Vịnh Lan Hạ",
            Description = "Điểm du thuyền lý tưởng với vẻ đẹp yên bình.",
            Country = "Việt Nam",
            Category = "Cruise",
            Address = "Cát Bà",
            City = "Hải Phòng",
            District = "Cát Hải",
            Ward = "Cát Bà"
        }
            };

                await context.Destinations.AddRangeAsync(destinations);
                await context.SaveChangesAsync();
            }
        }
    }

}
