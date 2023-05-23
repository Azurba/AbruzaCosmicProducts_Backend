using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace AbruzaCosmicProducts_Backend.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public string Name { get; set; }
        public int quantity { get; set; }
        public string Description { get; set; }
        public int rating { get; set; }
        [Column(TypeName = "decimal(10,2)")] // Specify the store type as decimal with precision 10 and scale 2
        public decimal price{ get; set; }
        public string image { get; set; }
    }
}
