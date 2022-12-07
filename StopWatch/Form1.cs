using System.Diagnostics;

namespace StopWatch
{
    public partial class Form1 : Form
    {
        public static Stopwatch watch = new Stopwatch();
        private Random random = new Random();
        private int hits = 0;
        private int lives = 3;
        private int highScore = 0;
        private int hitStreak = 0;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            watch.Start();
            timer1.Enabled = true;
            buttonTarget.Visible = true;
            label2.Text = "Hits: 0";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            watch.Stop();
            timer1.Enabled = false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            watch.Reset();
            timer1.Enabled = false;
            hits = 0;
            lives = 3;
            label1.Text = "Timer: 0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Timer: " + watch.Elapsed.TotalSeconds.ToString("F0");
            label3.Text = "Lives: " + lives;


            if (int.Parse(watch.Elapsed.TotalSeconds.ToString("F0")) > 45)
            {
                if (random.Next(0, 10) > 6)
                {
                    buttonTarget.Left = random.Next(0, this.Width);
                    buttonTarget.Top = random.Next(0, this.Height);
                    buttonTarget.Visible = true;
                    btnFalse.Visible = false;
                }
                if (random.Next(0, 10) <= 6)
                {
                    btnFalse.Left = random.Next(0, this.Width);
                    btnFalse.Top = random.Next(0, this.Height);
                    btnFalse.Visible = true;
                    buttonTarget.Visible = false;
                }
            }

            else if (int.Parse(watch.Elapsed.TotalSeconds.ToString("F0")) > 30)
            {
                if (random.Next(0, 10) >= 5)
                {
                    buttonTarget.Left = random.Next(0, this.Width);
                    buttonTarget.Top = random.Next(0, this.Height);
                    buttonTarget.Visible = true;
                    btnFalse.Visible = false;
                }
                if (random.Next(0, 10) < 5)
                {
                    btnFalse.Left = random.Next(0, this.Width);
                    btnFalse.Top = random.Next(0, this.Height);
                    btnFalse.Visible = true;
                    buttonTarget.Visible = false;
                }
            }

            else if (int.Parse(watch.Elapsed.TotalSeconds.ToString("F0")) > 15)
            {
                if(random.Next(0, 10) >= 5)
                {
                    buttonTarget.Left = random.Next(0, this.Width);
                    buttonTarget.Top = random.Next(0, this.Height);
                    buttonTarget.Visible = true;
                    btnFalse.Visible = false;
                }
                if (random.Next(0, 10) <= 3)
                {
                    btnFalse.Left = random.Next(0, this.Width);
                    btnFalse.Top = random.Next(0, this.Height);
                    btnFalse.Visible = true;
                    buttonTarget.Visible = false;
                }
            }
            else if (int.Parse(watch.Elapsed.TotalSeconds.ToString("F0")) >= 0)
            {
                if (random.Next(0, 10) >= 5)
                {
                    buttonTarget.Left = random.Next(0, this.Width);
                    buttonTarget.Top = random.Next(0, this.Height);
                    buttonTarget.Visible = true;
                    btnFalse.Visible = false;
                }
                if (random.Next(0, 10) < 2)
                {
                    btnFalse.Left = random.Next(0, this.Width);
                    btnFalse.Top = random.Next(0, this.Height);
                    btnFalse.Visible = true;
                    buttonTarget.Visible = false;
                }
            }

            if (gameEnd())
            {
                btnPlayAgain.Visible = true;
                btnQuit.Visible = true;
                buttonReset.Visible = false;
                buttonStart.Visible = false;
                buttonStop.Visible = false;
                buttonTarget.Visible = false;
            }
        }

        private void buttonTarget_Click(object sender, EventArgs e)
        {
            buttonTarget.Visible = false;
            hits++;
            hitStreak++;
            if (hitStreak == 10)
            {
                lives = lives + 1;
                hitStreak = 0;
            }
            label2.Text = "Hits: " + hits;
        }

        private bool gameEnd()
        {
            // If player loses all lives
            if (lives <= 0)
            {
                label1.Text = "Timer: 0";
                watch.Reset();
                timer1.Enabled = false;
                MessageBox.Show("Game over! All lives lost.");

                if (hits > highScore)
                {
                    highScore = hits;
                }
                hits = 0;
                lives = 3;


                return true;
            }

            // If timer hits 60sec
            else if (int.Parse(watch.Elapsed.TotalSeconds.ToString("F0")) == 60)
            {
                lives = 3;
                label1.Text = "Timer: 0";
                watch.Reset();
                timer1.Enabled = false;
                MessageBox.Show("Time's up!, You got " + hits + " hits!");

                if (hits > highScore)
                {
                    highScore = hits;
                }
                hits = 0;
                lives = 3;


                return true;
            }
            return false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            lives--;
            hitStreak = 0;
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            // Reset timer and variables
            watch.Reset();
            timer1.Enabled = false;
            hits = 0;
            lives = 3;
            label1.Text = "Timer: 0";
            label4.Text = "High Score: " + highScore;

            // Reset form display;
            btnPlayAgain.Visible = false;
            btnQuit.Visible = false;
            buttonReset.Visible = true;
            buttonStart.Visible = true;
            buttonStop.Visible = true;

            // Start game
            watch.Start();
            timer1.Enabled = true;
            buttonTarget.Visible = true;
            label2.Text = "Hits: 0";
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFalse_Click(object sender, EventArgs e)
        {
            lives--;
            hitStreak = 0;
        }
    }
}