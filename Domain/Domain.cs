using Domain.Shared.Layer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
                    throw new ArgumentException(ErrorsConstant.LessThanZero);
                }
                _price = value;
            }
        }

        public Item(string name, double price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ErrorsConstant.Empty, nameof(name));

            Name = name;
            Price = price;
        }
    }
}
