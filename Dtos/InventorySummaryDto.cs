namespace InventorySystem.API.Dtos
{
    public class InventorySummaryDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsLowStock { get; set; }
    }
}
