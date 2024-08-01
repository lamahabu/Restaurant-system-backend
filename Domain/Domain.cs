namespace Domain
{
    public abstract class BaseEntity
    {
        private static int _nextId = 1;

        public int Id { get; protected set; }
        public DateTime CreationTime { get; private set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            Id = _nextId++;
            CreationTime = DateTime.Now;
            IsDeleted = false;
        }
    }
    public abstract class Item : BaseEntity
    {
        public string Name { get; set; }

        private double price;
        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be greater than 0");
                }
                price = value;
            }
        }
        public Item(String Name, double price)
        {
            this.Name = Name;
            this.price = price;
        }
    }

}
