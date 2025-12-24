using System.ComponentModel.DataAnnotations;

namespace UserMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام محصول الزامی است.")]
        [StringLength(10, ErrorMessage = "نام محصول نمی‌تواند بیش از ۱۰ کاراکتر باشد.")]

        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImgPath { get; set; }

        public decimal price {  get; set; }
        public int quantity { get; set; }
        public IFormFile File { get; set; }
    }
}
