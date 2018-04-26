using System;
namespace TipCalc
{
    public class TipCalculation
    {

        double amount, tax;
        int tip;

        public double Amount { get { return amount; } set { amount = value; } }
        public int Tip { get { return tip; } set { tip = value; } }
        public double Tax { get { return tax; } set { tax = value; } }

        //get tip amount in dollar
        public double GetTipAmount()
        {
            double result = 0;
            if (tip != 0)
                result = amount * tip / 100;
            return Math.Round(result, 2);
        }
        //Get tax amount in dollar
        public double GetTaxAmount()
        {
            double result = 0;
            if (tax != 0)
                result = amount * tax / 100;
            return Math.Round(result,2);
        }
        //Get total amount of payment
        public double GetTotalAmount()
        {
            double result = amount + GetTaxAmount() + GetTipAmount();

            return Math.Round(result,2);

        }
    }
}
