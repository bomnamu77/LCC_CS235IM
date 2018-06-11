using System;
using UIKit;

namespace TermProject
{
    public class MonthModel : UIPickerViewModel
    {
        public string[] months = new string[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        public nint GetRowsByMonth(string month)
        {
            nint row = 0;
            for (int i = 0; i < months.Length; i++)
            {
                if (months[i] == month)
                    row = i;
            }

            return row;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return months.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (component == 0)
                return months[row];
            else
                return row.ToString();
        }


        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            if (component == 0)
                return 240f;
            else
                return 40f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }
}
