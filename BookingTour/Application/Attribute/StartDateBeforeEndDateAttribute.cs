using System.ComponentModel.DataAnnotations;
namespace Application.Attribute
{
    public class StartDateBeforeEndDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dto = (dynamic)validationContext.ObjectInstance; // Dùng dynamic để hỗ trợ các DTO khác có thuộc tính tương tự
            if (dto.StartDate >= dto.EndDate)
            {
                return new ValidationResult("Ngày bắt đầu phải lớn hơn ngày kết thúc.");
            }

            return ValidationResult.Success;
        }
    }
}
