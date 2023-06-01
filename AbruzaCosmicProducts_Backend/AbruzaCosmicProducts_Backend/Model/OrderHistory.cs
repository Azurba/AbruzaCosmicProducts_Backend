using System.ComponentModel.DataAnnotations.Schema;

namespace AbruzaCosmicProducts_Backend.Model
{
    public class OrderHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public int CardNumber { get; set; }
        //public int ProductId { get; set; }

        // Define a navigation property to represent the collection of products related to this order
        public List<Product> Products { get; set; }
    }
}

