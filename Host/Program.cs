using Domain;
using EFramework.Data;
using Microsoft.EntityFrameworkCore;
using Application;
namespace AutoMapper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            //using (var context = new AppDbContext())
            //{
            //    await context.Database.EnsureCreatedAsync();

            //    if (!await context.Set<Food>().AnyAsync())
            //    {
            //        context.Set<Food>().AddRange(SeedData.LoadFood());
            //        await context.SaveChangesAsync();
            //    }

            //    if (!await context.Set<Drink>().AnyAsync())
            //    {
            //        context.Set<Drink>().AddRange(SeedData.LoadDrinks());
            //        await context.SaveChangesAsync();
            //    }
            //}
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}