namespace AbruzaCosmicProducts_Backend.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}

//{
//    public class UserCart
//    {
//        public int Id { get; set; }
//        public List<Product> items { get; set; }

//    }
//}

