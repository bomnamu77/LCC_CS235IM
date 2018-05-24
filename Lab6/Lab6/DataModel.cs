using System;
using UIKit;

namespace Lab6
{
    public class DataModel : UIPickerViewModel
    {
        private string[] gameNames = {"PacMan", "Loom", "Tetris",
            "Street Fighter", "WarCraft", "MineCraft"};

        private UILabel gameLabel;

        public DataModel(UILabel gameLabel)
        {
            this.gameLabel = gameLabel;
        }

        // The number returned determines the number of rings in the picker
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return gameNames.Length;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (component == 0)
                return gameNames[row];
            else
                return row.ToString();
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            gameLabel.Text = gameNames[pickerView.SelectedRowInComponent(0)];
        }

        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            // there is only one component, this is it's width setting
            return 240f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }
}
