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
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typesRepo;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> brandRepo, IGenericRepository<ProductType> typesRepo)
        {
            _productsRepo = productsRepo;
            _brandRepo = brandRepo;
            _typesRepo = typesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsRepo.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productsRepo.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            var productBrand = await _brandRepo.GetAllAsync();
            return Ok(productBrand);
        }
        
        [HttpGet("types")]
        
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
         //   var productTypes = await _repo.GetProductTypesAsync();
            return Ok(await _typesRepo.GetAllAsync());
        }
        // GET
        // public IActionResult Index()
        // {
        //     return View();
        // }
    }
}