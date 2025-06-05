using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem1
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            // 1. Products with category "FMCG"
            Console.WriteLine("1. Products with category 'FMCG':");
            Display(products.Where(p => p.ProCategory == "FMCG"));

            // 2. Products with category "Grain"
            Console.WriteLine("\n2. Products with category 'Grain':");
            Display(products.Where(p => p.ProCategory == "Grain"));

            // 3. Sort products by product code
            Console.WriteLine("\n3. Products sorted by Product Code:");
            Display(products.OrderBy(p => p.ProCode));

            // 4. Sort products by product category
            Console.WriteLine("\n4. Products sorted by Category:");
            Display(products.OrderBy(p => p.ProCategory));

            // 5. Sort products by product Mrp (ascending)
            Console.WriteLine("\n5. Products sorted by Mrp (Ascending):");
            Display(products.OrderBy(p => p.ProMrp));

            // 6. Sort products by product Mrp (descending)
            Console.WriteLine("\n6. Products sorted by Mrp (Descending):");
            Display(products.OrderByDescending(p => p.ProMrp));

            // 7. Group products by Category
            Console.WriteLine("\n7. Group products by Category:");
            var groupedByCategory = products.GroupBy(p => p.ProCategory);
            foreach (var group in groupedByCategory)
            {
                Console.WriteLine($"\nCategory: {group.Key}");
                Display(group);
            }

            // 8. Group products by Mrp
            Console.WriteLine("\n8. Group products by Mrp:");
            var groupedByMrp = products.GroupBy(p => p.ProMrp);
            foreach (var group in groupedByMrp)
            {
                Console.WriteLine($"\nMRP: {group.Key}");
                Display(group);
            }

            // 9. Highest price product in FMCG
            Console.WriteLine("\n9. Highest priced product in FMCG:");
            var highestFMCG = products
                .Where(p => p.ProCategory == "FMCG")
                .OrderByDescending(p => p.ProMrp)
                .FirstOrDefault();
            if (highestFMCG != null)
                Console.WriteLine($"{highestFMCG.ProCode}\t{highestFMCG.ProName}\t{highestFMCG.ProMrp}");

            // 10. Count total products
            Console.WriteLine($"\n10. Total number of products: {products.Count}");

            // 11. Count of FMCG products
            Console.WriteLine($"11. Total number of FMCG products: {products.Count(p => p.ProCategory == "FMCG")}");

            // 12. Max price
            Console.WriteLine($"12. Maximum price: {products.Max(p => p.ProMrp)}");

            // 13. Min price
            Console.WriteLine($"13. Minimum price: {products.Min(p => p.ProMrp)}");

            // 14. Are all products below 30?
            Console.WriteLine($"14. Are all products priced below Rs.30? {products.All(p => p.ProMrp < 30)}");

            // 15. Are any products below 30?
            Console.WriteLine($"15. Are any products priced below Rs.30? {products.Any(p => p.ProMrp < 30)}");

            Console.ReadLine();
        }

        static void Display(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProCode}\t{p.ProName}\t{p.ProMrp}\t{p.ProCategory}");
            }
        }
    }
}
