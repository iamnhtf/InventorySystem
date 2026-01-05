namespace InventorySystem.API.Dtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; } = null!;
        public string Unit { get; set; } = "pcs";
        public decimal ImportPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
