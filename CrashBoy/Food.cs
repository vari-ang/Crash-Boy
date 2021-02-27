using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CrashBoy
{
    public class Food
    {
        Image foodImg;
        Rectangle food1, food2, food3, food4;
        SolidBrush fillRed = new SolidBrush(Color.Red);
        SolidBrush fillBlue = new SolidBrush(Color.Blue);

        int frmW = 0, frmH = 0,
            d = 26;

        public Food(int formWidth, int formHeight)
        {
            foodImg = CrashBoy.Properties.Resources.burger_food;

            frmW = formWidth;
            frmH = formHeight;

            x = Random(0, frmW);
            y = Random(0, frmH);
            Food1 = new Rectangle(x, y, d, d);

            x = Random(0, frmW);
            y = Random(0, frmH);
            Food2 = new Rectangle(x, y, d, d);

            x = Random(0, frmW);
            y = Random(0, frmH);
            Food3 = new Rectangle(x, y, d, d);

            x = Random(0, frmW);
            y = Random(0, frmH);
            Food4 = new Rectangle(x, y, d, d);
        }

        //public Rectangle Food1 { get => food1; set => food1 = value; }
        //public Rectangle Food2 { get => food2; set => food2 = value; }
        //public Rectangle Food3 { get => food3; set => food3 = value; }
        //public Rectangle Food4 { get => food4; set => food4 = value; }

        public Rectangle Food1 { get { return food1; } set { food1 = value; } }
        public Rectangle Food2 { get { return food2; } set { food2 = value; } }
        public Rectangle Food3 { get { return food3; } set { food3 = value; } }
        public Rectangle Food4 { get { return food4; } set { food4 = value; } }

        private static Random rand = new Random();
        private int Random(int a, int b)
        { 
            return rand.Next(a, b);
        }

        private int x = 0;
        public int X
        {
            get {
                return x;
            }
            set
            {
                x = value;
            }
        }
        private int y = 0;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public void DrawFood(Graphics obj)
        {
            //obj.FillEllipse(fillRed, food1);
            //obj.FillEllipse(fillRed, food2);
            //obj.FillEllipse(fillRed, food3);
            //obj.FillEllipse(fillRed, food4);

            obj.DrawImage(foodImg, food1);
            obj.DrawImage(foodImg, food2);
            obj.DrawImage(foodImg, food3);
            obj.DrawImage(foodImg, food4);
        }

        public int speed = 4;
        public void Move()
        {
            food1.Y += speed;
            food2.Y += speed;
            food3.Y += speed;
            food4.Y += speed;

            Refood();
        }

        public void Refood()
        {
            if (Food1.Y >= frmH)
            {
                x = Random(0, frmW - d);
                y = Random(-15, 0);
                food1.X = x;
                food1.Y = y;
            }
            if (Food2.Y >= frmH)
            {
                x = Random(0, frmW - d);
                y = Random(-15, 0);
                food2.X = x;
                food2.Y = y;
            }
            if (Food3.Y >= frmH)
            {
                x = Random(0, frmW - d);
                y = Random(-15, 0);
                food3.X = x;
                food3.Y = y;
            }
            if (Food4.Y >= frmH)
            {
                x = Random(0, frmW - d);
                y = Random(-15, 0);
                food4.X = x;
                food4.Y = y;
            }
        }

        public int RandomPstvText() //Text will be randomized from 1 to 10 (positive) 
        {
            return rand.Next(1, 11); 
        }
        public int RandomNgtvText() //Text will be randomized from -10 to -1 (negative) 
        {
            return rand.Next(-10, 0);
        }

        public void RemoveTheFood(int pos)
        {
            //Check to see which block is hit by the ball     
            if (pos == 1)
            {
                food1.Y = frmH;
            }
            else if (pos == 2)
            {
                food2.Y = frmH;
            }
            else if (pos == 3)
            {
                food3.Y = frmH;
            }
            else if (pos == 4)
            {
                food4.Y = frmH;
            }
        }
    }
}
