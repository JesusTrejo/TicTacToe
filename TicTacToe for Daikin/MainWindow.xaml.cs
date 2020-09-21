using System.Windows;
using System.Windows.Controls;


namespace TicTacToe_for_Daikin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Player 1 = X, Player 2 = O
        private Button[,] Cells = new Button[3, 3];
        private int ActivePlayer = 1; // Player 1 always starts
        private int Movements = 0;

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Cells[i, j] = (Button)this.FindName("Btn" + i + j);
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (ActivePlayer == 1)
                btn.Content = "X";
            else
                btn.Content = "O";


            btn.IsEnabled = false;

            bool won = CurrentPlayerWon();


            if (won)
            {
                MessageBox.Show("Player " + ActivePlayer + " wins!");
                ResetBoard();
            }
            else
            {
                ActivePlayer = ActivePlayer == 1 ? 2 : 1;
                PlayerLabel.Content = "Player " + ActivePlayer + " turn";

                Movements++;

                if (Movements >= 9)
                {
                    MessageBox.Show("Tie!");
                    ResetBoard();
                }


            }




        }

        private bool CurrentPlayerWon()
        {
            // It'd be way faster to just check the row/col and diagonal of the last move
            // Let's just check the whole board for simplicity

            int lineval = 0;

            // Check for columns
            for (int i = 0; i < 3; i++)
            {
                lineval = 0;

                for (int j = 0; j < 3; j++)
                {
                    if ((string)(Cells[j, i].Content) == "X")
                        lineval += 1;
                    else
                    if ((string)(Cells[j, i].Content) == "O")
                        lineval -= 1;
                }

                if (lineval == 3 || lineval == -3)
                    return true;
            }

            // Check for rows
            for (int i = 0; i < 3; i++)
            {
                lineval = 0;

                for (int j = 0; j < 3; j++)
                {
                    if ((string)(Cells[i, j].Content) == "X")
                        lineval += 1;
                    else
                    if ((string)(Cells[i, j].Content) == "O")
                        lineval -= 1;
                }

                if (lineval == 3 || lineval == -3)
                    return true;
            }

            // Check diagonals
            lineval = 0;
            for (int i = 0; i < 3; i++)
            {
                if ((string)(Cells[i, i].Content) == "X")
                    lineval += 1;
                else
                        if ((string)(Cells[i, i].Content) == "O")
                    lineval -= 1;
            }
            if (lineval == 3 || lineval == -3)
                return true;


            lineval = 0;
            for (int i = 0; i < 3; i++)
            {
                if ((string)(Cells[i, 3 - i - 1].Content) == "X")
                    lineval += 1;
                else
                        if ((string)(Cells[i, 3 - i - 1].Content) == "O")
                    lineval -= 1;
            }
            if (lineval == 3 || lineval == -3)
                return true;



            return false;
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Cells[i, j].Content = "";
                    Cells[i, j].IsEnabled = true;
                }


            ActivePlayer = 1;
            PlayerLabel.Content = "Player 1 turn";
            Movements = 0;
        }
    }
}

