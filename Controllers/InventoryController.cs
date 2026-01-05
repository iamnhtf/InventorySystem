using InventorySystem.API.Data;
using InventorySystem.API.Dtos;
using InventorySystem.API.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Controllers
{
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/inventory/summary
        [HttpGet("summary")]
        public async Task<IActionResult> GetInventorySummary()
        {
            var result = await _context.Products
                .Select(p => new InventorySummaryDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    Sku = p.Sku,
                    ReorderLevel = p.ReorderLevel,

                    QuantityInStock =
                        _context.StockMovements
                            .Where(sm => sm.ProductId == p.Id)
                            .Sum(sm => sm.Type == StockMovementType.In
                                ? sm.Quantity
                                : -sm.Quantity),

                    IsLowStock =
                        _context.StockMovements
                            .Where(sm => sm.ProductId == p.Id)
                            .Sum(sm => sm.Type == StockMovementType.In
                                ? sm.Quantity
                                : -sm.Quantity) < p.ReorderLevel
                })
                .ToListAsync();

            return Ok(result);
        }
    }
}
