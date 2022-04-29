using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProjetoPong {
    public partial class Main : Form {
        public int PlayerPoints { get; set; } = 0;
        public int EnemyPoints { get; set; } = 0;
        public int VelocidadePlayer { get; set; } = 15;
        public int Tick { get; set; } = 50;
        public int xVelocidadeBola { get; set; }
        public int yVelocidadeBola { get; set; }
        public bool goUp { get; set; } = false;
        public bool goDown { get; set; } = false;
        Thread OutWall, LogEnemy, LogPlayer, LogWall;


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
            xVelocidadeBola = xVelBola.Next(-27, 27);
            yVelocidadeBola = yVelBola.Next(-25, 25);

            if ((xVelocidadeBola <= 13 && xVelocidadeBola >= -13) || (yVelocidadeBola <= 13 && yVelocidadeBola >= -13)) {
                goto Start;
            }
        }

        private void Timer_Tick(object sender, EventArgs e) {
            LogEnemy = new Thread(LogicaDoInimigo, 0);
            LogPlayer = new Thread(LogicaDoPlayer, 0);
            LogWall = new Thread(LogicaDaParede, 0);
            OutWall = new Thread(OutOfBounds, 0);

            // Quando o timer inicia a bola começa a se movimentar se baseando na posição inicial || Top: 260 e Left: 500
            Pball.Location = new Point(
            Pball.Location.X + xVelocidadeBola,
            Pball.Location.Y + yVelocidadeBola
            );

            // Se bater no player 2(inimigo) a bola vai para o sentido contrário
            // Se bater na parede do player 2(inimigo) a bola reseta e é ponto pro player 1

            LogEnemy.Start();
            LogPlayer.Start();
            LogWall.Start();
            OutWall.Start();

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
                            PointToPlayer();
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
                            xVelocidadeBola = -xVelocidadeBola;
                            yVelocidadeBola = -yVelocidadeBola;
                        }
                    }
                    else if (Pplayer is PictureBox && Pplayer.Tag == "playerpointwall") {
                        if (Pball.Bounds.IntersectsWith(Pplayer.Bounds)) {
                            PointToEnemy();
                        }
                    }
                }
            }

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
                            Timer.Stop();
                            ResetOOB();
                            //messageBox.Show("Out of bounds not allowed, restart the game.", "Bug detected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            Temporizador();
                        }
                    }
                }
            }
        }

        private void Temporizador() {
            Timer.Enabled = true;
            Timer.Interval = Tick;
            Pball.Top = 262;
            Pball.Left = 482;
        }

        private void PointToPlayer() {
            Pball.Top = 262;
            Pball.Left = 482;
            PlayerPoints += 1;
            lblPlayerPoints.Text = PlayerPoints.ToString();
            GerarVelocidadeAleatoria();
            //Timer.Stop();
        }

        private void PointToEnemy() {
            Pball.Top = 262;
            Pball.Left = 482;
            EnemyPoints += 1;
            lblEnemyPoints.Text = EnemyPoints.ToString();
            GerarVelocidadeAleatoria();
            //Timer.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            Temporizador();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            ResetGame();
        }

        private void ResetGame() {
            PlayerPoints = 0;
            EnemyPoints = 0;
            lblEnemyPoints.Text = EnemyPoints.ToString();
            lblPlayerPoints.Text = PlayerPoints.ToString();

            goUp = false;
            goDown = false;
            Pball.Top = 262;
            Pball.Left = 482;
            Pplayer.Top = 227;
            Pplayer.Left = 35;
            Penemy.Top = 227;
            Penemy.Left = 961;
            Timer.Stop();
        }

        private void ResetOOB() {
            goUp = false;
            goDown = false;
            Pball.Top = 262;
            Pball.Left = 482;
            Pplayer.Top = 227;
            Pplayer.Left = 35;
            Penemy.Top = 227;
            Penemy.Left = 961;
        }
    }
}
