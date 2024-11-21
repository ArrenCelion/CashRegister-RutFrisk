using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    internal class Register
    {
        Receipt receipt = new Receipt();
        public void StartApplication()
        {
            Menu.Welcome();
            StartMenu();
        }

        private void StartMenu()
        {
            receipt = new Receipt();
            string choice = Menu.StartMenu();
            HandleInputMenu(choice);
        }

        public void CashRegister()
        {
            string input = Menu.RegisterMenu(receipt);
            HandleRegisterInput(input);
        }

        private void HandleInputMenu(string input)
        {

            switch (input)
            {
                case "1":
                    CashRegister();
                    break;
                case "2":
                    string answer = Menu.PrintMenu();
                    if (answer == "0")
                    {
                        StartMenu();
                    }
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Det var inte ett giltigt menyval, var vänlig skriv in siffran för det valet du vill göra");
                    break;
            }
        }

        private void HandleRegisterInput(string input)
        {
            if (input.ToUpper() == "PAY")
            {
                Pay();
            }
            else
            {
                BuyProduct(input);
            }
        }


        public void BuyProduct(string input)
        {
            Order order = SplitInput(input);
            if (order == null)
            {
                CashRegister();
                return;
            }

            Product currentProduct = ProductLookup.GetProduct(order.prodId);
            if (currentProduct == null)
            {
                CashRegister();
                return;
            }

            receipt.AddProduct(currentProduct, order.amount);
            CashRegister();
        }

        private class Order()
        {
            public short prodId = 0;
            public short amount = 0;
        }
        private Order SplitInput(string input)
        {
            Order order = new Order();
            try
            {
                string temp;
                string[] product = input.Split(' ');
                temp = product[0];
                order.prodId = Convert.ToInt16(temp);
                temp = product[1];
                order.amount = Convert.ToInt16(temp);
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            return null;
        }

        public void Pay()
        {
            PrintReceiptToFile();
            Console.WriteLine("Tack för att du handlat");
            Console.ReadKey();
            StartMenu();
        }
        private void PrintReceiptToFile()
        {
            var date = DateTime.Now.ToShortDateString();
            string data = receipt.ConvertToData();
            string divider = "\n~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~\n";
            string path = $"../../../RECEIPT_{date}.txt";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                if (data != null)
                {
                    writer.WriteLine();
                    writer.WriteLine("KVITTO:");
                    writer.Write(data);
                    writer.Write(divider);
                }
            }
        }
    }
}
