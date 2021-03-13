using System;
using System.Collections.Generic;

namespace SalesReceipts
{
    class Program
    {
        static Dictionary<int, List<Receipt>> Receipts = new Dictionary<int, List<Receipt>>();

        static Receipt NewReceipt = new Receipt();
        static void Main(string[] args)
        {
            OrderInput();

            //Console.WriteLine(NewReceipt.PrintReceipt());

            Console.ReadLine();
        }

        private static void OrderInput()
        {
            Console.WriteLine("What is your ID?");
            int ID;
            int.TryParse(Console.ReadLine(), out ID);
            NewReceipt.CustomerID = ID;


            Console.WriteLine("How many COGS?");
            int COGS;
            int.TryParse(Console.ReadLine(), out COGS);
            NewReceipt.CogQuantity = COGS;

            Console.WriteLine("How many Gear");
            int Gear;
            int.TryParse(Console.ReadLine(), out Gear);
            NewReceipt.GearQauntity = Gear;

            if (Receipts.ContainsKey(ID) == false)
            {
                Receipts.Add(ID, new List<Receipt>());
            }
            Receipts[ID].Add(NewReceipt);

            AskForAnother();
        }

        private static void AskForAnother()
        {
            Console.WriteLine("Do you have another recipt? (Y/N)");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    OrderInput();
                    break;
                case "n":
                    AskForComand();
                    break;
            }
            return;

        }

        private static void AskForComand()
        {
            Console.WriteLine("Would you like to: \n 1)Print all receipts based off of a customer ID \n 2) Print all receipts for the day \n 3) Print the receipt for the sale that had the highest total");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("What ID?");
                    int.TryParse(Console.ReadLine(), out int ID);
                    PrintCustomerID(Receipts, ID);
                    break;
                case "2":
                    PrintAllReceipts(Receipts);
                    break;
                case "3":
                    HighestTotal();
                    break;

            }

            Console.WriteLine("Would you like another command (Y/N)");
            string InputResponse = Console.ReadLine().ToLower();
            AnotherCommand(InputResponse);
        }

        private static void AnotherCommand(string inputResponse)
        {
            switch (inputResponse)
            {
                case "y":
                    AskForComand();
                    break;
                case "n":
                    Console.WriteLine("Goodbye");
                    break;
            }
        }

        private static void HighestTotal()
        {
            Console.WriteLine("Highest Total");
        }

        private static void PrintAllReceipts(Dictionary<int, List<Receipt>> receipts)
        {
            foreach (var customer in receipts.Keys)
            {
                foreach (var receipt in receipts[customer])
                {
                    Console.Write($"{receipt.PrintReceipt()}");
                }
            }
        }

        private static void PrintCustomerID(Dictionary<int, List<Receipt>>receipts, int id)
        {
            if (receipts.ContainsKey(id) == false)
            {
                Console.WriteLine("Sorry this doesn't contain that ID");
            }
            else
            {
                foreach (var receipt in receipts[id])
                {

                    Console.WriteLine($"{receipt.PrintReceipt()}");
                }
            }
        }
    }
}
