using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;

        public ProductInMemoryRepository()
        {
            // Init with default values
            products = new List<Product>()
            {
                new Product { ProductId = 1, CategoryId = 1, Name = "Orange Juice", Quantity = 100, Price = 1.99 },
                new Product { ProductId = 2, CategoryId = 1, Name = "Cola", Quantity = 200, Price = 1.99 },
                new Product { ProductId = 3, CategoryId = 2, Name = "Bread", Quantity = 300, Price = 1.50 },
                new Product { ProductId = 4, CategoryId = 3, Name = "Chicken Legs", Quantity = 400, Price = 10.50 },
                new Product { ProductId = 5, CategoryId = 3, Name = "Lamb Chops", Quantity = 300, Price = 20.50 },
                new Product { ProductId = 6, CategoryId = 4, Name = "Milk", Quantity = 150, Price = 2.50 },
                new Product { ProductId = 7, CategoryId = 4, Name = "Cheese", Quantity = 100, Price = 3.99 },
                new Product { ProductId = 8, CategoryId = 5, Name = "Apples", Quantity = 250, Price = 0.75 },
                new Product { ProductId = 9, CategoryId = 5, Name = "Pears", Quantity = 50, Price = 0.75 },
                new Product { ProductId = 10, CategoryId = 5, Name = "Bananas", Quantity = 70, Price = 0.50 },
                new Product { ProductId = 11, CategoryId = 5, Name = "Grapes", Quantity = 40, Price = 1.25 },
                new Product { ProductId = 12, CategoryId = 5, Name = "Strawberries", Quantity = 30, Price = 2.00 },
                new Product { ProductId = 13, CategoryId = 5, Name = "Lettuce", Quantity = 25, Price = 1.00 },
                new Product { ProductId = 14, CategoryId = 5, Name = "Tomatoes", Quantity = 35, Price = 1.50 },
                new Product { ProductId = 15, CategoryId = 5, Name = "Cucumbers", Quantity = 20, Price = 0.75 },
                new Product { ProductId = 16, CategoryId = 5, Name = "Carrots", Quantity = 45, Price = 0.80 },
                new Product { ProductId = 17, CategoryId = 5, Name = "Bell Peppers", Quantity = 30, Price = 1.25 },
                new Product { ProductId = 18, CategoryId = 5, Name = "Spinach", Quantity = 25, Price = 1.25 },
                new Product { ProductId = 19, CategoryId = 7, Name = "Ice Cream", Quantity = 120, Price = 2.25 },
                new Product { ProductId = 20, CategoryId = 7, Name = "Frozen Pizza", Quantity = 80, Price = 4.99 }
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (products != null && products.Count > 0)
            {
                var maxId = products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }


            products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
        }

        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(x => x.ProductId == productId);
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);
            if (productToDelete != null) products.Remove(productToDelete);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return products.Where(x => x.CategoryId == categoryId);
        }
    }
}
