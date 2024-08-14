using Microsoft.EntityFrameworkCore;
using EF.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Data.Config
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
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

            builder.ToTable("Drinks");
           // builder.HasData(LoadDrinkMenu());
        }

        private static List<Drink> LoadDrinkMenu()
        {
            return new List<Drink>
           {
            new Drink {Id=1, name = "Coca-Cola", price = 5 },
          
            };
        }

    }
}
