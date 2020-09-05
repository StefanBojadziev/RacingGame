using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameOver.Visible = false;
            restart.Visible = false;
            restart.Enabled = false;
            projectile.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(playerSpeed);
            racer(playerSpeed-br.Next(0,2));
            GameOverEvent();
            items(playerSpeed);
            itemColision();
            Fire();
        }

        Random br = new Random();

        int x1, y1;

        int coinCounter = 0;

        void racer(int speed)
        {
            if (enemy1.Top >= 450)
            {
                x1 = br.Next(0, 200);
                y1 = br.Next(0, 25);
                enemy1.Location = new Point(x1, y1);
            }
            else
            {
                enemy1.Top += speed;
            }

            if (enemy2.Top >= 450)
            {
                x1 = br.Next(0, 200);
                y1 = br.Next(0, 25);
                enemy2.Location = new Point(x1, y1);
            }
            else
            {
                enemy2.Top += speed;
            }

            if (enemy3.Top >= 450)
            {
                x1 = br.Next(200, 325);
                y1 = br.Next(0, 25);
                enemy3.Location = new Point(x1, y1);
            }
            else
            {
                enemy3.Top += speed;
            }

            if (enemy4.Top >= 450)
            {
                x1 = br.Next(200, 325);
                y1 = br.Next(0, 25);
                enemy4.Location = new Point(x1, y1);
            }
            else
            {
                enemy4.Top += speed;
            }


        }

        void items(int speed)
        {
            //so ova gi pridvizhuvame site objekti kako parichki, maslo i kamenja so ista brzina
            if (coin1.Top >= 450)
            {
                x1 = br.Next(0, 200);
                y1 = br.Next(0, 25);
                coin1.Location = new Point(x1, y1);
            }
            else
            {
                coin1.Top += speed;
            }

            if (coin2.Top >= 450)
            {
                x1 = br.Next(0, 200);
                y1 = br.Next(0, 25);
                coin2.Location = new Point(x1, y1);
            }
            else
            {
                coin2.Top += speed;
            }

            if (coin3.Top >= 450)
            {
                x1 = br.Next(200, 325);
                y1 = br.Next(0, 25);
                coin3.Location = new Point(x1, y1);
            }
            else
            {
                coin3.Top += speed;
            }

            if (coin4.Top >= 450)
            {
                x1 = br.Next(200, 325);
                y1 = br.Next(0, 25);
                coin4.Location = new Point(x1, y1);
            }
            else
            {
                coin4.Top += speed;
            }

            if (rock.Top >= 450)
            {
                x1 = br.Next(0, 325);
                y1 = br.Next(0, 25);
                rock.Location = new Point(x1, y1);
            }
            else
            {
                rock.Top += speed;
            }

            if (oilSpill.Top >= 450)
            {
                x1 = br.Next(0, 325);
                y1 = br.Next(0, 25);
                oilSpill.Location = new Point(x1, y1);
            }
            else
            {
                oilSpill.Top += speed;
            }



        }

        void Fire()
        {
            if (projectile.Top <= 0)
            {
                projectile.Location = player.Location;
                projectile.Visible = false;
            }
            else
            {
                projectile.Top -= playerSpeed;
            }
        }

        void GameOverEvent()
        {
            //proveruvame dali sme go doprele protivnikot
            if (player.Bounds.IntersectsWith(enemy1.Bounds) || projectile.Bounds.IntersectsWith(enemy4.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                restart.Visible = true;
                restart.Enabled = true;

            }

            if (player.Bounds.IntersectsWith(enemy2.Bounds) || projectile.Bounds.IntersectsWith(enemy4.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                restart.Visible = true;
                restart.Enabled = true;

            }

            if (player.Bounds.IntersectsWith(enemy3.Bounds) || projectile.Bounds.IntersectsWith(enemy4.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                restart.Visible = true;
                restart.Enabled = true;

            }

            if (player.Bounds.IntersectsWith(enemy4.Bounds) || projectile.Bounds.IntersectsWith(enemy4.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                restart.Visible = true;
                restart.Enabled = true;

            }

            if (player.Bounds.IntersectsWith(rock.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                restart.Visible = true;
                restart.Enabled = true;

            }


        }

        void itemColision()
        {
            //proveruvame dali sme ja doprele parichkata
            if (player.Bounds.IntersectsWith(coin1.Bounds))
            {
                coinCounter++;
                score.Text = "Score: " + coinCounter;
                x1 = br.Next(200, 325);
                y1 = br.Next(0, 25);
                coin1.Location = new Point(x1, y1);
            }

            if (player.Bounds.IntersectsWith(coin2.Bounds))
            {
                coinCounter++;
                score.Text = "Score: " + coinCounter;
                x1 = br.Next(200, 325);
                y1 = br.Next(0, 25);
                coin2.Location = new Point(x1, y1);
            }

            if (player.Bounds.IntersectsWith(coin3.Bounds))
            {
                coinCounter++;
                score.Text = "Score: " + coinCounter;
                x1 = br.Next(200, 325);
                y1 = br.Next(0, 25);
                coin3.Location = new Point(x1, y1);
            }

            if (player.Bounds.IntersectsWith(coin4.Bounds))
            {
                coinCounter++;
                score.Text = "Score: " + coinCounter;
                x1 = br.Next(200, 325);
                y1 = br.Next(0, 25);
                coin4.Location = new Point(x1, y1);
            }
            //kolizija so maslo ne frla levo ili desno i ne usporuva
            if (player.Bounds.IntersectsWith(oilSpill.Bounds))
            {
                if (br.Next(0, 1) == 0)
                {
                    player.Left += 10;
                }

                else
                {
                    player.Left += -10;
                }

                playerSpeed--;
                x1 = br.Next(0, 325);
                y1 = br.Next(0, 25);
                oilSpill.Location = new Point(x1, y1);

            }

            if (projectile.Bounds.IntersectsWith(rock.Bounds))
            {
                x1 = br.Next(0, 325);
                y1 = br.Next(0, 25);
                rock.Location = new Point(x1, y1);

            }

        }

        void moveLine (int playerSpeed) 
        {
            //koristam -5 zato shto "oko testot" mi kazhuva deka animacijata na liniite lichi podobro odkolku so 0
            //dvizhenje na prvata linija
            if (pictureBox1.Top >= 450) 
            {
                pictureBox1.Top = -5;
            }
            else 
            {
                pictureBox1.Top += playerSpeed;
            }

            //dvizhenje na vtorata linija
            if (pictureBox2.Top >= 450)
            {
                pictureBox2.Top = -5;
            }
            else
            {
                pictureBox2.Top += playerSpeed;
            }

            //dzvizhenje na tretata linija
            if (pictureBox3.Top >= 450)
            {
                pictureBox3.Top = -5;
            }
            else
            {
                pictureBox3.Top += playerSpeed;
            }

            //dvizhenje na chetvratata linija
            if (pictureBox4.Top >= 450)
            {
                pictureBox4.Top = -5;
            }
            else
            {
                pictureBox4.Top += playerSpeed;
            }

        

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        int playerSpeed = 0;

        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) 
            {
                if (player.Left > 0) 
                {
                    player.Left += -6;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                if(player.Right < 382)
                    player.Left += 6;
            }

            if(e.KeyCode == Keys.Up) 
            {
                if(playerSpeed < 15)
                {
                    playerSpeed++;
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                if (playerSpeed > 0)
                {
                    playerSpeed--;
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                Fire();
                projectile.Visible = true;
            }
        }
    }
}
