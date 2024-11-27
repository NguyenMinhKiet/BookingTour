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
            Ward = "Trung tâm",
            Image = "fansipan.jpg"
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
            Ward = "Phước Mỹ",
            Image = "bien-my-khe.jpg"
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
            Ward = "Điện Biên",
            Image = "hoang-thanh-thang-long.jpg"
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
            Ward = "Phú Mỹ Hưng",
            Image = "dia-dao-cu-chi.jpg"
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
            Ward = "Cúc Phương",
            Image = "vuon-quoc-gia-cuc-phuong.jpg"
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
            Ward = "Sơn Trạch",
            Image = "hang-son-doong.jpg"
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
            Ward = "Tràng Tiền",
            Image = "ho-guom.jpg"
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
            Ward = "Hy Cương",
            Image = "le-hoi-den-hung.jpg"
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
            Ward = "Cát Bà",
            Image = "vinh_lan_ha.jpg"
        },

        // Hồ Chí Minh
    new Destination
    {
        DestinationID = Guid.NewGuid(),
        Name = "Chợ Bến Thành",
        Description = "Biểu tượng của TP. Hồ Chí Minh, nơi mua sắm và ẩm thực nổi tiếng.",
        Country = "Việt Nam",
        Category = "Market",
        Address = "Quận 1",
        City = "Hồ Chí Minh",
        District = "Quận 1",
        Ward = "Bến Thành",
        Image = "cho-ben-thanh.jpg"
    },
    new Destination
    {
        DestinationID = Guid.NewGuid(),
        Name = "Nhà Thờ Đức Bà",
        Description = "Công trình kiến trúc Pháp cổ kính giữa lòng Sài Gòn.",
        Country = "Việt Nam",
        Category = "Historical",
        Address = "Quận 1",
        City = "Hồ Chí Minh",
        District = "Quận 1",
        Ward = "Bến Nghé",
        Image = "nha-tho-duc-ba.jpg"
    },

    new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Hang Sửng Sốt",
    Description = "Hang động lớn nhất và đẹp nhất tại vịnh Hạ Long.",
    Country = "Việt Nam",
    Category = "Nature",
    Address = "Vịnh Hạ Long",
    City = "Quảng Ninh",
    District = "Hạ Long",
    Ward = "Giếng Cột", // Thêm Ward
    Image = "hang-sung-sot.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Đảo Titop",
    Description = "Địa điểm tuyệt đẹp với bãi biển thơ mộng và tầm nhìn toàn cảnh vịnh.",
    Country = "Việt Nam",
    Category = "Island",
    Address = "Vịnh Hạ Long",
    City = "Quảng Ninh",
    District = "Hạ Long",
    Ward = "Titop", // Thêm Ward
    Image = "dao-titop.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Thiền Viện Trúc Lâm",
    Description = "Ngôi thiền viện lớn nằm bên hồ Tuyền Lâm.",
    Country = "Việt Nam",
    Category = "Religious",
    Address = "Phường 3",
    City = "Đà Lạt",
    District = "Thành phố Đà Lạt",
    Ward = "Hồ Tuyền Lâm", // Thêm Ward
    Image = "thien-vien-truc-lam.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Hồ Xuân Hương",
    Description = "Hồ nước nổi tiếng giữa lòng Đà Lạt.",
    Country = "Việt Nam",
    Category = "Nature",
    Address = "Trung tâm",
    City = "Đà Lạt",
    District = "Thành phố Đà Lạt",
    Ward = "Xuân Hương", // Thêm Ward
    Image = "ho-xuan-huong.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Vinpearl Land",
    Description = "Công viên giải trí hàng đầu Việt Nam.",
    Country = "Việt Nam",
    Category = "Entertainment",
    Address = "Đảo Hòn Tre",
    City = "Nha Trang",
    District = "Thành phố Nha Trang",
    Ward = "Hòn Tre", // Thêm Ward
    Image = "vinpearl-land.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Bãi Dài",
    Description = "Bãi biển tuyệt đẹp với cát trắng mịn.",
    Country = "Việt Nam",
    Category = "Beach",
    Address = "Cam Ranh",
    City = "Khánh Hòa",
    District = "Cam Ranh",
    Ward = "Cam Hải", // Thêm Ward
    Image = "bai-dai.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Bãi Sao",
    Description = "Bãi biển đẹp nhất của đảo Phú Quốc.",
    Country = "Việt Nam",
    Category = "Beach",
    Address = "Phú Quốc",
    City = "Kiên Giang",
    District = "Phú Quốc",
    Ward = "Dương Tơ", // Thêm Ward
    Image = "bai-sao.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Vinpearl Safari",
    Description = "Công viên chăm sóc và bảo tồn động vật bán hoang dã đầu tiên tại Việt Nam.",
    Country = "Việt Nam",
    Category = "Wildlife",
    Address = "Phú Quốc",
    City = "Kiên Giang",
    District = "Phú Quốc",
    Ward = "Dương Tơ", // Thêm Ward
    Image = "vinpearl-safari.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Bản Cát Cát",
    Description = "Làng dân tộc nổi tiếng với văn hóa đặc sắc.",
    Country = "Việt Nam",
    Category = "Cultural",
    Address = "Sapa",
    City = "Lào Cai",
    District = "Sapa",
    Ward = "Cát Cát", // Thêm Ward
    Image = "ban-cat-cat.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Hoàng Cung Huế",
    Description = "Di tích lịch sử nổi bật của cố đô Huế.",
    Country = "Việt Nam",
    Category = "Historical",
    Address = "Thành phố Huế",
    City = "Thừa Thiên Huế",
    District = "Thành phố Huế",
    Ward = "Hoàng Cung", // Thêm Ward
    Image = "hoang-cung-hue.jpg"
},
new Destination
{
    DestinationID = Guid.NewGuid(),
    Name = "Chùa Thiên Mụ",
    Description = "Ngôi chùa cổ nổi tiếng bên dòng sông Hương.",
    Country = "Việt Nam",
    Category = "Religious",
    Address = "Thành phố Huế",
    City = "Thừa Thiên Huế",
    District = "Thành phố Huế",
    Ward = "Thiên Mụ", // Thêm Ward
    Image = "chua-thien-mu.jpg"
}



            };

                await context.Destinations.AddRangeAsync(destinations);
                await context.SaveChangesAsync();
            }
        }
    }

}
