using System;

using UIKit;

namespace Lab5
{
    public partial class ViewController : UIViewController
    {

        TicTacToeGame tictactoe = new TicTacToeGame();
        int gameCount = 0;
        int winCount = 0;
        int lossCount = 0;

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

        partial void TouchUpInsideEachButton(UIButton sender)
        {
            
            UIButton button = (UIButton)sender;

            UIViewController controller;
            if (button.TitleLabel.Text == "About")
            {
                // Create the destination controller object
                controller = this.Storyboard.InstantiateViewController("AboutViewController") as AboutViewController;
                // This is how we communicate the user name to the destination controller
                //((HelloViewController)controller).UserName = userName;
            }
            else    // the "History" button was tapped
            {
                controller = this.Storyboard.InstantiateViewController("HistoryViewController") as HistoryViewController;
                ((HistoryViewController)controller).winCount = winCount;
                ((HistoryViewController)controller).lossCount = lossCount;
                ((HistoryViewController)controller).gameCount = gameCount;

            }

            /*
            // Use a transition animation
            UIView.BeginAnimations("AboutHistory");
            UIView.SetAnimationDuration(0.5);
            //UIView.SetAnimationTransition(UIViewAnimationTransition.FlipFromLeft, controller.View, true);
            UIView.SetAnimationTransition(UIViewAnimationTransition.FlipFromLeft, controller.View, true);
            UIView.CommitAnimations();
            */
            this.PresentViewController(controller, true, null);
            // Switch scenes
            //this.NavigationController.PushViewController(controller, true);
        }

        partial void ResetButton_TouchUpInside(UIButton sender)
        {
            tictactoe.Reset();
            ResetBoard();
        }

        void handler(object sender, EventArgs args)
        {
            UIButton button = (UIButton)sender;

            UpdateButton(button, "X", false);               //update the user selected button("X")


            tictactoe.SetChoice(1, (int)button.Tag);        //set user's choice

            //int result = tictactoe.CheckWin();
            int result = CheckResult(0);    //check the result of user's choice
                
            if (result == 0)   //if the game is not over yet, get the computer choice
            {
                //get the computer choice
                int compChoice = tictactoe.ComputerChoice();
                //update a Button of computer choose
                switch (compChoice)         //update the button that computer choose ("O")
                {
                    case 1: 
                        UpdateButton(Button1, "O", false);
                        break;
                    case 2:
                        UpdateButton(Button2, "O", false);
                        break;
                    case 3:
                        UpdateButton(Button3, "O", false);
                        break;
                    case 4:
                        UpdateButton(Button4, "O", false);
                        break;
                    case 5:
                        UpdateButton(Button5, "O", false);
                        break;
                    case 6:
                        UpdateButton(Button6, "O", false);
                        break;
                    case 7:
                        UpdateButton(Button7, "O", false);
                        break;
                    case 8:
                        UpdateButton(Button8, "O", false);
                        break;
                    case 9:
                        UpdateButton(Button9, "O", false);
                        break;
                 
                    default:
                        break;
                }


                result = CheckResult(1); //check the result of computer's choice
             

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
            UpdateButton(Button1, "", true);
            UpdateButton(Button2, "", true);
            UpdateButton(Button3, "", true);
            UpdateButton(Button4, "", true);
            UpdateButton(Button5, "", true);
            UpdateButton(Button6, "", true);
            UpdateButton(Button7, "", true);
            UpdateButton(Button8, "", true);
            UpdateButton(Button9, "", true);

        }

        //update button's title and status based on inputs
        void UpdateButton(UIButton button, string title, bool enabled)
        {


            button.SetTitle(title, UIControlState.Normal);
            button.SetTitle(title, UIControlState.Disabled);
            button.Enabled = enabled;
        }

        //checks result and display message if the game is over
        int CheckResult(int player)
        {
            int result = tictactoe.CheckWin();      // result 0 - not over

            if (result != 0)    // game's over      
            {
                string resultMsg = "";
                gameCount++;

                if (result == 1)            // result 1 - current player won
                {
                    if (player == 0)    // if current player is user
                    {
                        winCount++;
                        resultMsg = "You won!";
                    }
                    else    // if current player is user
                    {
                        lossCount++;
                        resultMsg = "Computer won!";
                    }
                }
                else if (result == -1)      // result -1  - draw
                    resultMsg = "Draw!!";


                DisplayResult(resultMsg);
                DisableInputs();


            }


            return result;

        }
    }
}
