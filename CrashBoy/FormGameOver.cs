using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrashBoy
{
    public partial class FormGameOver : Form
    {
        FormHome frmHome;
        FormGame frmGame;

        public FormGameOver()
        {
            InitializeComponent();
        }

        private void FormGameOver_Load(object sender, EventArgs e)
        {
            frmHome = (FormHome)this.Owner.Owner;
            frmGame = (FormGame)this.Owner;

            labelScore.Text = frmGame.score.Text;
            labelHighScore.Text = frmHome.highScore.ToString();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            this.Close();
            
            //Restart the form game 
            frmGame.FormGame_Load(sender, e);
            frmGame.timerGame.Enabled = true;
            frmGame.timerGame.Start();
            frmGame.hit = false;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Close(); 
            frmGame.Close(); //Close form game too
        }
    }
}
