namespace CrashBoy
{
    partial class FormHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.labelTap = new System.Windows.Forms.Label();
            this.labelBoy = new System.Windows.Forms.Label();
            this.labelCrash = new System.Windows.Forms.Label();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.labelHighScore = new System.Windows.Forms.Label();
            this.pictureBoxHighScore = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHighScore)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.Color.Transparent;
            this.buttonRight.BackgroundImage = global::CrashBoy.Properties.Resources.buttonRight;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRight.Location = new System.Drawing.Point(660, 794);
            this.buttonRight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(103, 64);
            this.buttonRight.TabIndex = 19;
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackColor = System.Drawing.Color.Transparent;
            this.buttonLeft.BackgroundImage = global::CrashBoy.Properties.Resources.buttonLeft;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLeft.Location = new System.Drawing.Point(16, 794);
            this.buttonLeft.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(103, 64);
            this.buttonLeft.TabIndex = 18;
            this.buttonLeft.UseVisualStyleBackColor = false;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // labelTap
            // 
            this.labelTap.AutoSize = true;
            this.labelTap.BackColor = System.Drawing.Color.White;
            this.labelTap.Font = new System.Drawing.Font("Copperplate Gothic Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTap.Location = new System.Drawing.Point(234, 630);
            this.labelTap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTap.Name = "labelTap";
            this.labelTap.Size = new System.Drawing.Size(310, 37);
            this.labelTap.TabIndex = 17;
            this.labelTap.Text = "T a p   t o   P l a y";
            this.labelTap.Click += new System.EventHandler(this.labelTap_Click);
            // 
            // labelBoy
            // 
            this.labelBoy.AutoSize = true;
            this.labelBoy.BackColor = System.Drawing.Color.White;
            this.labelBoy.Font = new System.Drawing.Font("Copperplate Gothic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoy.Location = new System.Drawing.Point(289, 135);
            this.labelBoy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBoy.Name = "labelBoy";
            this.labelBoy.Size = new System.Drawing.Size(174, 63);
            this.labelBoy.TabIndex = 16;
            this.labelBoy.Text = "B o y";
            // 
            // labelCrash
            // 
            this.labelCrash.AutoSize = true;
            this.labelCrash.BackColor = System.Drawing.Color.White;
            this.labelCrash.Font = new System.Drawing.Font("Copperplate Gothic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrash.Location = new System.Drawing.Point(238, 65);
            this.labelCrash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCrash.Name = "labelCrash";
            this.labelCrash.Size = new System.Drawing.Size(282, 63);
            this.labelCrash.TabIndex = 15;
            this.labelCrash.Text = "C r a s h";
            // 
            // timerPlay
            // 
            this.timerPlay.Enabled = true;
            this.timerPlay.Interval = 400;
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // labelHighScore
            // 
            this.labelHighScore.AutoSize = true;
            this.labelHighScore.BackColor = System.Drawing.Color.White;
            this.labelHighScore.Font = new System.Drawing.Font("Copperplate Gothic Bold", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHighScore.Location = new System.Drawing.Point(385, 332);
            this.labelHighScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHighScore.Name = "labelHighScore";
            this.labelHighScore.Size = new System.Drawing.Size(57, 53);
            this.labelHighScore.TabIndex = 21;
            this.labelHighScore.Text = "0";
            // 
            // pictureBoxHighScore
            // 
            this.pictureBoxHighScore.BackgroundImage = global::CrashBoy.Properties.Resources.best;
            this.pictureBoxHighScore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxHighScore.Location = new System.Drawing.Point(282, 318);
            this.pictureBoxHighScore.Name = "pictureBoxHighScore";
            this.pictureBoxHighScore.Size = new System.Drawing.Size(96, 78);
            this.pictureBoxHighScore.TabIndex = 22;
            this.pictureBoxHighScore.TabStop = false;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CrashBoy.Properties.Resources.white_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(776, 963);
            this.Controls.Add(this.pictureBoxHighScore);
            this.Controls.Add(this.labelHighScore);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.labelTap);
            this.Controls.Add(this.labelBoy);
            this.Controls.Add(this.labelCrash);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(800, 1027);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.FormHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHighScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Label labelTap;
        private System.Windows.Forms.Label labelBoy;
        private System.Windows.Forms.Label labelCrash;
        private System.Windows.Forms.Timer timerPlay;
        public System.Windows.Forms.Label labelHighScore;
        private System.Windows.Forms.PictureBox pictureBoxHighScore;
    }
}