namespace AbruzaCosmicProducts_Backend.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int quantity { get; set; }
        public string Description { get; set; }
        public int rating { get; set; }
        public int price { get; set; }
        public string image { get; set; }
    }
}
