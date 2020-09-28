using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyBirdGameApp
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvents(object sender, EventArgs e)
        {
           
                floppyBird.Top += gravity;
                pipeBottom.Left -= pipeSpeed;
                pipeTop.Left -= pipeSpeed;
                scoreText.Text = "Score: " + score;

                if (pipeBottom.Left < -150)
                {
                    pipeBottom.Left = 1000;
                    score++;
                }
                if (pipeTop.Left < -180)
                {
                    pipeTop.Left = 1150;
                    score++;
                }

                if (floppyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                    floppyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    floppyBird.Bounds.IntersectsWith(ground.Bounds) ||
                    floppyBird.Top < -25
                    )
                {
                    endGame();
                }

                if (score > 10)
                {
                    pipeSpeed = 15;
                }
            
            


        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over!!!";
        }

        private void gameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().ToUpper() == Keys.P.ToString())
            {
                gameTimer.Stop();
            }
            else if (e.KeyChar.ToString().ToUpper() == Keys.S.ToString())
            {
                gameTimer.Start();
            }
            else
            {

            }
        }
    }
}
