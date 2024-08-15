using Contract;
using Microsoft.OpenApi.Models;
using Application;
using EFramework.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoMapper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuotMapper", Version = "v1" });
            });

            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped<IDrink, DrinkServices>();
            services.AddScoped<IFood, FoodServices>();
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("constr"))
           );

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuotMapper v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}