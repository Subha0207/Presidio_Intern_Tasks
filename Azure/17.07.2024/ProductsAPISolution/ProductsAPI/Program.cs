using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Context;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using ProductsAPI.Repository;

namespace ProductsAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            const string secretName = "Subhashini76";
            var keyVaultName = "subha-vault";
            var uri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(uri), new DefaultAzureCredential());

            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine($"Your secret is '{secret.Value.Value}'.");

            // Add DbContext configuration
            builder.Services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(secret.Value.Value);
            });
            // add dbcontext configuration
            //builder.Services.AddDbContext<ProductContext>(
            //    options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
            //);


            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IRepository<int, Product>, ProductRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
    }
}
