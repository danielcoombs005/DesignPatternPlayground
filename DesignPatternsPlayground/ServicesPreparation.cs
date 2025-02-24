using DesignPatternsPlayground.Models;
using DesignPatternsPlayground.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using DesignPatternsPlayground.Services;

namespace DesignPatternsPlayground
{
    public static class ProgramPreparation
    {
        public static WebApplicationBuilder PrepareServices(ref WebApplicationBuilder builder) 
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Prepare connections in the application
            PrepareSingletons(ref builder);
            PrepareScopes(ref builder);
            PrepareContext(ref builder);

            return builder;
        }

        public static void RunApp(WebApplicationBuilder builder)
        {
            var app = builder.Build();

            // Ensure the application is connected to the database
            // Should be used in a development environment only
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();

                if (!dbContext.Database.CanConnect())
                {
                    throw new NotImplementedException("Can't connect to the database.");
                }
            }

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }

        private static void PrepareSingletons(ref WebApplicationBuilder builder)
        {

        }

        private static void PrepareScopes(ref WebApplicationBuilder builder)
        {
            // Generically assign repository scopes to any instance
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped(typeof(IDBRepository<>), typeof(DBRepository<>));
        }

        private static void PrepareContext(ref WebApplicationBuilder builder)
        {
            /**
             * Must construct the connection string in the appsetting.json file like so:
             *   "ConnectionStrings": {
             *     "DatabaseConnection": "CONNECTION STRING HERE"
             *   }
             */
            var config = builder.Configuration;
            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(config.GetConnectionString("DatabaseConnection")));
        }
    }
}
