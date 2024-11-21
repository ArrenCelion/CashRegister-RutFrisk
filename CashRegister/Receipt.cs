using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    internal class Receipt
    {
        List<string> receiptList = new List<string>();
        decimal totalAmount;
        bool firstCall = true;
        public void AddProduct(Product product, short amount)
        {
            decimal productCost = product.ProductPrice * amount;
            string currentProduct = $"{product.ProductName} {amount} * {product.ProductPrice} Kr/{product.PriceType} = {productCost} Kr";
            receiptList.Add(currentProduct);
            totalAmount += productCost; //amount ska vara totala produkt kostnaden amount * price
        }

        public void WriteReceipt()
        {
            var currentTime = DateTime.Now;
            string receiptStart = "KVITTO ";

            if (!firstCall && receiptList != null)
            {
                Console.WriteLine(receiptStart + currentTime);

                foreach (var item in receiptList)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Total: {totalAmount}");
            }
            else
            {
                firstCall = false;
            }
        }

        public string ConvertToData()
        {
            string data = "";
            string productData;
            foreach (var item in receiptList)
            {
                productData = item.ToString();
                data += productData + "\n";
            }
            return data;
        }
    }
}
