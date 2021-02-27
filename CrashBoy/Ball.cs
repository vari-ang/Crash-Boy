using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CrashBoy
{
    public class Ball
    {
        Image boyImg;
        Rectangle ball;
        int frmW = 0, frmH = 0;
        public int d = 25;

        Font textFont = new Font("Arial", 10);
        SolidBrush textColor = new SolidBrush(Color.Black);
        StringFormat format = new StringFormat();
        String text;

        public Ball(int formWidth, int formHeight)
        {
            boyImg = CrashBoy.Properties.Resources.red_boy;

            frmW = formWidth; frmH = formHeight;
            int x = frmW / 2;
            int y = frmH - 80;
            ball = new Rectangle(x, y, d, d);
            text = "1";
        }
        public void DrawBall(Graphics obj)
        {
            obj.DrawImage(boyImg, ball);
        }

        public int GetX
        {
            get { return ball.X; }
        }    
        public int GetY
        {
            get { return ball.Y; }
        }
       
        public int speed = 15;
        public void MoveLeft()
        {
            ball.X -= speed;
            if (ball.X <= 0)
            {
                ball.X = 0;
            }
        }
        public void MoveRight()
        {
            ball.X += speed;
            if (ball.X + d >= frmW)
            {
                ball.X = frmW - d;
            }
        }
        public bool eatFood(Rectangle obj)
        {
            if (obj.IntersectsWith(ball))
            {
                return true;
            }
            return false;
        }

        public bool hitBlock(Rectangle obj)
        {
            if (obj.IntersectsWith(ball))
            {
                return true;
            }
            return false;
        }

        public void Resize(int newD)
        {
            ball = new Rectangle(GetX, GetY, newD, newD);
        }
    }
}
