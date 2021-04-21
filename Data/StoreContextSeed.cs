using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.Extensions.Logging;

namespace API.Data
{
    public class StoreContextSeed
    {
        public static async Task Seed(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var productBrands = File.ReadAllText("Data/Seeders/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrands);
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var productTypes = File.ReadAllText("Data/Seeders/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(productTypes);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }


                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("Data/Seeders/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }

            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error ocurred during seeding data from json");
            }
        }
    }
}