using System;
namespace Lab5
{
    public class TicTacToeGame
    {
        const int MAX = 9;
        public char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };




        public void SetChoice(int player, int i)
        {
            if (player == 1)  // user's choice
                arr[i] = 'X';
            else              // computer's choice
                arr[i] = 'O';


        }
        public int ComputerChoice()
        {
            

            Random rnd = new Random();
            int choice = 0;
            do
            {
                choice = rnd.Next(1, MAX);

            } while (!CheckChoice(choice));


            SetChoice(2, choice);
            return choice;

        }
        private bool CheckChoice(int i)
        {
            if (arr[i] != 'O' && arr[i] != 'X' )
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {

            for (int i = 1; i <= MAX; i++)
                arr[i] = Convert.ToChar(48+i);
            
        }
        public int CheckWin()

        {

            #region Horzontal Winning Condtion

            //Winning Condition For First Row   

            if (arr[1] == arr[2] && arr[2] == arr[3])

            {

                return 1;

            }

            //Winning Condition For Second Row   

            else if (arr[4] == arr[5] && arr[5] == arr[6])

            {

                return 1;

            }

            //Winning Condition For Third Row   

            else if (arr[7] == arr[8] && arr[8] == arr[9])

            {

                return 1;

            }

            #endregion



            #region vertical Winning Condtion

            //Winning Condition For First Column       

            else if (arr[1] == arr[4] && arr[4] == arr[7])

            {

                return 1;

            }

            //Winning Condition For Second Column  

            else if (arr[2] == arr[5] && arr[5] == arr[8])

            {

                return 1;

            }

            //Winning Condition For Third Column  

            else if (arr[3] == arr[6] && arr[6] == arr[9])

            {

                return 1;

            }

            #endregion



            #region Diagonal Winning Condition

            else if (arr[1] == arr[5] && arr[5] == arr[9])

            {

                return 1;

            }

            else if (arr[3] == arr[5] && arr[5] == arr[7])

            {

                return 1;

            }

            #endregion



            #region Checking For Draw

            // If all the cells or values filled with X or O then any player has won the match  

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')

            {

                return -1;

            }

            #endregion



            else

            {

                return 0;

            }

        }
    }
}
