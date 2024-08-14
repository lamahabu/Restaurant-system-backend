using Microsoft.EntityFrameworkCore;
using EF.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Data.Config
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);//varchar(155)

            builder.Property(x => x.price)
                .HasPrecision(15, 2);

            builder.Property(x => x.CreationTime)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.IsDeleted)
            .HasDefaultValue(0);

            builder.ToTable("Drinks");
            builder.HasData(LoadDrinkMenu());
        }

        private static List<Drink> LoadDrinkMenu()
        {
            return new List<Drink>
           {
            new Drink { name = "Coca-Cola", price = 5 },
            new Drink { name = "Pepsi", price = 5 },
            new Drink { name = "Orange Juice", price = 8 },
            new Drink { name = "Lemonade", price = 7 },
            new Drink { name = "Iced Tea", price = 6 },
            new Drink { name = "Coffee", price = 4 },
            new Drink { name = "Espresso", price = 6 },
            new Drink { name = "Milkshake", price = 10 },
            new Drink { name = "Smoothie", price = 12 },
            new Drink { name = "Mineral Water", price = 3 }
            };
        }

    }
}
