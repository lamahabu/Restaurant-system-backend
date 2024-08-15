using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;
using EFramework.Data;
namespace EF.Data.Config
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Price)
                .HasPrecision(15, 2);

            builder.Property(x => x.CreationTime)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.IsDeleted)
            .HasDefaultValue(0);

            builder.ToTable("Drinks");
            builder.HasData(SeedData.LoadDrinks());
        }

        private static List<Drink> LoadDrinkMenu()
        {
            return new List<Drink>
           {
                //new Drink{ Name = "Coca-Cola", Price = 5 },
          
            };
        }
    }
}
