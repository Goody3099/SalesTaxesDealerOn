using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxesDealerOn
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start of the program 
            Console.WriteLine("Fill your Cart!");

            // Initialize the cart
            List<Items> cart = new List<Items>();

            // Walks user though adding items to the cart.
            while (true)
            {
                Console.WriteLine("Enter name of product. If no product is entered the cart will be calculated and the receipt will be printed.");
                string name = Console.ReadLine();
                if (name == "")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a price for this product.");
                    string price = Console.ReadLine();
                    decimal priceConverted = decimal.Parse(price);

                    Console.WriteLine("Is this product one of the following: Books, Food, or Medical Products? y for yes n for no");
                    string tax = Console.ReadLine();
                    bool taxBool = taxable(tax);

                    Console.WriteLine("Is this product an import? y for yes n for no");
                    string import = Console.ReadLine();
                    bool importBool = importTaxable(import);

                    decimal salesTax = salesTaxCalc(taxBool, priceConverted);

                    decimal importTax = importTaxCalc(importBool, priceConverted);

                    Items item = new Items(name, priceConverted, taxBool, salesTax, importBool, importTax);
                    cart.Add(item);
                }
            }

            // Calculate values for cart.
            decimal totalSalesTax = cart.Sum(tST => tST.salesTax);
            decimal totalImportTax = cart.Sum(tIT => tIT.importTax);
            decimal totalTax = totalSalesTax + totalImportTax;
            decimal total = cart.Sum(item => item.price);

            // Print out the receipt.
            cart.ForEach(x => Console.WriteLine(x.name + ":" + " " + (x.price + x.salesTax + x.importTax)));
            Console.WriteLine("Sales Taxes: " + totalTax);
            Console.WriteLine("Total: " + (total + totalTax));
        }

        // Helper methods for the logic.
        static decimal importTaxCalc(bool importBool, decimal price)
        {
            if (importBool == true)
            {
                decimal importTax = Math.Round((price / 20) * 20) / 20;
                return importTax;
            }
            else
            {
                return 0;
            }
        }

        static decimal salesTaxCalc(bool taxBool, decimal price)
        {
            if (taxBool == true)
            {
                decimal salesTax = Math.Round((price / 10) * 20) / 20;
                return salesTax;
            }
            else
            {
                return 0;
            }
        }

        static bool taxable(string tax)
        {
            if (tax.ToLower() == "y")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool importTaxable(string import)
        {
            if (import.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}