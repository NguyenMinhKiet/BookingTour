using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Static;
using System.Globalization;
using System.Text;
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
        Title = "Khám Phá Thành Phố Hồ Chí Minh – Những Điểm Đến Nổi Bật",
        Description = "Khám phá thành phố Hồ Chí Minh với các điểm tham quan nổi bật như Chợ Bến Thành, Nhà Thờ Đức Bà.",
        Price = 1000000,
        StartDate = new DateTime(2024, 11, 10),
        EndDate = new DateTime(2024, 11, 12),
        AvailableSeats = 20,
        Category = "City",
        City = "Hồ Chí Minh",
        Image = "ho-chi-minh.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Vịnh Hạ Long – Kỳ Quan Thiên Nhiên Thế Giới",
        Description = "Tham quan vịnh Hạ Long, kỳ quan thiên nhiên của thế giới với các hang động đẹp như Đầu Gỗ, Sung Sốt.",
        Price = 2000000,
        StartDate = new DateTime(2024, 11, 10),
        EndDate = new DateTime(2024, 11, 11),
        AvailableSeats = 15,
        Category = "Nature",
        City = "Quảng Ninh",
        Image ="vinh-ha-long.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Thành Phố Ngàn Hoa Đà Lạt",
        Description = "Khám phá thành phố ngàn hoa với các điểm đến như Thiền Viện Trúc Lâm, Hồ Xuân Hương.",
        Price = 1500000,
        StartDate = new DateTime(2024, 11, 15),
        EndDate = new DateTime(2024, 11, 17),
        AvailableSeats = 30,
        Category = "Mountain",
        City = "Lâm Đồng",
        Image = "da-lat.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Nha Trang – Thiên Đường Biển Của Việt Nam",
        Description = "Khám phá Nha Trang với các bãi biển đẹp như Bình Ba, Bình Lập, và tham quan Vinpearl Land.",
        Price = 2500000,
        StartDate = new DateTime(2024, 12, 1),
        EndDate = new DateTime(2024, 12, 3),
        AvailableSeats = 25,
        Category = "Beach",
        City = "Khánh Hòa",
        Image = "nha-trang.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Đảo Ngọc Phú Quốc – Thiên Đường Nghỉ Dưỡng",
        Description = "Khám phá đảo ngọc Phú Quốc với các bãi biển tuyệt đẹp và hệ sinh thái phong phú.",
        Price = 3000000,
        StartDate = new DateTime(2024, 12, 5),
        EndDate = new DateTime(2024, 12, 7),
        AvailableSeats = 20,
        Category = "Island",
        City = "Kiên Giang",
        Image = "phu-quoc.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Sapa – Vùng Núi Tây Bắc Hùng Vĩ",
        Description = "Khám phá những thửa ruộng bậc thang và bản làng dân tộc của Sapa.",
        Price = 1800000,
        StartDate = new DateTime(2024, 12, 10),
        EndDate = new DateTime(2024, 12, 12),
        AvailableSeats = 30,
        Category = "Mountain",
        City = "Lào Cai",
        Image = "sa-pa.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Cố Đô Huế – Di Sản Văn Hóa Thế Giới",
        Description = "Tham quan cố đô Huế với các di tích lịch sử như Hoàng Cung, Chùa Thiên Mụ.",
        Price = 1200000,
        StartDate = new DateTime(2024, 12, 15),
        EndDate = new DateTime(2024, 12, 17),
        AvailableSeats = 15,
        Category = "Historical",
        City = "Thừa Thiên Huế",
        Image = "pho-co-hue.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Hà Nội – Thủ Đô Ngàn Năm Văn Hiến",
        Description = "Khám phá thủ đô Hà Nội với các điểm đến như Hồ Hoàn Kiếm, Lăng Bác, và Phố Cổ.",
        Price = 1100000,
        StartDate = new DateTime(2024, 12, 20),
        EndDate = new DateTime(2024, 12, 22),
        AvailableSeats = 40,
        Category = "City",
        City = "Hà Nội",
        Image = "ha-noi.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Côn Đảo – Địa Điểm Lịch Sử Và Thiên Nhiên Hấp Dẫn",
        Description = "Khám phá Côn Đảo, một địa điểm thiên nhiên đẹp và lịch sử thú vị với các di tích nhà tù.",
        Price = 3500000,
        StartDate = new DateTime(2024, 12, 25),
        EndDate = new DateTime(2024, 12, 27),
        AvailableSeats = 18,
        Category = "Historical",
        City = "Bà Rịa Vũng Tàu",
        Image = "con-dao.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Quảng Bình – Động Phong Nha Và Các Kỳ Quan Thiên Nhiên",
        Description = "Tham quan động Phong Nha, động Tiên Sơn và các hang động nổi tiếng khác ở Quảng Bình.",
        Price = 2200000,
        StartDate = new DateTime(2024, 12, 28),
        EndDate = new DateTime(2024, 12, 30),
        AvailableSeats = 20,
        Category = "Adventure",
        City = "Quảng Bình",
        Image = "quang-binh.jpg"
    },
    new Tour
    {
        TourID = Guid.NewGuid(),
        Title = "Khám Phá Cần Thơ – Miền Tây Hồn Quê",
        Description = "Khám phá miền Tây với các chợ nổi và làng quê thanh bình tại Cần Thơ.",
        Price = 1300000,
        StartDate = new DateTime(2024, 12, 30),
        EndDate = new DateTime(2025, 1, 1),
        AvailableSeats = 30,
        Category = "Cultural",
        City = "Cần Thơ",
        Image = "can-tho.jpg"
           } };

            await context.Tours.AddRangeAsync(tours);
            await context.SaveChangesAsync();
        }
    }
}
}

