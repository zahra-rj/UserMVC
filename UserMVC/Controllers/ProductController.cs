using Microsoft.AspNetCore.Mvc;
using UserMVC.Models;
using UserMVC.Services;

namespace UserMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> List()
        {
            var res= await _productService.GetList();
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            var product = new Product();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Product product)
        {
            if (product.File == null || product.File.Length == 0)
                return BadRequest("فایلی انتخاب نشده است.");

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", product.File.FileName);
            var directory= Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
             
            using(var stream = new FileStream(path, FileMode.Create))
            {
                await product.File.CopyToAsync(stream);

            }
            product.ImgPath= "/img/" + product.File.FileName;
            await _productService.Insert(product);
            return RedirectToAction("list");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Product product= await _productService.GetByID(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.Update(product);
            return RedirectToAction("list");
        }

        public async Task<IActionResult>Delete (int id)
        {
            await _productService.delete(id);
            return RedirectToAction("list");
        }

    }
    
    
}
