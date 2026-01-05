using InventorySystem.API.Enum;

namespace InventorySystem.API.Dtos
{
    public class StockMovementDto
    {
        public Guid ProductId { get; set; }
        public StockMovementType Type { get; set; }   // In / Out
        public int Quantity { get; set; }
        public string? Note { get; set; }
    }
}
