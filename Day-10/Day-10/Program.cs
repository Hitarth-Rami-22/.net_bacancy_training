// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Categary { get; set; }
}
class OrderDetail
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product{ ProductId =1, Name = "Laptop", Categary = "Electronics"},
            new Product{ ProductId =2, Name = "Smartphone", Categary = "Electronics" },
            new Product{ ProductId =3, Name = "Light", Categary = "Electrics" },
            new Product{ ProductId =4, Name = "Running Shoes", Categary = "Footwear"},

        };
        List<OrderDetail> orderDetails = new List<OrderDetail>
        {
            new OrderDetail { OrderId = 101, ProductId = 1, Quantity = 2, Price = 1200 },
            new OrderDetail { OrderId = 102, ProductId = 2, Quantity = 1, Price = 1300 },
            new OrderDetail { OrderId = 103, ProductId = 3, Quantity = 3, Price = 800 },
            new OrderDetail { OrderId = 104, ProductId = 4, Quantity = 6, Price = 1000 },

        };

        //inner join
        //query syntex
        var innerJoin = from p in products
                        join o in orderDetails on p.ProductId equals o.ProductId
                        select new { p.ProductId, p.Name, o.OrderId, o.Quantity, o.Price };

        //Method syntax
        var innerJoinMethod = products.Join(
            orderDetails,                      // Second collection
            p => p.ProductId,                  // Key from first collection
            o => o.ProductId,                  // Key from second collection
            (p, o) => new                      // Result selection
            { p.ProductId, p.Name, o.OrderId, o.Quantity, o.Price });

        Console.WriteLine("Inner Join: ");
        foreach (var item in innerJoin)
            Console.WriteLine($"{item.ProductId} {item.Name} {item.OrderId} {item.Quantity} {item.Price}");

        Console.WriteLine("\n------------------------------------------------------\n");


        // a Group Join, listing products along with their order details
        //query syntex
        var groupJoin = from p in products
                        join o in orderDetails on p.ProductId equals o.ProductId into orderGroup
                        select new { p.ProductId, p.Name, Orders = orderGroup };

        //method syntex
        var groupJoinMethod = products.GroupJoin(
           orderDetails,                     // Second collection
           p => p.ProductId,                 // Key from first collection
           o => o.ProductId,                 // Key from second collection
           (p, orderGroup) => new            // Result selection
           {p.ProductId,p.Name,Orders = orderGroup});


        Console.WriteLine("Group Join: ");
        foreach (var item in groupJoin)
        {
            Console.WriteLine($" {item.ProductId} {item.Name}");
            foreach (var order in item.Orders)
                Console.WriteLine($"  OrderId: {order.OrderId}, Quantity: {order.Quantity}");
        }
        Console.WriteLine("\n--------------------------------------------------------\n");



        //cross join, Cross Join, generating all possible combinations of Products and OrderDetails
        //query syntex
        var crossJoin = from p in products
                        from o in orderDetails
                        select new { p.Name, o.OrderId, o.Quantity };

        //method syntex
        var crossJoinMethod = products.SelectMany(
          p => orderDetails,    // Second collection
          (p, o) => new {p.Name,o.OrderId,o.Quantity});


        Console.WriteLine("Cross join: ");
        foreach (var item in crossJoin)
            Console.WriteLine($"{item.Name} {item.OrderId} {item.Quantity}");
        Console.WriteLine("\n--------------------------------------------------------\n");




        //left outer join, Left Outer Join, listing all products along with their orders (even if they haven’t been ordered)
        //query syntex
        var leftJoin = from p in products
                       join o in orderDetails on p.ProductId equals o.ProductId into orderGroup
                       from order in orderGroup
                       select new { p.ProductId, p.Name, OrderId = order?.OrderId, Quantity = order?.Quantity };

        //method syntex
        var leftJoinMethod = products.GroupJoin(
            orderDetails,
            p => p.ProductId,
            o => o.ProductId,
            (p, orderGroup) => new
            {p.ProductId,p.Name,Orders = orderGroup }).SelectMany(
                p => p.Orders,  // Flatten the collection
                (p, order) => new
                { p.ProductId,p.Name,OrderId = order?.OrderId, Quantity = order?.Quantity }); // Use null conditional operator


        Console.WriteLine("Left outer join: ");
        foreach (var item in leftJoin)
            Console.WriteLine($"{item.ProductId} {item.Name} {item.OrderId} {item.Quantity}");
        Console.WriteLine("\n--------------------------------------------------------\n");




        //group by productid and sum quantity
        //query syntex
        var groupedQuery = from o in orderDetails
                           group o by o.ProductId into g
                           select new
                           {
                               ProductId = g.Key,
                               TotalQuantity = g.Sum(o => o.Quantity) // Corrected to sum quantities
                           };
        //method syntex
        var groupedMethod = orderDetails
           .GroupBy(o => o.ProductId)
           .Select(g => new
           {
               ProductId = g.Key,
               TotalQuantity = g.Sum(o => o.Quantity) // Summing quantity instead of counting
           });

        Console.WriteLine("Total Quantity Sold: ");
        foreach (var item in groupedQuery)
            Console.WriteLine($"ProductId: {item.ProductId}, Total Quantity: {item.TotalQuantity}");
        Console.WriteLine("\n--------------------------------------------------------\n");



        //tolookup, ToLookup to create a dictionary-like structure where ProductId is the key and order details are the values
        //query syntex
        var lookupQuery = (from o in orderDetails
                           select o).ToLookup(o => o.ProductId);

        //method query
        var lookup = orderDetails.ToLookup(o => o.ProductId);

        Console.WriteLine("ToLookup: ");
        foreach (var group in lookup)
        {
            Console.WriteLine($"ProductId: {group.Key}");
            foreach (var order in group)
                Console.WriteLine($" OrderId: {order.OrderId}, Qunatity: {order.Quantity}");
        }
        Console.WriteLine("\n--------------------------------------------------------\n");




        //goup by count order & max quantity per product
        //query syntex
        var orderStatsQuery = from o in orderDetails
                              group o by o.ProductId into g
                              select new
                              {
                                  ProductId = g.Key,
                                  OrderCount = g.Count(), // Count of orders per product
                                  MaxQuantity = g.Max(o => o.Quantity) // Maximum quantity in a single order
                              };

        //method syntex
        var orderStats = orderDetails.GroupBy(o => o.ProductId)
            .Select(g => new { ProductId = g.Key, OrderCount = g.Count(), MaxQuantity = g.Max(o => o.Quantity) });

        Console.WriteLine("order count & max Quantity: ");
        foreach (var item in orderStats)
            Console.WriteLine($"ProductId: {item.ProductId}, Orders: {item.OrderCount}, Max Quantity: {item.MaxQuantity}");

        Console.WriteLine("\n--------------------------------------------------------\n");




        //product ordered more than 5 times
        //query syntex
        var frequentProductsQuery = from p in products
                                    where (from o in orderDetails
                                           where o.ProductId == p.ProductId
                                           select o).Count() > 5
                                    select p.Name;


        //method syntex
        var frequentProducts = products.Where(p => orderDetails.Count(o => o.ProductId == p.ProductId) > 5)
            .Select(p => p.Name);

        Console.WriteLine("Products ordered more than 5 times: ");
        foreach (var item in frequentProducts)
            Console.WriteLine(item);

        Console.WriteLine("\n---------------------------------------------------------\n");




        //unique category
        //query syntex
        var uniqueCategoriesQuery = (from p in products select p.Categary).Distinct();

        //method syntex
        var uniqueCategory = products.Select(p => p.Categary).Distinct();

        Console.WriteLine("Unique category: ");
        foreach (var category in uniqueCategory)
            Console.WriteLine(category);

        Console.WriteLine("\n---------------------------------------------------------\n");




        //Get a combined list of product names from two different product collections.
        //query syntex
        var moreProducts = new List<Product>
        {
            new Product{ ProductId =1, Name = "Laptop", Categary = "Electronics"},
            new Product{ ProductId =2, Name = "Smartphone", Categary = "Electronics" }
        };
        var combinedNamesQuery = (from p in products select p.Name)
           .Union(from p in moreProducts select p.Name);


        //method syntex
        var combinedName = products.Select(p => p.Name).Union(moreProducts.Select(p => p.Name));

        Console.WriteLine("Combined product Name: ");
        foreach (var name in combinedName)
            Console.WriteLine(name);

        Console.WriteLine("\n---------------------------------------------------------\n");




        //Find common product names between two different product collections
        //query syntex
        var commonNamesQuery = (from p in products select p.Name)
           .Intersect(from p in moreProducts select p.Name);

        //method syntex
        var commonName = products.Select(p => p.Name).Intersect(moreProducts.Select(p => p.Name));

        Console.WriteLine("exist product collection: ");
        foreach (var name in commonName)
            Console.WriteLine(name);

        Console.WriteLine("\n---------------------------------------------------------\n");




        //Find product names that exist in the first product collection but not in the second
        //query syntex
        var uniqueToFirstQuery = (from p in products select p.Name)
           .Except(from p in moreProducts select p.Name);

        //method syntx
        var uniqueToFirst = products.Select(products => products.Name).Except(moreProducts.Select(p => p.Name));

        Console.WriteLine("Product in first  but not in second: ");
        foreach (var name in uniqueToFirst)
            Console.WriteLine(name);

        Console.WriteLine("\n---------------------------------------------------------\n");



        //Assume a list of duplicate product names. Write a LINQ query to get a distinct list
        //query syntex
        var duplicateProducts = new List<Product>
        {
            new Product{ ProductId =1, Name = "Laptop", Categary = "Electonics"},
            new Product{ ProductId =2, Name = "Laptop", Categary = "Electonics"}
        };
        var distinctProductsQuery = (from p in duplicateProducts select p.Name).Distinct();

        //method syntex
        var distinctProducts = duplicateProducts.Select(p => p.Name).Distinct();

        Console.WriteLine("Dictinct product name: ");
        foreach (var name in distinctProducts)
            Console.WriteLine(name);

        Console.WriteLine("\n---------------------------------------------------------\n");



        //Create a LINQ query that retrieves products from a collection and demonstrate deferred execution
        //query syntex
        var deferredQueryQuerySyntax = from p in products
                                       where p.Categary == "Electronics"
                                       select p;

        //method syntex
        var deferredQuery = products.Where(p => p.Categary == "Electronics");
        Console.WriteLine("Deferred execution: ");
        foreach (var item in deferredQuery)
            Console.WriteLine(item.Name);

        Console.WriteLine("\n---------------------------------------------------------\n");



        //Use ToList() to immediately execute the query and display results
        //query syntex
        var immediateQueryQuerySyntax = (from p in products
                                         where p.Categary == "Electronics"
                                         select p).ToList();

        //method syntex
        var immediateQuery = products.Where(p => p.Categary == "Electronics").ToList();
        Console.WriteLine("Immediate execution: ");
        foreach (var item in immediateQuery)
            Console.WriteLine(item.Name);

        Console.WriteLine("\n---------------------------------------------------------\n");


        //Implement an example that simulates lazy vs. eager loading
        //query syntex(lazy loading)
        var lazyQueryQuery = from p in products
                             where p.Categary == "Electronics"
                             select p;

        products.Add(new Product { ProductId = 4, Name = "Smartwatch", Categary = "Electronics" });

        //method syntex
        var lazyQueryMethod = products.Where(p => p.Categary == "Electronics");

        Console.WriteLine("\nQuery Syntax Result:");
        foreach (var item in lazyQueryQuery)
            Console.WriteLine(item.Name);
   }
}
