namespace ApiWebshop
{
    public class Clients
    {
        public int Id { get; set; }
        public string? CreatedAt { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<dynamic>? Address { get; set; }
        public List<dynamic> Company { get; set; }
        public List<dynamic> Orders { get; set; }
        public List<dynamic> Profil { get; set; }

    }
}
