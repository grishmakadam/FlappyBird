using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 1;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            ScoreText.Text= "Score: "+score.ToString();

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180) 
            {
                pipeTop.Left = 800;
                score++;
            }
            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 15;
            }

            if (flappyBird.Top < -25)
            {
                endGame();
            }
        }

        private void endGame()
        {
            Timer.Stop();
            ScoreText.Text += " Game Over!!";
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }

        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
    } 
}
