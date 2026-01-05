namespace InventorySystem.API.Dtos
{
    public class CreateProductDto
    {
        public string name { get; set; }
        public string Sku { get; set; } // ma don hang
        public string unit { get; set; } = "pcs"; //pieces
        public decimal ImportPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int ReorderLevel { get; set; }
    }
}
