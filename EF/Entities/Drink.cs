namespace EF.Entities
{
    public class Drink
    {
        public int Id { get; set; }
        public string name { get; set; } = null!;
        public decimal price { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}

