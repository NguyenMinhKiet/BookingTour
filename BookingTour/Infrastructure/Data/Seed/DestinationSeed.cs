using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Name = "Chợ Bến Thành",
                    Description = "Một trong những điểm đến nổi tiếng của thành phố Hồ Chí Minh, nơi bạn có thể tìm thấy các sản phẩm thủ công mỹ nghệ, thực phẩm, và đặc sản địa phương.",
                    Country = "Vietnam",
                    Category = "Market",
                    City = "Ho Chi Minh City"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Nhà Thờ Đức Bà",
                    Description = "Một biểu tượng của thành phố Hồ Chí Minh, nhà thờ có kiến trúc tuyệt đẹp và nằm ngay trung tâm thành phố.",
                    Country = "Vietnam",
                    Category = "Historical",
                    City = "Ho Chi Minh City"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Vịnh Hạ Long",
                    Description = "Kỳ quan thiên nhiên thế giới, nổi tiếng với các đảo đá vôi tuyệt đẹp và là một trong những điểm du lịch không thể bỏ qua tại Quảng Ninh.",
                    Country = "Vietnam",
                    Category = "Nature",
                    City = "Quảng Ninh"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Động Đầu Gỗ",
                    Description = "Một trong những động đẹp nhất của vịnh Hạ Long với những nhũ đá tự nhiên tuyệt vời.",
                    Country = "Vietnam",
                    Category = "Nature",
                    City = "Quảng Ninh"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Thiền Viện Trúc Lâm",
                    Description = "Nằm ở Đà Lạt, thiền viện Trúc Lâm là một điểm du lịch tâm linh nổi tiếng với khung cảnh thanh bình và không khí trong lành.",
                    Country = "Vietnam",
                    Category = "Spiritual",
                    City = "Đà Lạt"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Hồ Xuân Hương",
                    Description = "Một hồ nước lớn và xinh đẹp tại Đà Lạt, nổi tiếng với không gian thư giãn và cảnh quan thiên nhiên tuyệt vời.",
                    Country = "Vietnam",
                    Category = "Nature",
                    City = "Đà Lạt"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Bãi biển Bình Ba",
                    Description = "Một bãi biển đẹp nằm ở Nha Trang, với làn nước trong vắt và những bãi cát trắng mịn.",
                    Country = "Vietnam",
                    Category = "Beach",
                    City = "Nha Trang"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Vinpearl Land Nha Trang",
                    Description = "Một khu vui chơi giải trí lớn tại Nha Trang, với các hoạt động giải trí đa dạng cho cả gia đình.",
                    Country = "Vietnam",
                    Category = "Entertainment",
                    City = "Nha Trang"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Hòn Thơm",
                    Description = "Một hòn đảo tuyệt đẹp thuộc Phú Quốc, nổi tiếng với các bãi biển hoang sơ và cảnh quan thiên nhiên chưa bị khai thác.",
                    Country = "Vietnam",
                    Category = "Island",
                    City = "Phú Quốc"
                },
                new Destination
                {
                    DestinationID = Guid.NewGuid(),
                    Name = "Chùa Thiên Mụ",
                    Description = "Một trong những ngôi chùa cổ kính nhất tại Huế, nổi tiếng với kiến trúc đặc trưng và vai trò quan trọng trong lịch sử.",
                    Country = "Vietnam",
                    Category = "Historical",
                    City = "Huế"
                }
            };

                await context.Destinations.AddRangeAsync(destinations);
                await context.SaveChangesAsync();
            }
        }
    }

}
