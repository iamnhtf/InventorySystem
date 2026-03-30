namespace InventorySystem.API.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Sku { get; set; } // ma don hang
        public string Unit { get; set; } = "pcs"; //pieces
        public decimal ImportPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int ReorderLevel { get; set; }
    }
}
