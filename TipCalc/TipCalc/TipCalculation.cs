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

        public double GetTipAmount()
        {
            double result = 0;
            if (tip != 0)
                result = amount * tip / 100;
            return Math.Round(result, 2);
        }
        public double GetTaxAmount()
        {
            double result = 0;
            if (tax != 0)
                result = amount * tax / 100;
            return Math.Round(result,2);
        }

        public double GetTotalAmount()
        {
            double result = amount;
            if (tax != 0)
                result += amount * tax / 100;
            if (tip != 0)
                result += amount * tip / 100;

            return Math.Round(result,2);

        }
    }
}
