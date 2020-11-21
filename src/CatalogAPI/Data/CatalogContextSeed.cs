using System;
using System.Collections.Generic;
using CatalogAPI.Entities;
using MongoDB.Driver;

namespace CatalogAPI.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconficuredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconficuredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone X",
                    Summary = "Summary test",
                    Description = "Desc test",
                    ImageFile = "priduct-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samsung S8 plus",
                    Summary = "Summary test",
                    Description = "Desc test",
                    ImageFile = "priduct-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
            };
        }
    }
}
