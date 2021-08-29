using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class MemoryGame : Form
    {

        Label first, second;  // first and second Square clicked
        Random random = new Random();
        int movesMade = 0; // number of pairs User has guessed
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch(); 

        public MemoryGame()
        {
            InitializeComponent();
            StartGame();
        }


        private List<char> generatePictures()
        {
            Random random = new Random();
            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();
            while (candidates.Count < 8)
            {
                // May strike a duplicate.
                candidates.Add(random.Next(34,126));
            }

            // load them in to a list.
            List<int> result = new List<int>();
            result.AddRange(candidates);

            // shuffle the results:
            int i = result.Count;
            while (i > 1)
            {
                i--;
                int k = random.Next(i + 1);
                int value = result[k];
                result[k] = result[i];
                result[i] = value;
            }
            List<char> pictures = new List<char>();
            for(int p = 0;p < result.Count; p++)
            {
                pictures.Add((char)result[p]);
                pictures.Add((char)result[p]);
            }
            return pictures;
        }

        
        private void label_click(object sender, EventArgs e)  // event when Player clicks a Square
        {
            if (first != null && second != null)
                return;

            Label clicked = sender as Label;
            if (clicked == null)
                return;

            if (clicked.ForeColor == Color.Black)
                return;

            if (first == null)
            {
                first = clicked;
                first.ForeColor = Color.Black;
                return;
            }

            second = clicked;
            second.ForeColor = Color.Black;

            movesMade++;
            CheckWin();
            

            if(first.Text == second.Text)
            {
                first = null;
                second = null;
            }
            else
                timer1.Start();
            lblNumberMoves.Text = movesMade.ToString();
           
        }

        private void timer1_Tick(object sender, EventArgs e) //  amount of time for two mismatched continously clicked squares to stay turned over
        {
            timer1.Stop();
            first.ForeColor = Color.OrangeRed;
            second.ForeColor = Color.OrangeRed;
            first = null;
            second = null;
        }

        


        private void StartGame()
        {
            if (timer.IsRunning)
            {
                timer.Stop();           
            }
            movesMade = 0;
            lblNumberMoves.Text = 0.ToString();
            lblTime.Text = "00:00:00";
            timer.Reset();

            if (lblTime.Text == "00:00:00")
                timer.Start();
            Label temp;
            int rand;
            List<char> pictures = generatePictures();
            

            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    temp = (Label)tableLayoutPanel1.Controls[i];
                }
                else
                    continue;

                rand = random.Next(0, pictures.Count);
                temp.Text = pictures[rand].ToString();
                temp.ForeColor = Color.OrangeRed;

                pictures.RemoveAt(rand);

            }
        }

        

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer.Elapsed.ToString() != "00:00:00")
                lblTime.Text = timer.Elapsed.ToString().Remove(8);
            
          
        }


        private void newGame_Click(object sender, EventArgs e)
        {
            
            StartGame();
        }

        private void CheckWin()
        {
            Label temp;
            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                temp = tableLayoutPanel1.Controls[i] as Label;
                if(temp != null && temp.ForeColor != Color.Black)
                {
                    return;
                }
               
            }
            timer.Stop();
            DialogResult result = MessageBox.Show("You matched all the icons! Congrats!New Game?", "You won!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                
                StartGame();
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
            
            
        }
    }
}
