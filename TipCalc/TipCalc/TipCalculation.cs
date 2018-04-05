using System;
namespace TipCalc
{
    public class TipCalculation
    {

        double amount, tip, tax;

        public double Amount { get { return amount; } set { amount = value; } }
        public double Tip { get { return tip; } set { tip = value; } }
        public double Tax { get { return tax; } set { tax = value; } }

        public double GetTipAmount()
        {
            double result = 0;
            if (tip != 0)
                result = amount * tip / 100;
            return result;
        }
        public double GetTaxAmount()
        {
            double result = 0;
            if (tax != 0)
                result = amount * tax / 100;
            return result;
        }

        public double GetTotalAmount()
        {
            double result = amount;
            if (tax != 0)
                result += amount * tax / 100;
            if (tip != 0)
                result += amount * tip / 100;

            return result;

        }
    }
}
