using System;

using UIKit;

namespace TicTacToe
{
    public partial class ViewController : UIViewController
    {

        TicTacToeGame tictactoe = new TicTacToeGame();
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

           
            Button1.TouchDown += handler;
            Button2.TouchDown += handler;
            Button3.TouchDown += handler;
            Button4.TouchDown += handler;
            Button5.TouchDown += handler;
            Button6.TouchDown += handler;
            Button7.TouchDown += handler;
            Button8.TouchDown += handler;
            Button9.TouchDown += handler;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void ResetButton_TouchUpInside(UIButton sender)
        {
            tictactoe.Reset();
            ResetBoard();
        }

        void handler(object sender, EventArgs args)
        {
            UIButton button = (UIButton)sender;

            UpdateButton(button, "X", false);


            tictactoe.SetChoice(1, (int)button.Tag);

            int result = tictactoe.CheckWin();

            if (result != 0)
            {
                string resultMsg="";
                if (result == 1)
                    resultMsg = "You won!!";
                else if (result == -1)
                    resultMsg = "Draw!!";
                

                DisplayResult(resultMsg);
                DisableInputs();
            }
            else
            {
                
                int compChoice = tictactoe.ComputerChoice();
                switch (compChoice)
                {
                    case 1: 
                        UpdateButton(button, "O", false);
                        break;
                    case 2:
                        Button2.SetTitle("O", UIControlState.Normal);
                        Button2.SetTitle("O", UIControlState.Disabled);
                        Button2.Enabled = false;
                        break;
                    case 3:
                        Button3.SetTitle("O", UIControlState.Normal);
                        Button3.SetTitle("O", UIControlState.Disabled);
                        Button3.Enabled = false;
                        break;
                    case 4:
                        Button4.SetTitle("O", UIControlState.Normal);
                        Button4.SetTitle("O", UIControlState.Disabled);
                        Button4.Enabled = false;
                        break;
                    case 5:
                        Button5.SetTitle("O", UIControlState.Normal);
                        Button5.SetTitle("O", UIControlState.Disabled);
                        Button5.Enabled = false;
                        break;
                    case 6:
                        Button6.SetTitle("O", UIControlState.Normal);
                        Button6.SetTitle("O", UIControlState.Disabled);
                        Button6.Enabled = false;
                        break;
                    case 7:
                        Button7.SetTitle("O", UIControlState.Normal);
                        Button7.SetTitle("O", UIControlState.Disabled);
                        Button7.Enabled = false;
                        break;
                    case 8:
                        Button8.SetTitle("O", UIControlState.Normal);
                        Button8.SetTitle("O", UIControlState.Disabled);
                        Button8.Enabled = false;
                        break;
                    case 9:
                        Button9.SetTitle("O", UIControlState.Normal);
                        Button9.SetTitle("O", UIControlState.Disabled);
                        Button9.Enabled = false;
                        break;
                 
                    default:
                        break;
                }

                result = tictactoe.CheckWin();
                if (result != 0)
                {
                    string resultMsg = "";

                    if (result == 1)
                        resultMsg = "Computer won!!";
                    else if (result == -1)
                        resultMsg = "Draw!!";

                    DisplayResult(resultMsg);
                    DisableInputs();
                }

            }


        }

        void DisplayResult(string resultMsg)
        {
            var alert = UIAlertController.Create("Game over", resultMsg, UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        void DisableInputs()
        {

            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            Button7.Enabled = false;
            Button8.Enabled = false;
            Button9.Enabled = false;

        }

        void ResetBoard()
        {
            Button1.SetTitle("", UIControlState.Normal);
            Button1.SetTitle("", UIControlState.Disabled);
            Button1.Enabled = true;
            Button2.SetTitle("", UIControlState.Normal);
            Button2.SetTitle("", UIControlState.Disabled);
            Button2.Enabled = true;
            Button3.SetTitle("", UIControlState.Normal);
            Button3.SetTitle("", UIControlState.Disabled);
            Button3.Enabled = true;
            Button4.SetTitle("", UIControlState.Normal);
            Button4.SetTitle("", UIControlState.Disabled);
            Button4.Enabled = true;
            Button5.SetTitle("", UIControlState.Normal);
            Button5.SetTitle("", UIControlState.Disabled);
            Button5.Enabled = true;
            Button6.SetTitle("", UIControlState.Normal);
            Button6.SetTitle("", UIControlState.Disabled);
            Button6.Enabled = true;
            Button7.SetTitle("", UIControlState.Normal);
            Button7.SetTitle("", UIControlState.Disabled);
            Button7.Enabled = true;
            Button8.SetTitle("", UIControlState.Normal);
            Button8.SetTitle("", UIControlState.Disabled);
            Button8.Enabled = true;
            Button9.SetTitle("", UIControlState.Normal);
            Button9.SetTitle("", UIControlState.Disabled);
            Button9.Enabled = true;

        }

        void UpdateButton(UIButton button, string title, bool enabled)
        {


            button.SetTitle(title, UIControlState.Normal);
            button.SetTitle(title, UIControlState.Disabled);
            button.Enabled = enabled;
        }

    }
}
