namespace KCTechStore.Models
{
    public class ShoeViewModel
    {
        public int ShoeId { get; }
        public string ShoeName { get; set; }
        public IEnumerable<SizeViewModel> Sizes { get; set; }
        public string Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public bool? IsInStock { get; set; }
        public string ShoePhoto { get; set; }
        public string Condition { get; set; }
    }
}
