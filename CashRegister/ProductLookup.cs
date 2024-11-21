using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    internal static class ProductLookup
    {
       private static List<Product> productList = new List<Product>();
        public static void CreateLookup()
        {
            string dataString = ReadProductList();
            string[] prodItems;
            string[] products = dataString.Split('\n');
            for (int i = 0; i < products.Length; i++)
            { 
                prodItems = products[i].Split(", ");
                Product product = new Product();
                product.ProductName = prodItems[0];

                short productId = Convert.ToInt16(prodItems[1]);
                product.ProductId = productId;

                decimal productPrice = Convert.ToDecimal(prodItems[2]);
                product.ProductPrice = productPrice;

                string temp = prodItems[3];
                PriceTypes type;
                if (Enum.TryParse<PriceTypes>(temp, out type))
                    product.PriceType = type;
                else
                    Console.WriteLine("Conversion Failed for {0}", temp);

                productList.Add(product);
            }
        }

        private static string ReadProductList()
        {
            string productList;

            using (StreamReader reader = new StreamReader("../../../ProductList.txt")) 
            {
                productList = reader.ReadToEnd();
            }

            return productList;
        }

        public static Product GetProduct(short id)
        {
            foreach (Product product in productList)
            {
                if(product.ProductId == id)
                {
                    return product;
                }
            }

            return null;         
        }

        public static void PrintLookup()
        {
            foreach (Product product in productList)
            {
                Console.WriteLine($"{product.ProductName}, {product.ProductId}, {product.ProductPrice}, {product.PriceType}");
            }
        }
    }
}
