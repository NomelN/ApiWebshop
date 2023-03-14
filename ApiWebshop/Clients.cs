namespace ApiWebshop
{
    public class Clients
    {
        public int? Id { get; set; }
        public string? CreatedAt { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public List<dynamic>? address { get; set; }
        
        public List<dynamic>? company { get; set; }

        public List<dynamic>? orders { get; set; }
        public List<dynamic>? Profil { get; set; }

    }
}
