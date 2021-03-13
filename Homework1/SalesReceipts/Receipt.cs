using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReceipts
{
    class Receipt
    {
        public int CustomerID {get; set;}
        public int CogQuantity {get; set;}
        public int GearQauntity {get; set;}
        public DateTime SaleDate {get; set;}
        public double SalesTaxPercent {get; set;}
        public double CogPrice {get; set;}
        public double GearPrice { get; set; }


        public Receipt()
        {
            CustomerID = 0;
            CogQuantity = 0;
            GearQauntity = 0;
            SaleDate = DateTime.Now;
            SalesTaxPercent = .089;
            CogPrice = 79.99;
            GearPrice = 250.00;

        }

        Receipt (int id, int cog, int gear)
        {
            id = CustomerID;
            cog = CogQuantity;
            gear = GearQauntity;
        }

        public string PrintReceipt()
        {
            return $" ID: {CustomerID}\nCOG: {CogQuantity}\nGear: {GearQauntity}\nNet Total: {CalculateNetAmount()}\nTax Amount: {CalculateTaxAmount()}\nTotal: {CalculateTotal()}";

        }
        public double CalculateTotal()
        {
            double NetAmount = CalculateNetAmount();
            double TaxAmount = CalculateTaxAmount();
            double total = NetAmount + TaxAmount;
            
            return total;

        }
        public double CalculateTaxAmount()
        {
            double TaxAmount;

            double NetAmount = CalculateNetAmount();

            TaxAmount = NetAmount * SalesTaxPercent;
            
            return TaxAmount;
        }
        public double CalculateNetAmount()
        {
            int TotalQuantity = CogQuantity + GearQauntity;
            bool WholeSale = false;
            double MarkupPrice = .015;
            if (CogQuantity > 10 || GearQauntity > 10)
            {
                WholeSale = true;
            }
            else if (TotalQuantity == 16)
            {
                WholeSale = true;
            }
            if (WholeSale == true)
            {
                MarkupPrice = .0125;
            }


            return ((CogQuantity * MarkupPrice) * CogPrice) + ((GearPrice*MarkupPrice) * GearQauntity);
        }
    }
}
