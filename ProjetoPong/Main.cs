using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProjetoPong {
    public partial class Main : Form {
        public int speed { get; set; } = 5;
        public int PlayerPoints { get; set; } = 0;
        public int EnemyPoints { get; set; } = 0;
        public int VelocidadePlayer { get; set; } = 12;
        public int VelocidadeInimigo { get; set; } = 10;
        public int Tick { get; set; } = 20;
        public int xVelocidadeBola { get; set; }
        public int yVelocidadeBola { get; set; }
        public bool goUp { get; set; } = false;
        public bool goDown { get; set; } = false;
        Thread EnemyMov, OutWall, LogEnemy, LogPlayer, LogWall, PointPlayer, PointEnemy, ResetarJogo, PlayerTopBottom;


        public Main() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
            GerarVelocidadeAleatoria();
        }


        private void GerarVelocidadeAleatoria() {
            Start:
            Random xVelBola = new Random();
            Random yVelBola = new Random();
            xVelocidadeBola = xVelBola.Next(-10, 10);
            yVelocidadeBola = yVelBola.Next(-10, 10);

            if ((xVelocidadeBola <= 1 && xVelocidadeBola >= -1) || (yVelocidadeBola <= 1 && yVelocidadeBola >= -1)) {
                goto Start;
            }
        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (goUp) {
                Pplayer.Top -= speed;
            }

            if (goDown) {
                Pplayer.Top += speed;
            }

            LogEnemy = new Thread(LogicaDoInimigo, 0);
            LogPlayer = new Thread(LogicaDoPlayer, 0);
            LogWall = new Thread(LogicaDaParede, 0);
            OutWall = new Thread(OutOfBounds, 0);
            PointPlayer = new Thread(PointToPlayer, 0);
            PointEnemy = new Thread(PointToEnemy, 0);
            EnemyMov = new Thread(EnemyMoviment, 0);
            PlayerTopBottom = new Thread(PlayerLimits, 0);

            // Quando o timer inicia a bola começa a se movimentar se baseando na posição inicial || Top: 260 e Left: 500
            Pball.Location = new Point(
            Pball.Location.X + xVelocidadeBola,
            Pball.Location.Y + yVelocidadeBola
            );

            LogEnemy.Start();
            LogPlayer.Start();
            LogWall.Start();
            OutWall.Start();
            EnemyMov.Start();
            PlayerTopBottom.Start();

            // Se bater no player 2(inimigo) a bola vai para o sentido contrário
            // Se bater na parede do player 2(inimigo) a bola reseta e é ponto pro player 1
            void LogicaDoInimigo() {
                foreach (Control Penemy in this.Controls) {
                    if (Penemy is PictureBox && Penemy.Tag == "enemy") {
                        if (Pball.Bounds.IntersectsWith(Penemy.Bounds)) {
                            xVelocidadeBola = -xVelocidadeBola;
                            yVelocidadeBola = -yVelocidadeBola;
                        }
                    }
                    else if (Penemy is PictureBox && Penemy.Tag == "enemypointwall") {
                        if (Pball.Bounds.IntersectsWith(Penemy.Bounds)) {
                            //PointToPlayer();
                            PointPlayer.Start();
                        }
                    }
                }
            }

            // Se bater no player 1  a bola vai para o sentido contrário
            // Se bater na parede do player 1 a bola reseta e é ponto pro player 2 (inimigo)
            void LogicaDoPlayer() {
                foreach (Control Pplayer in this.Controls) {
                    if (Pplayer is PictureBox && Pplayer.Tag == "player") {
                        if (Pball.Bounds.IntersectsWith(Pplayer.Bounds)) {
                            if (Pball.Location.Y < 260 && Pball.Location.X < 482) {
                                xVelocidadeBola = -xVelocidadeBola;
                                yVelocidadeBola = -yVelocidadeBola;
                            }
                            else if (Pball.Location.Y > 260 && Pball.Location.X > 482) {
                                xVelocidadeBola = -xVelocidadeBola;
                                yVelocidadeBola = -yVelocidadeBola;
                            }
                        }
                    }
                    else if (Pplayer is PictureBox && Pplayer.Tag == "playerpointwall") {
                        if (Pball.Bounds.IntersectsWith(Pplayer.Bounds)) {
                            PointEnemy.Start();
                        }
                    }
                }
            }

            //Teste de movimento do inimigo para subir e descer automaticamente
            //Necessário o delegate para poder alterar o picturebox do inimigo pois estava sendo acesso por outra thread
            void EnemyMoviment() {
                foreach (Control enemy in this.Controls) {
                    if (Penemy.InvokeRequired) Penemy.BeginInvoke((MethodInvoker)delegate {
                        if (enemy is PictureBox && enemy.Tag == "enemy") {
                            enemy.Top -= VelocidadeInimigo;

                            if (enemy.Bounds.IntersectsWith(pictureBox4.Bounds)) {
                                VelocidadeInimigo = -VelocidadeInimigo;
                            }
                            if (enemy.Bounds.IntersectsWith(pictureBox5.Bounds)) {
                                enemy.Top += VelocidadeInimigo;

                                VelocidadeInimigo = -VelocidadeInimigo;
                            }
                        }
                    });
                }
            }

            // Teste de movimento para o inimigo seguir a bola no Y
            // Provavel necessidade do delegate? R: sim
            //void EnemyMoviment() {
            //    foreach (Control enemy in this.Controls) {
            //        if (Penemy.InvokeRequired) Penemy.BeginInvoke((MethodInvoker)delegate {
            //            if (enemy is PictureBox && enemy.Tag == "enemy") {
            //                enemy.Top = Pball.Location.Y;
            //                if (enemy.Bounds.IntersectsWith(pictureBox4.Bounds)) {                                
            //                    VelocidadeInimigo = Pball.Location.Y;
            //                }
            //                if (enemy.Bounds.IntersectsWith(pictureBox5.Bounds)) {
            //                    if(enemy.Bottom > pictureBox5.Top) {
            //                        enemy.Top = 483;
            //                    }
            //                }
            //            }
            //        });
            //    }
            //}

            // Caso a bola bata na parede superior ou inferior ela vai para o lado ricocheteia
            void LogicaDaParede() {
                foreach (Control Pwall in this.Controls) {
                    if (Pwall is PictureBox && Pwall.Tag == "wall") {
                        if (Pball.Bounds.IntersectsWith(Pwall.Bounds)) {
                            yVelocidadeBola = -yVelocidadeBola;
                        }
                    }
                }
            }

            void OutOfBounds() {
                foreach (Control Pwall in this.Controls) {
                    if (Pwall is PictureBox && Pwall.Tag == "wall") {
                        if (Pball.Bounds.Top >= 610 || Pball.Bounds.Top <= -10 || Pball.Bounds.Left >= 1030 || Pball.Bounds.Left <= -10) {
                            ResetOOB();
                            //messageBox.Show("Out of bounds not allowed, restart the game.", "Bug detected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            GerarVelocidadeAleatoria();
                            Temporizador();
                        }
                    }
                }
            }

            void PlayerLimits() {
                foreach (Control player in this.Controls) {
                    if(player is PictureBox && player.Tag == "player") {
                        if (player.Bounds.IntersectsWith(pictureBox4.Bounds)) {
                            Pplayer.Top = pictureBox4.Bottom;
                            goUp = false;
                        }
                        else if (Pplayer.Bounds.IntersectsWith(pictureBox5.Bounds)) {
                            Pplayer.Top = 484;
                            goDown = false;
                        }
                    }
                }
            }
        }

        private void Temporizador() {
            Timer.Enabled = true;
            Timer.Interval = Tick;
            if (Pball.InvokeRequired) Pball.BeginInvoke((MethodInvoker)delegate {
                Pball.Top = 262;
                Pball.Left = 482;
            });
        }

        private void PointToPlayer() {
            ResetOOB();

            PlayerPoints += 1;
            if (lblPlayerPoints.InvokeRequired) lblPlayerPoints.BeginInvoke((MethodInvoker)delegate {
                lblPlayerPoints.Text = PlayerPoints.ToString();
            });

            GerarVelocidadeAleatoria();
        }

        private void btnEnd_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.W) {
                goUp = true;
            }
            if (e.KeyCode == Keys.S) {
                goDown = true;
            }
        }

        private void Main_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.W) {
                goUp = false;
            }
            if (e.KeyCode == Keys.S) {
                goDown = false;
            }
        }

        private void PointToEnemy() {
            Thread.Yield();
            ResetOOB();

            EnemyPoints += 1;
            if (lblEnemyPoints.InvokeRequired) lblEnemyPoints.BeginInvoke((MethodInvoker)delegate {
                lblEnemyPoints.Text = EnemyPoints.ToString();
            });

            GerarVelocidadeAleatoria();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            Temporizador();

            if (Timer.Enabled == true) {
                foreach (Control btn in this.Controls) {
                    if (btn.Tag == "start" && btn.Enabled == true) {
                        btn.Enabled = false;
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            ResetarJogo = new Thread(ResetGame, 0);
            ResetarJogo.Start();
        }

        private void ResetGame() {
            btnStart.Enabled = true;
            PlayerPoints = 0;
            EnemyPoints = 0;
            lblEnemyPoints.Text = EnemyPoints.ToString();
            lblPlayerPoints.Text = PlayerPoints.ToString();

            if (Pball.InvokeRequired) Pball.BeginInvoke((MethodInvoker)delegate {
                Pball.Top = 262;
                Pball.Left = 482;
            });

            if (Pplayer.InvokeRequired) Pplayer.BeginInvoke((MethodInvoker)delegate {
                Pplayer.Top = 227;
                Pplayer.Left = 35;
            });

            //if (Penemy.InvokeRequired) Penemy.BeginInvoke((MethodInvoker)delegate {
            //    Penemy.Top = 227;
            //    Penemy.Left = 961;
            //});

            goUp = false;
            goDown = false;
            Timer.Stop();

        }

        private void ResetOOB() {
            if (Pball.InvokeRequired) Pball.BeginInvoke((MethodInvoker)delegate {
                Pball.Top = 262;
                Pball.Left = 482;
            });

            //if (Penemy.InvokeRequired) Penemy.BeginInvoke((MethodInvoker)delegate {
            //    Penemy.Top = 227;
            //    Penemy.Left = 961;
            //});

            goUp = false;
            goDown = false;
        }
    }
}
