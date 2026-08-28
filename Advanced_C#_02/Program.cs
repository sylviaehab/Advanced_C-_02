using Advanced_C__02.Data;

namespace Advanced_C__02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new()
{
    new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
    new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
    new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
    new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
    new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
    new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
    new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
    new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
    new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
    new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
};

            List<Product> electronics = Product.SearchProducts(
                catalog,
                product => product.Category == "Electronics"
            );
            List<Product> under50 = Product.SearchProducts(
                catalog,
                product => product.Price < 50
            );
            List<Product> stock = Product.SearchProducts(
                catalog,
                product => product.Stock > 0
            );
            List<Product> clothing = Product.SearchProducts(
                catalog,
                product => product.Category == "Clothing" && product.Price < 100
            );

            Console.WriteLine("========= Electronics =========");

            foreach (Product products in electronics)
            {
                Console.WriteLine($"{products.Name}: ${products.Price}(Stock: {products.Stock})");

            }
            Console.WriteLine("========= Under $50 =========");
            foreach (Product products in under50)
            {
                Console.WriteLine($"{products.Name}- ${products.Price}(Stock: {products.Stock})");
            }
            Console.WriteLine("========= In Stock =========");
            foreach (Product products in stock)
            {
                Console.WriteLine($"{products.Name}- ${products.Price}(Stock: {products.Stock})");
            }
            Console.WriteLine("========= Clothing Under $100 =========");
            foreach (Product products in clothing)
            {
                Console.WriteLine($"{products.Name}- ${products.Price}(Stock: {products.Stock})");
            }

            //(Using Action<Product>)
            Console.WriteLine("========= Short Report =========");
            Product.PrintReport(catalog, product => Console.WriteLine($"{product.Name}- ${product.Price}"));
            Console.WriteLine("========= Detailed Report =========");
            Product.PrintReport(catalog, product => Console.WriteLine($"[{product.Category}]{product.Name}| ${product.Price} | Stock: {product.Stock}"));
           // (Using Func<Product, TResult>)
            Console.WriteLine("========= Summary List =========");
            var summary = Product.TransformProducts(catalog, product => $"{product.Name} (${product.Price})");
            foreach (var item in summary)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("========= Price Label =========");
            var labels = Product.TransformProducts(catalog, product => $"{product.Name}: {(product.Price > 100 ? "Expensive!" : "Affordable")}");
            foreach (var item in labels)
            {
                Console.WriteLine(item);

            }
            //(Using Predicate<Product>)
            Console.WriteLine("========= Low-Stock Alert =========");
            List<Product> lowStock =Product.FilterProducts(catalog, product => product.Stock < 20);
            foreach (Product product in lowStock)
            {
                Console.WriteLine($"[Low Stock]{product.Name}: only {product.Stock} left!");
            }

        }
    }
}
