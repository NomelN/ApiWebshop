namespace ApiWebshop
{
    public class CommandeProduit
    {
        public int IdCommande { get; set; }
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
        public string CreatedAt { get; set; }
        public object Id { get; internal set; }
    }
}