namespace UserMVC.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public int UserId { get; set; }
        public string ImgPath { get; set; }
        public IFormFile File { get; set; }
    }
}
