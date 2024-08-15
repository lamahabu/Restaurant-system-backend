namespace Domain
{
    public abstract class BaseEntity
    {

        public int Id { get; protected set; }
        public DateTime CreationTime { get; private set; }
        public bool IsDeleted { get; set; }
        
        public BaseEntity()
        {
            CreationTime = DateTime.Now;
            IsDeleted = false;
        }
    }
    public abstract class Item : BaseEntity
    {
        public string Name { get; set; }
        public double _price;

        public double Price
        {
            get => _price; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be greater than or equal to 0");
                }
                _price = value; 
            }
        }
        public Item(string name, double price) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            if (price < 0)
                throw new ArgumentException("Price must be greater than or equal to 0", nameof(price));

            Name = name;
            Price = price;
        }
    }

}
