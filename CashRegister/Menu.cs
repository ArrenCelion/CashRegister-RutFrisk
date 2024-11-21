using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    internal class Menu
    {
        public static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("             * * * * * * * * * * * * * * * * * * * * * * * *            ");
            Console.WriteLine(" ");
            Console.WriteLine("                        Välkommen till Ruts Livs!                       ");
            Console.WriteLine(" ");
            Console.WriteLine("   För att navigera i butiken skriv in ditt val och tryck sedan enter   ");
            Console.WriteLine("          Tryck enter för att gå vidare om du har läst färdigt          ");
            Console.WriteLine(" ");
            Console.WriteLine("             * * * * * * * * * * * * * * * * * * * * * * * *            ");
            Console.ReadLine();
        }


        public static string StartMenu()
        {
            Console.Clear();
            Console.WriteLine("KASSA");
            Console.WriteLine("1. Ny Kund");
            Console.WriteLine("2. Produktlista");
            Console.WriteLine("0. Avsluta");
            string choice = Console.ReadLine();

            return choice;
        }

        public static string PrintMenu()
        {
            Console.Clear();
            ProductLookup.PrintLookup();
            Console.WriteLine("0. Gå tillbaka");
            string answer = Console.ReadLine();
            return answer;
        }

        public static string RegisterMenu(Receipt receipt)
        {
            string input = "";
            Console.Clear();
            Console.WriteLine("KASSA");
            receipt.WriteReceipt();
            Console.WriteLine("Kommandon: ");
            Console.WriteLine("<ProduktID> <Antal>");
            Console.WriteLine("PAY");
            Console.Write("Kommando: ");
            input = Console.ReadLine();

            return input;
        }
    }
}
