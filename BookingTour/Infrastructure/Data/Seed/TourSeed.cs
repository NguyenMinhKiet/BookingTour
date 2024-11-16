using Domain.Entities;
using Infrastructure.Data;
namespace Infrastructure.Data.Seed
{


public class TourSeed
{
    public static async Task SeedToursAsync(ApplicationDbContext context)
    {
        // Kiểm tra xem bảng Tours đã có dữ liệu chưa
        if (!context.Tours.Any())
        {
            var tours = new List<Tour>
            {
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Hồ Chí Minh",
                    Description = "Khám phá thành phố Hồ Chí Minh với các điểm tham quan nổi bật như Chợ Bến Thành, Nhà Thờ Đức Bà.",
                    Price = 1000000,
                    StartDate = new DateTime(2024, 11, 10),
                    EndDate = new DateTime(2024, 11, 12),
                    AvailableSeats = 20,
                    Category = "City Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Hạ Long",
                    Description = "Tham quan vịnh Hạ Long, kỳ quan thiên nhiên của thế giới với các hang động đẹp như Đầu Gỗ, Sung Sốt.",
                    Price = 2000000,
                    StartDate = new DateTime(2024, 11, 10),
                    EndDate = new DateTime(2024, 11, 11),
                    AvailableSeats = 15,
                    Category = "Nature Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Đà Lạt",
                    Description = "Khám phá thành phố ngàn hoa với các điểm đến như Thiền Viện Trúc Lâm, Hồ Xuân Hương.",
                    Price = 1500000,
                    StartDate = new DateTime(2024, 11, 15),
                    EndDate = new DateTime(2024, 11, 17),
                    AvailableSeats = 30,
                    Category = "Mountain Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Nha Trang",
                    Description = "Khám phá Nha Trang với các bãi biển đẹp như Bình Ba, Bình Lập, và tham quan Vinpearl Land.",
                    Price = 2500000,
                    StartDate = new DateTime(2024, 12, 1),
                    EndDate = new DateTime(2024, 12, 3),
                    AvailableSeats = 25,
                    Category = "Beach Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Phú Quốc",
                    Description = "Khám phá đảo ngọc Phú Quốc với các bãi biển tuyệt đẹp và hệ sinh thái phong phú.",
                    Price = 3000000,
                    StartDate = new DateTime(2024, 12, 5),
                    EndDate = new DateTime(2024, 12, 7),
                    AvailableSeats = 20,
                    Category = "Island Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Sapa",
                    Description = "Khám phá những thửa ruộng bậc thang và bản làng dân tộc của Sapa.",
                    Price = 1800000,
                    StartDate = new DateTime(2024, 12, 10),
                    EndDate = new DateTime(2024, 12, 12),
                    AvailableSeats = 30,
                    Category = "Mountain Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Huế",
                    Description = "Tham quan cố đô Huế với các di tích lịch sử như Hoàng Cung, Chùa Thiên Mụ.",
                    Price = 1200000,
                    StartDate = new DateTime(2024, 12, 15),
                    EndDate = new DateTime(2024, 12, 17),
                    AvailableSeats = 15,
                    Category = "Historical Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Hà Nội",
                    Description = "Khám phá thủ đô Hà Nội với các điểm đến như Hồ Hoàn Kiếm, Lăng Bác, và Phố Cổ.",
                    Price = 1100000,
                    StartDate = new DateTime(2024, 12, 20),
                    EndDate = new DateTime(2024, 12, 22),
                    AvailableSeats = 40,
                    Category = "City Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Côn Đảo",
                    Description = "Khám phá Côn Đảo, một địa điểm thiên nhiên đẹp và lịch sử thú vị với các di tích nhà tù.",
                    Price = 3500000,
                    StartDate = new DateTime(2024, 12, 25),
                    EndDate = new DateTime(2024, 12, 27),
                    AvailableSeats = 18,
                    Category = "Historical Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Quảng Bình",
                    Description = "Tham quan động Phong Nha, động Tiên Sơn và các hang động nổi tiếng khác ở Quảng Bình.",
                    Price = 2200000,
                    StartDate = new DateTime(2024, 12, 28),
                    EndDate = new DateTime(2024, 12, 30),
                    AvailableSeats = 20,
                    Category = "Adventure Tour"
                },
                new Tour
                {
                    TourID = Guid.NewGuid(),
                    Title = "Tour Cần Thơ",
                    Description = "Khám phá miền Tây với các chợ nổi và làng quê thanh bình tại Cần Thơ.",
                    Price = 1300000,
                    StartDate = new DateTime(2024, 12, 30),
                    EndDate = new DateTime(2025, 1, 1),
                    AvailableSeats = 30,
                    Category = "Cultural Tour"
                }
            };

            await context.Tours.AddRangeAsync(tours);
            await context.SaveChangesAsync();
        }
    }
}
}