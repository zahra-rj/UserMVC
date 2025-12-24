using UserMVC.DB;
using UserMVC.Models;

namespace UserMVC.Services
{
    public class ProductService : IProductService
    {
        //private static readonly List<Product> _products = new List<Product>
        //{
        //    new Product { Id = 1, Name="ستاره", Description="jsnjk", ImgPath="njjnk",price=2293,quantity=2 }

        //};
        public ProductService()
        {
            InitData();
        }
        public async Task InitData()
        {
            if (Database.Product == null)
            {
                Database.Product = new List<Product>();
            }
            if (Database.Product.Count == 0)
            {
                Database.Product.Add(new Product { Id = 1, Name = "ستاره", Description = "jsnjk", ImgPath = "/img/img.jpg", price = 2293, quantity = 2 });
                Database.Product.Add(new Product { Id = 1, Name = "زهرا", Description = "jsnjfvhk", ImgPath = "/img/img.jpg", price = 23, quantity = 23 });
            }

        }
        public async Task<List<Product>> GetList()
        {
            return Database.Product.ToList();

        }

        public async Task<Product> GetByID(int id)
        {
            var product= Database.Product.FirstOrDefault(p=>p.Id==id);
            return product;

        }

       
        public async Task Insert(Product product)
        {
            product.Id = Database.Product.OrderByDescending(p => p.Id).Select(p => p.Id).FirstOrDefault() + 1;
            Database.Product.Add(product);
        }

        public async Task Update(Product product)
        {

            Product old = await GetByID(product.Id);
            Database.Product.Remove(product);
            Database.Product.Add(product);
        }

        public async Task delete(int id)
        {
            Product product= await GetByID(id);
            Database.Product.Remove(product);
        }


    }
}
