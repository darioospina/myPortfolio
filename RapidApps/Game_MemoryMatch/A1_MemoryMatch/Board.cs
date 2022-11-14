using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace A1_MemoryMatch
{
    public partial class Board : Form
    {
        // Variables for the environment
        static GameMethods nGM = new GameMethods();
        Player p1 = new Player();
        Player p2 = new Player();

        // This variables relate to the two cards selected on each turn
        List<int> pairsSelected = new List<int>();
        private int num1 = 0;
        private int num2 = 0;

        public List<Card> newGameP1 = nGM.addCards();
        public List<Card> newGameP2 = nGM.addCards();


        public Board()
        {
            InitializeComponent();
        }

        private void CardSelection(object sender, EventArgs e)
        {
            Button CardSelected = (Button)sender;

            pairsSelected.Add(Int32.Parse(CardSelected.Name.Substring(3)) - 1);

            if(p1.Pairs < 10 && p1.PlayerTurn == true)
            {
                lblPlayer1.ForeColor = Color.Green;

                setTurnGI(pairsSelected, CardSelected, newGameP1, p1);
                if(p1.Pairs == 10)
                {
                    p1.PlayerTurn = false;
                    p2.PlayerTurn = true;
                    restartInterface();
                }
            }

            if (p2.Pairs < 10 && p2.PlayerTurn == true)
            {
                lblPlayer1.ForeColor = Color.Black;
                lblPlayer2.ForeColor = Color.Green;

                setTurnGI(pairsSelected, CardSelected, newGameP2, p2);
                if(p2.Pairs == 10)
                {
                    p2.PlayerTurn = false;
                    btnPlay.Text = "Play again";
                    btnPlay.Enabled = true;
                    btnPlay.BackColor = Color.Gold;

                    if(p1.Moves < p2.Moves)
                    {
                        lbl_winner.Text = "Player 1 won!!";
                    } else if(p2.Moves < p1.Moves)
                    {
                        lbl_winner.Text = "Player 2 won!!";
                    } else if(p1.Moves == p2.Moves)
                    {
                        lbl_winner.Text = "We have a tie. Try again.";
                    }
                    lbl_winner.Visible = true;
                }
            }


            lblMovesP1.Text = "Moves: " + p1.Moves.ToString();
            lblMovesP2.Text = "Moves: " + p2.Moves.ToString();

            lblPairsP1.Text = "Pairs: " + p1.Pairs.ToString();
            lblPairsP2.Text = "Pairs: " + p2.Pairs.ToString();
        }

        private void setTurnGI (List<int> pairsSelected, Button CardSelected, List<Card> newGamePlayer, Player player)
        {
            if (pairsSelected.Count == 1)
            {
                num1 = pairsSelected[0];
                CardSelected.Text = newGamePlayer[pairsSelected[0]].Back.ToString();
            }
            if (pairsSelected.Count == 2)
            {
                num2 = pairsSelected[1];
                CardSelected.Text = newGamePlayer[pairsSelected[1]].Back.ToString();
                Task time = Task.Delay(1000);
                time.Wait();

                if (nGM.checkIfPaired(newGamePlayer, num1, num2, player))
                {
                    foreach (var button in this.Controls.OfType<Button>())
                    {
                        if (button.Text.Equals(CardSelected.Text.ToString()))
                        {
                            button.Visible = false;
                        }
                    }
                }

                pairsSelected.Clear();
                hideCards(newGamePlayer);
            }
        }
        private void Board_Load(object sender, EventArgs e)
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                if(!button.Text.Equals("Play"))
                {
                    button.Enabled = false;
                }
            }
            lbl_winner.Visible = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            p1.Pairs = 0;
            p2.Pairs = 0;
            p1.Moves = 0;
            p2.Moves = 0;

            lblPlayer1.ForeColor = Color.Green;
            lblPlayer2.ForeColor = Color.Black;

            lbl_winner.Visible = false;

            lblMovesP1.Text = "Moves: " + p1.Moves.ToString();
            lblMovesP2.Text = "Moves: " + p2.Moves.ToString();

            lblPairsP1.Text = "Pairs: " + p1.Pairs.ToString();
            lblPairsP2.Text = "Pairs: " + p2.Pairs.ToString();

            foreach (var button in this.Controls.OfType<Button>())
            {
                if (!button.Text.Equals("Play"))
                {
                    button.Enabled = true;
                    button.Visible = true;
                }
            }
            p1.PlayerTurn = true;
            p2.PlayerTurn = false;

            btnPlay.Enabled = false;
            btnPlay.BackColor = Color.WhiteSmoke;

            showCards(newGameP1);
            Task time = Task.Delay(4000);
            time.Wait();
            hideCards(newGameP1);
        }
        private void showCards(List<Card> listOfCards)
        {
            btn1.Text = listOfCards[0].Back.ToString();
            btn2.Text = listOfCards[1].Back.ToString();
            btn3.Text = listOfCards[2].Back.ToString();
            btn4.Text = listOfCards[3].Back.ToString();
            btn5.Text = listOfCards[4].Back.ToString();
            btn6.Text = listOfCards[5].Back.ToString();
            btn7.Text = listOfCards[6].Back.ToString();
            btn8.Text = listOfCards[7].Back.ToString();
            btn9.Text = listOfCards[8].Back.ToString();
            btn10.Text = listOfCards[9].Back.ToString();
            btn11.Text = listOfCards[10].Back.ToString();
            btn12.Text = listOfCards[11].Back.ToString();
            btn13.Text = listOfCards[12].Back.ToString();
            btn14.Text = listOfCards[13].Back.ToString();
            btn15.Text = listOfCards[14].Back.ToString();
            btn16.Text = listOfCards[15].Back.ToString();
            btn17.Text = listOfCards[16].Back.ToString();
            btn18.Text = listOfCards[17].Back.ToString();
            btn19.Text = listOfCards[18].Back.ToString();
            btn20.Text = listOfCards[19].Back.ToString();
        }
        private void hideCards(List<Card> listOfCards)
        {
            btn1.Text = listOfCards[0].Front.ToString();
            btn2.Text = listOfCards[1].Front.ToString();
            btn3.Text = listOfCards[2].Front.ToString();
            btn4.Text = listOfCards[3].Front.ToString();
            btn5.Text = listOfCards[4].Front.ToString();
            btn6.Text = listOfCards[5].Front.ToString();
            btn7.Text = listOfCards[6].Front.ToString();
            btn8.Text = listOfCards[7].Front.ToString();
            btn9.Text = listOfCards[8].Front.ToString();
            btn10.Text = listOfCards[9].Front.ToString();
            btn11.Text = listOfCards[10].Front.ToString();
            btn12.Text = listOfCards[11].Front.ToString();
            btn13.Text = listOfCards[12].Front.ToString();
            btn14.Text = listOfCards[13].Front.ToString();
            btn15.Text = listOfCards[14].Front.ToString();
            btn16.Text = listOfCards[15].Front.ToString();
            btn17.Text = listOfCards[16].Front.ToString();
            btn18.Text = listOfCards[17].Front.ToString();
            btn19.Text = listOfCards[18].Front.ToString();
            btn20.Text = listOfCards[19].Front.ToString();
        }

        private void restartInterface()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                if (!button.Text.Equals("Play"))
                {
                    button.Enabled = true;
                    button.Visible = true;
                }
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dario-ospina.com");
        }
    }
}
