using InventorySystem.API.Data;
using InventorySystem.API.Dtos;
using InventorySystem.API.Entities;
using InventorySystem.API.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockMovementsController: ControllerBase
    {
        private readonly AppDbContext _db;
        public StockMovementsController (AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StockMovementDto dto)
        {
            var product = await _db.Products.FindAsync(dto.ProductId);
            if (product == null)
                return NotFound("Product not found");

            if (dto.Quantity <= 0)
                return BadRequest("Quantity must be greater than 0");

            if (dto.Type == StockMovementType.Out)
            {
                var currentStock = await _db.StockMovements
                    .Where(x => x.ProductId == dto.ProductId)
                    .SumAsync(x => x.Type == StockMovementType.In
                        ? x.Quantity
                        : -x.Quantity);

                if (currentStock < dto.Quantity)
                    return BadRequest("Not enough stock");
            }

            var movement = new StockMovement
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                Type = dto.Type,
                Quantity = dto.Quantity,
                Note = dto.Note,
                CreatedAt = DateTime.UtcNow
            };

            _db.StockMovements.Add(movement);
            await _db.SaveChangesAsync();

            return Ok(movement);
        }


        // GET: api/stockmovements
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movements = await _db.StockMovements
                .Include(x => x.Product)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return Ok(movements);
        }
    }
}
