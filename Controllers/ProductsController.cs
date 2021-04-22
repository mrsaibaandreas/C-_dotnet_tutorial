using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            var productBrand = await _repo.GetProductBrandsAsync();
            return Ok(productBrand);
        }
        
        [HttpGet("types")]
        
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
         //   var productTypes = await _repo.GetProductTypesAsync();
            return Ok(await _repo.GetProductTypesAsync());
        }
        // GET
        // public IActionResult Index()
        // {
        //     return View();
        // }
    }
}