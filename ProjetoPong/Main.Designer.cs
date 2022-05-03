
namespace ProjetoPong {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.Pplayer = new System.Windows.Forms.PictureBox();
            this.Penemy = new System.Windows.Forms.PictureBox();
            this.Pball = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlayerPoints = new System.Windows.Forms.Label();
            this.lblEnemyPoints = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Pplayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Penemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // Pplayer
            // 
            this.Pplayer.BackColor = System.Drawing.Color.White;
            this.Pplayer.Location = new System.Drawing.Point(35, 227);
            this.Pplayer.Name = "Pplayer";
            this.Pplayer.Size = new System.Drawing.Size(10, 69);
            this.Pplayer.TabIndex = 0;
            this.Pplayer.TabStop = false;
            this.Pplayer.Tag = "player";
            // 
            // Penemy
            // 
            this.Penemy.BackColor = System.Drawing.Color.White;
            this.Penemy.Location = new System.Drawing.Point(961, 227);
            this.Penemy.Name = "Penemy";
            this.Penemy.Size = new System.Drawing.Size(10, 69);
            this.Penemy.TabIndex = 1;
            this.Penemy.TabStop = false;
            this.Penemy.Tag = "enemy";
            // 
            // Pball
            // 
            this.Pball.BackColor = System.Drawing.Color.Aqua;
            this.Pball.Location = new System.Drawing.Point(482, 260);
            this.Pball.Name = "Pball";
            this.Pball.Size = new System.Drawing.Size(13, 14);
            this.Pball.TabIndex = 2;
            this.Pball.TabStop = false;
            this.Pball.Tag = "ball";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Player 1 | Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(786, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Player 2 | Points:";
            // 
            // lblPlayerPoints
            // 
            this.lblPlayerPoints.AutoSize = true;
            this.lblPlayerPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerPoints.ForeColor = System.Drawing.Color.White;
            this.lblPlayerPoints.Location = new System.Drawing.Point(166, 1);
            this.lblPlayerPoints.Name = "lblPlayerPoints";
            this.lblPlayerPoints.Size = new System.Drawing.Size(20, 24);
            this.lblPlayerPoints.TabIndex = 5;
            this.lblPlayerPoints.Text = "0";
            // 
            // lblEnemyPoints
            // 
            this.lblEnemyPoints.AutoSize = true;
            this.lblEnemyPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyPoints.ForeColor = System.Drawing.Color.White;
            this.lblEnemyPoints.Location = new System.Drawing.Point(958, 1);
            this.lblEnemyPoints.Name = "lblEnemyPoints";
            this.lblEnemyPoints.Size = new System.Drawing.Size(20, 24);
            this.lblEnemyPoints.TabIndex = 6;
            this.lblEnemyPoints.Text = "0";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Silver;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(378, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.TabStop = false;
            this.btnStart.Tag = "start";
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Silver;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(459, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.TabStop = false;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Silver;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Location = new System.Drawing.Point(540, 3);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 9;
            this.btnEnd.TabStop = false;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Location = new System.Drawing.Point(-8, 28);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1031, 10);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "wall";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Location = new System.Drawing.Point(-8, 552);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1031, 10);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "wall";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.Location = new System.Drawing.Point(-1, 36);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(10, 525);
            this.pictureBox7.TabIndex = 13;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Tag = "playerpointwall";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.Location = new System.Drawing.Point(995, 32);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(10, 525);
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Tag = "enemypointwall";
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1004, 560);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblEnemyPoints);
            this.Controls.Add(this.lblPlayerPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pball);
            this.Controls.Add(this.Penemy);
            this.Controls.Add(this.Pplayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Pplayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Penemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pplayer;
        private System.Windows.Forms.PictureBox Penemy;
        private System.Windows.Forms.PictureBox Pball;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlayerPoints;
        private System.Windows.Forms.Label lblEnemyPoints;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Timer Timer;
    }
}

