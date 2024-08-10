namespace EF.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public DateTime Holder { get; set; }
        public bool IsDeleted { get; set; }
        public string name { get; set; } = null!;
        public decimal price { get; set; }
    }
}
