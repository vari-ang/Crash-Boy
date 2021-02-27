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
    public partial class FormHome : Form
    {
        public List<string> backGround = new List<string>() { "white_bg", "black", "desert", "undersea_bg", "space" };
        public int bgIndex = 0,
                   highScore = 0;

        string resourcesPath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer loopSound = new WindowsMediaPlayer();

        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            labelHighScore.Text = highScore.ToString();

            loopSound.URL = resourcesPath + "Cheery Monday.mp3";
            loopSound.settings.setMode("loop", true);
        }

        private void showBackground(int i)
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

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            if (labelTap.Visible)
            {
                labelTap.Visible = false;
            }
            else
            {
                labelTap.Visible = true;
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            bgIndex--;

            if (bgIndex < 0)
            {
                bgIndex = backGround.Count - 1;
            }
            showBackground(bgIndex);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            bgIndex++;

            if (bgIndex >= backGround.Count)
            {
                bgIndex = 0;
            }
            showBackground(bgIndex);
        }

        private void labelTap_Click(object sender, EventArgs e)
        {
            FormGame frmGame = new FormGame();
            frmGame.Owner = this;
            frmGame.ShowDialog();
        }       
    }
}
