using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CrashBoy
{
    class Block
    {
        Image blockImg;
        Rectangle block1, block2, block3, block4, block5;

        private static Random rand = new Random();
       
        public int frmW = 0, frmH = 0,
                   x1 = 0, x2 = 0, x3 = 0, x4 = 0, x5 = 0,
                   y = -400,
                   width = 0, height = 0,
                   speed = 4;

        public Block(int formWidth, int formHeight)
        {
            blockImg = CrashBoy.Properties.Resources.blueblock;

            frmW = formWidth;
            frmH = formHeight;
            width = frmW / 5;
            height = width;

            x2 = x1 + width;
            x3 = x2 + width;
            x4 = x3 + width;
            x5 = x4 + width;

            Block1 = new Rectangle(x1, y, width, height);
            Block2 = new Rectangle(x2, y, width, height);
            Block3 = new Rectangle(x3, y, width, height);
            Block4 = new Rectangle(x4, y, width, height);
            Block5 = new Rectangle(x5, y, width, height);
        }

        //public Rectangle Block1 { get => block1; set => block1 = value; }
        //public Rectangle Block2 { get => block2; set => block2 = value; }
        //public Rectangle Block3 { get => block3; set => block3 = value; }
        //public Rectangle Block4 { get => block4; set => block4 = value; }
        //public Rectangle Block5 { get => block5; set => block5 = value; }

        public Rectangle Block1 { get { return block1; } set { block1 = value; } }
        public Rectangle Block2 { get { return block2; } set { block2 = value; } }
        public Rectangle Block3 { get { return block3; } set { block3 = value; } }
        public Rectangle Block4 { get { return block4; } set { block4 = value; } }
        public Rectangle Block5 { get { return block5; } set { block5 = value; } }

        public void DrawBlock(Graphics obj)
        {
            obj.DrawImage(blockImg, Block1);
            obj.DrawImage(blockImg, Block2);
            obj.DrawImage(blockImg, Block3);
            obj.DrawImage(blockImg, Block4);
            obj.DrawImage(blockImg, Block5);
        }

        public void Move()
        {
            block1.Y += speed;
            block2.Y += speed;
            block3.Y += speed;
            block4.Y += speed;
            block5.Y += speed;

            Reblock();
        }

        //Re-draw the blocks when they disappear from the screen
        public void Reblock()
        {
            if (Block1.Y >= frmH)
            {
                block1.Y = y;
                block2.Y = y;
                block3.Y = y;
                block4.Y = y;
                block5.Y = y;

                x1 = 0; x2 = 0; x3 = 0; x4 = 0; x5 = 0;
                x2 = x1 + width + 1;
                x3 = x2 + width + 1;
                x4 = x3 + width + 1;
                x5 = x4 + width + 1;

                block1.X = x1;
                block2.X = x2;
                block3.X = x3;
                block4.X = x4;
                block5.X = x5;
            }
        }

        public int RandomText()
        {
            return rand.Next(1, 50);
        }

        public void HitByTheBall()
        {
            block1.Y -= speed*2;
            block2.Y -= speed*2;
            block3.Y -= speed*2;
            block4.Y -= speed*2;
            block5.Y -= speed*2;
        }

        //Remove the block when the text label is 0
        public void RemoveTheBlock(int pos)
        {
            //Check to see which block is hit by the ball     
            if (pos == 1)
            {
                block1.X = frmW + 10;
            }
            else if (pos == 2)
            {
                block2.X = frmW + 10;
            }
            else if (pos == 3)
            {
                block3.X = frmW + 10;
            }
            else if (pos == 4)
            {
                block4.X = frmW + 10;
            }
            else
            {
                block5.X = frmW + 10;
            }
        }
    }
}
