using EF.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EF.Data.Config
{
    public class FoodConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
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

            builder.ToTable("Food");
            builder.HasData(LoadFoodMenu());
        }

        private static List<Food> LoadFoodMenu()
        {
            return new List<Food>
          {
          new Food { name = "Burger", price = 20 },
          new Food { name = "Pizza", price = 30 },
          new Food { name = "Pasta", price = 25 },
          new Food { name = "Salad", price = 15 },
          new Food { name = "Sushi", price = 50 },
          new Food { name = "Tacos", price = 18 },
          new Food { name = "Steak", price = 60 },
          new Food { name = "Sandwich", price = 10 },
          new Food { name = "Fries", price = 8 },
          new Food { name = "Ice Cream", price = 12 }
          };
        }

    }
}

