using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace EF.Data.Config
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Price)
                .HasPrecision(15, 2);

            builder.Property(x => x.CreationTime)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.IsDeleted)
                 .HasDefaultValue(0);

            builder.ToTable("Food");
            //builder.HasData(LoadFoodMenu());
        }
        private static List<Food> LoadFoodMenu()
        {
            return new List<Food>
            {
                 new Food("Burger", 20),
                 new Food("Pizza", 30),
                 new Food("Fries", 15)
            };
        }
    }
}
