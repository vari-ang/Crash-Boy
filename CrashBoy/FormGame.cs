using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace CrashBoy
{
    public partial class FormGame : Form
    {
        FormHome frmHome;

        string resourcesPath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer hurtSound = new WindowsMediaPlayer();

        Ball ball;
        Food food;
        Block block;

        Label labelScore = new Label();
        public Label score = new Label();

        Label currScore = new Label();

        Label labelB1 = new Label();
        Label labelB2 = new Label();
        Label labelB3 = new Label();
        Label labelB4 = new Label();
        Label labelB5 = new Label();

        Label labelF1 = new Label();
        Label labelF2 = new Label();
        Label labelF3 = new Label();
        Label labelF4 = new Label();

        List<Label> listBLabel = new List<Label>();
        List<Label> listFLabel = new List<Label>();

        List<int> listBLabelText = new List<int>() { 0, 0, 0, 0, 0 };

        bool pauseClicked = false;

        int x = 0, y = 0;
        int b1X = 0, b2X = 0, b3X = 0, b4X = 0, b5X = 0,
            b1Y = 0, b2Y = 0, b3Y = 0, b4Y = 0, b5Y = 0,
            f1X = 0, f2X = 0, f3X = 0, f4X = 0,
            f1Y = 0, f2Y = 0, f3Y = 0, f4Y = 0,
            labelBW = 35,
            labelBH = 25,
            labelFW = 25,
            labelFH = 18;

        //private void FormGame_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    Console.WriteLine("CLICKED");
        //    if(e.KeyCode == Keys.Right)
        //    {
        //        Console.WriteLine("Clicked Right");
        //    }
        //    else if(e.KeyCode == Keys.Left)
        //    {
        //        Console.WriteLine("Clicked Left");
        //    }
        //}

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (pauseClicked) return; //To disable call to this method when pause is clicked

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                ball.MoveLeft();
                x -= ball.speed;
                currScore.Location = new Point(x, y);
                if (currScore.Location.X <= 0)
                {
                    x = 5;
                    currScore.Location = new Point(x, y);
                }
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                ball.MoveRight();
                x += ball.speed;
                currScore.Location = new Point(x, y);
                if (currScore.Location.X + 20 >= this.ClientRectangle.Width)
                {
                    x = this.ClientRectangle.Width - 20;
                    currScore.Location = new Point(x, y);
                }
            }
        }

        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;

            ball.DrawBall(graph);
            food.DrawFood(graph);
            block.DrawBlock(graph);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            x += 0;
            if(!pauseClicked)
            {
                buttonPause.BackgroundImage = CrashBoy.Properties.Resources.button_play;
                pauseClicked = true;
                timerGame.Enabled = false;
            }
            else
            {
                buttonPause.BackgroundImage = CrashBoy.Properties.Resources.button_pause;
                pauseClicked = false;
                timerGame.Enabled = true;
            }
        }

        public bool hit = false;
        int blockSpeed;

        public FormGame()
        {
            InitializeComponent();
        }

        public void FormGame_Load(object sender, EventArgs e)
        {
            frmHome = (FormHome)this.Owner;

            ball = new Ball(this.ClientRectangle.Width, this.ClientRectangle.Height);
            food = new Food(this.ClientRectangle.Width, this.ClientRectangle.Height);                   
            block = new Block(this.ClientRectangle.Width, this.ClientRectangle.Height);

            blockSpeed = block.speed;

            ShowBackground(frmHome.bgIndex);        

            labelScore.BackColor = System.Drawing.Color.Transparent;
            labelScore.Location = new Point(5, 5);
            labelScore.Text = "Score: ";
            labelScore.Width = 80;
            labelScore.Height = 25;
            labelScore.Font = new Font("Arial", 16);           

            score.BackColor = System.Drawing.Color.Transparent;
            score.Location = new Point(labelScore.Width, 5);
            score.Text = "0";
            score.Width = 150;
            score.Height = 25;
            score.Font = new Font("Arial", 16);         

            currScore.BackColor = System.Drawing.Color.Transparent;
            currScore.ForeColor = System.Drawing.Color.DimGray;
            x = this.ClientRectangle.Width / 2 + ball.d / 4;
            y = this.ClientRectangle.Height - 80 - 3 * ball.d / 4;
            currScore.Location = new Point(x, y);
            currScore.Text = "10";
            currScore.Width = 100;
            currScore.Height = 17;
            currScore.Font = new Font("Arial", 10, FontStyle.Bold);       

            /*** Change the text color so that it is visible ***/
            if (frmHome.bgIndex == 1 || 
                frmHome.bgIndex == 3 ||
                frmHome.bgIndex == 4) //index: 1 = black, 3 = undersea, 4 = space background
            {
                labelScore.ForeColor = System.Drawing.Color.White;
                score.ForeColor = System.Drawing.Color.White;
                currScore.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                labelScore.ForeColor = System.Drawing.Color.Black;
                score.ForeColor = System.Drawing.Color.Black;
                currScore.ForeColor = System.Drawing.Color.Black;
            }

            //Add texts to control
            Controls.Add(labelScore);
            Controls.Add(score);
            Controls.Add(currScore);

            /*** 5 labels for 5 blocks ***/
            listBLabel.Add(labelB1);
            listBLabel.Add(labelB2);
            listBLabel.Add(labelB3);
            listBLabel.Add(labelB4);
            listBLabel.Add(labelB5);

            /*** 4 labels for 4 foods ***/
            listFLabel.Add(labelF1);
            listFLabel.Add(labelF2);
            listFLabel.Add(labelF3);
            listFLabel.Add(labelF4);

            b1X = block.Block1.X; b2X = block.Block2.X; b3X = block.Block3.X; b4X = block.Block4.X; b5X = block.Block5.X;
            b1Y = block.Block1.Y; b2Y = block.Block2.Y; b3Y = block.Block3.Y; b4Y = block.Block4.Y; b5Y = block.Block5.Y;

            f1X = food.Food1.X; f2X = food.Food2.X; f3X = food.Food3.X; f4X = food.Food4.X;
            f1Y = food.Food1.Y; f2Y = food.Food2.Y; f3Y = food.Food3.Y; f4Y = food.Food4.Y;

            /*** Draw all labels ***/
            //Labels for blocks
            for (int i = 0; i < listBLabel.Count; i++)
            {
                listBLabel[i].BackColor = System.Drawing.Color.Transparent;
                listBLabel[i].Text = block.RandomText().ToString();
                listBLabel[i].Width = labelBW;
                listBLabel[i].Height = labelBH;
                listBLabel[i].Font = new Font("Arial", 14);
                Controls.Add(listBLabel[i]);
            }

            //Labels for foods
            for(int i = 0; i < listFLabel.Count; i++)
            {
                listFLabel[i].BackColor = System.Drawing.Color.Transparent;

                if (frmHome.bgIndex == 0) //Give text color to black when the background is white
                {
                    listFLabel[i].ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    //Give white color for all other backgrounds
                    listFLabel[i].ForeColor = System.Drawing.Color.White;
                }
                
                //For the first time, set all texts to have positive values 
                listFLabel[i].Text = food.RandomPstvText().ToString(); 
                listFLabel[i].Width = labelFW;
                listFLabel[i].Height = labelFH;
                listFLabel[i].Font = new Font("Arial", 10, FontStyle.Bold);
                Controls.Add(listFLabel[i]);
            }

            buttonPause.BackgroundImage = CrashBoy.Properties.Resources.button_pause;
        }

        private void ShowBackground(int i)
        {
            switch (i)
            {
                case 0:
                    this.BackgroundImage = Properties.Resources.white_bg;
                    break;
                case 1:
                    this.BackgroundImage = Properties.Resources.black;
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources.desert;
                    break;
                case 3:
                    this.BackgroundImage = Properties.Resources.sea_bg;
                    break;
                case 4:
                    this.BackgroundImage = Properties.Resources.space;
                    break;
                default:
                    break;
            }
        }

        //Get the index for the block hit by the ball
        private int GetBlockIndex()
        {
            if (ball.hitBlock(block.Block1) ||
                ball.hitBlock(block.Block2) ||
                ball.hitBlock(block.Block3) ||
                ball.hitBlock(block.Block4) ||
                ball.hitBlock(block.Block5))
            {
                if (ball.GetX >= b5X)
                {
                    return 4;
                }
                else if(ball.GetX >= b4X)
                {
                    return 3;
                }
                else if (ball.GetX >= b3X)
                {
                    return 2;
                }
                else if (ball.GetX >= b2X)
                {
                    return 1;
                }
                else if(ball.GetX >= b1X)
                {
                    return 0;
                }           
            }
            return -1;
        }

        //Get the index for the food eaten by the ball
        private int GetFoodIndex()
        {
            if (ball.eatFood(food.Food1)) {
                return 0;
            }
            if (ball.eatFood(food.Food2)) {
                return 1;
            }
            if (ball.eatFood(food.Food3)) {
                return 2;
            }
            if (ball.eatFood(food.Food4)) {
                return 3;
            }
            return -1;
        }

        //Determine the right text based on user score
        private void determineFoodText(int index)
        {
            int score = int.Parse(currScore.Text),
                numPstv = 0; //How many positive values should be in the game
            if(score > 100)
            {
                numPstv = 1;
            }
            else if(score > 50)
            {
                numPstv = 2;
            }
            else if(score >= 0)
            {
                numPstv = 3;
            }
            
            //Check whether the current food should assign positive or negative value
            if(index + 1 <= numPstv)
            {
                setFoodText("positive", index);
            }
            else
            {
                setFoodText("negative", index);
            }
        }

        //Set the proper text label for foods (positive or negative value)
        private void setFoodText(string status, int i)
        {
            if(status == "positive")
            {
                listFLabel[i].Text = food.RandomPstvText().ToString();
                if (frmHome.bgIndex == 0) //Give text color to black when the background is white
                {
                    listFLabel[i].ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    //Give white color for positive value
                    listFLabel[i].ForeColor = System.Drawing.Color.White;
                }               
            }
            else if(status == "negative")
            {
                listFLabel[i].Text = food.RandomNgtvText().ToString();
                //Give red color for negative value
                listFLabel[i].ForeColor = System.Drawing.Color.Red;
            }
        }

        //Method to check if the game is over
        private bool GameOver()
        {
            if(int.Parse(currScore.Text) <= 0)
            {
                return true;
            }
            return false;
        }

        private void CheckGameOver()
        {
            //Check to see if the game is over
            if (GameOver())
            {
                //Play hurt song
                hurtSound.URL = resourcesPath + "Hurt.aiff"; 

                timerGame.Enabled = false;
                timerGame.Stop();
               
                int tempScore = int.Parse(score.Text);
                if (tempScore > frmHome.highScore)
                {
                    frmHome.highScore = tempScore;
                    frmHome.labelHighScore.Text = frmHome.highScore.ToString();
                }

                FormGameOver frmGameOver = new FormGameOver();
                frmGameOver.Owner = this;
                frmGameOver.ShowDialog();

                //System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application         
                //this.Close(); //to turn off current app
            }
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            Invalidate();
            food.Move();
            block.Move();

            int blockIndex = GetBlockIndex();
            //Ball hit the block
            if(blockIndex != -1)
            {
                int blockScore;
                hit = true;

                if(listBLabel[blockIndex].Text == "") { blockScore = 0; } //Score is 0 when no text is attached on the block
                else { blockScore = int.Parse(listBLabel[blockIndex].Text); }
                
                blockScore -= 1;
                listBLabel[blockIndex].Text = blockScore.ToString();

                if(blockScore <= 0)
                {
                    block.RemoveTheBlock(blockIndex + 1);
                    listBLabel[blockIndex].Text = ""; //Remove the the attached text
                }

                int tempScore = int.Parse(score.Text);
                tempScore++;
                score.Text = tempScore.ToString();

                block.HitByTheBall();

                //Reduce current score
                int currTempScore = int.Parse(currScore.Text);
                currTempScore--;
                currScore.Text = currTempScore.ToString();

                //Balls get smaller
                int d = ball.d,
                    newD = d;
                double increment = Math.Ceiling(double.Parse(currScore.Text) / 10 - 1);
                newD = d + (int)increment;
                ball.Resize(newD);

                //Speed is faster because the object is getting smaller
                int ballSpeed = ball.speed,
                    newSpeed = ballSpeed;
                double speedUp = Math.Ceiling(double.Parse(currScore.Text) / 20 - 1);
                newSpeed = ballSpeed + (int)speedUp;

                if (newSpeed > 15)
                {
                    newSpeed = 15;
                }

                ball.speed = newSpeed;

                //Block and food speed will increase correspond to the score
                double inc = Math.Ceiling(double.Parse(score.Text) / 50 - 1);

                block.speed = blockSpeed + (int)inc;
                //food.speed = blockSpeed + (int)inc;

                //Check to see if the game is over
                CheckGameOver();
            }

            //Food will move again when all blocks position is greater than ball's Y position
            if (block.Block1.Y + block.height > ball.GetY &&
                block.Block2.Y + block.height > ball.GetY &&
                block.Block3.Y + block.height > ball.GetY &&
                block.Block4.Y + block.height > ball.GetY &&
                block.Block5.Y + block.height > ball.GetY)
            {
                hit = false;
            }

            //Update the score when the ball eat the food
            int foodIndex = GetFoodIndex();
            if (foodIndex != -1) //Ball eat the food
            {
                int tempScore = int.Parse(currScore.Text);
                tempScore += int.Parse(listFLabel[foodIndex].Text);
                currScore.Text = tempScore.ToString();

                food.RemoveTheFood(foodIndex + 1);

                //Balls get bigger
                int d = ball.d,
                    newD = d;
                double increment = Math.Ceiling(double.Parse(currScore.Text) / 10 - 1);
                newD = d + (int)increment;

                if (newD > block.width) newD = block.width; //Maximum d is block width

                ball.Resize(newD);

                //Ball's speed is slower because the object is getting bigger
                int ballSpeed = ball.speed,
                    newBallSpeed = ballSpeed;
                double ballSpeedDown = Math.Ceiling(double.Parse(currScore.Text) / 20 - 1);
                newBallSpeed = ballSpeed - (int)ballSpeedDown;

                if (newBallSpeed < 5)
                {
                    newBallSpeed = 5;
                }

                ball.speed = newBallSpeed;

                //Check to see if the game is over
                CheckGameOver();
            }

            if (hit)
            {
                //Food movement is stopped
                food.speed = 0;
            }
            else
            {
                //Food is moving again
                food.speed = 4;
                //food.speed = block.speed;
            }

            //Labels for blocks
            b1Y += block.speed; b2Y += block.speed; b3Y += block.speed; b4Y += block.speed; b5Y += block.speed;

            //Labels for foods
            f1Y += food.speed; f2Y += food.speed; f3Y += food.speed; f4Y += food.speed;

            labelB1.Location = new Point(b1X + block.width / 2 - 10, b1Y + block.height / 2 - 10);
            labelB2.Location = new Point(b2X + block.width / 2 - 10, b2Y + block.height / 2 - 10);
            labelB3.Location = new Point(b3X + block.width / 2 - 10, b3Y + block.height / 2 - 10);
            labelB4.Location = new Point(b4X + block.width / 2 - 10, b4Y + block.height / 2 - 10);
            labelB5.Location = new Point(b5X + block.width / 2 - 10, b5Y + block.height / 2 - 10);

            //labelB1.Location = new Point(b1X + block.width / 2 - labelBW, b1Y + block.height / 2 - labelBH);
            //labelB2.Location = new Point(b2X + block.width / 2 - labelBW, b2Y + block.height / 2 - labelBH);
            //labelB3.Location = new Point(b3X + block.width / 2 - labelBW, b3Y + block.height / 2 - labelBH);
            //labelB4.Location = new Point(b4X + block.width / 2 - labelBW, b4Y + block.height / 2 - labelBH);
            //labelB5.Location = new Point(b5X + block.width / 2 - labelBW, b5Y + block.height / 2 - labelBH);

            labelF1.Location = new Point(f1X + 5, f1Y - 15);
            labelF2.Location = new Point(f2X + 5, f2Y - 15);
            labelF3.Location = new Point(f3X + 5, f3Y - 15);
            labelF4.Location = new Point(f4X + 5, f4Y - 15);

            /*** Re-random the text number when the text pos is greater than form height ***/
            //Blocks' labels
            if (b1Y >= this.ClientRectangle.Height)
            {
                listBLabel[0].Text = block.RandomText().ToString();
            }
            if (b2Y >= this.ClientRectangle.Height)
            {
                listBLabel[1].Text = block.RandomText().ToString();
            }
            if (b3Y >= this.ClientRectangle.Height)
            {
                listBLabel[2].Text = block.RandomText().ToString();
            }
            if (b4Y >= this.ClientRectangle.Height)
            {
                listBLabel[3].Text = block.RandomText().ToString();
            }
            if (b5Y >= this.ClientRectangle.Height)
            {
                listBLabel[4].Text = block.RandomText().ToString();
            }

            //Foods' labels
            if (f1Y >= this.ClientRectangle.Height)
            {
                //listFLabel[0].Text = food.RandomPstvText().ToString();
                determineFoodText(0);
            }
            if (f2Y >= this.ClientRectangle.Height)
            {
                determineFoodText(1);
            }
            if (f3Y >= this.ClientRectangle.Height)
            {
                determineFoodText(2);
            }
            if (f4Y >= this.ClientRectangle.Height)
            {
                //listFLabel[3].Text = food.RandomNgtvText().ToString();
                determineFoodText(3);
            }

            //The labelBlocks will be reposition exactly like the blocks' position
            b1Y = block.Block1.Y; b2Y = block.Block2.Y; b3Y = block.Block3.Y; b4Y = block.Block4.Y; b5Y = block.Block5.Y;

            //The labelFoods will be reposition exactly like the foods' position
            f1X = food.Food1.X; f2X = food.Food2.X; f3X = food.Food3.X; f4X = food.Food4.X;
            f1Y = food.Food1.Y; f2Y = food.Food2.Y; f3Y = food.Food3.Y; f4Y = food.Food4.Y;
        }
    }
}
