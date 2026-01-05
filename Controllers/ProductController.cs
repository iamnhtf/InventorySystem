using InventorySystem.API.Data;
using InventorySystem.API.Dtos;
using InventorySystem.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.name,
                Sku = dto.Sku,
                Unit = dto.unit,
                ImportPrice = dto.ImportPrice,
                SellPrice = dto.SellPrice,
                ReorderLevel = dto.ReorderLevel,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }
    }
}
