using pac_man.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pac_man
{
    public partial class Form1 : Form
    {
        static Graphics g;
        static int forward;
        int step, score;
        Scene scene;
        Ghosts ghosts;
        Dots dots;
        Dot active;
        Player p;
        Ghost gh;
        int level = 1;
        bool hold, right, left, down, gameover, gameend = false;
        bool up = false;
        float distance;
        PointF valid, valid2, valid3, trigger, l,l2, l3;
        public Form1()
        {
            InitializeComponent();
            //DrawMap1();
            Init();
        }
        public void Init()
        {
            level1();


        }
        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (left == true && hold == false)
            {
                up = false;
                down = false;
                left = true;
                right = false;
                p.LeftRight();
                p.Turn(4);
                if (trigger.X -10 <= p.middle.X - 5 && p.middle.X-5 <= trigger.X && trigger.Y<p.middle.Y+10 && trigger.Y>p.middle.Y-10)
                {
                    score += 100;
                    label1.Text = score.ToString();
                    dots.dots.Remove(active);
                    trigger = new PointF(-100, -100);
                }
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(4);
                    forward += step;
                    UpdatePosition();
                    
                }
                if ((p.middle.X - 7.5f <= l.X + 1 && l.X != 0 && l.Y != 0) || (p.middle2.X - 7.5f <= l2.X + 1 && l2.X != 0 && l2.Y != 0) || (p.middle3.X - 7.5f <= l3.X + 1 && l3.X != 0 && l3.Y != 0))
                {
                    left=false;
                    gameover=true;
                }
                if ((p.middle.X - 7.5f <= valid.X + 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.X - 7.5f <= valid2.X + 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.X - 7.5f <= valid3.X + 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    left = false;
                    
                }
                else
                {
                    p.Turn(4);
                    forward += step;
                    UpdatePosition();
                }

            }
            else if (right == true && hold == false)
            {
                up = false;
                down = false;
                left = false;
                right = true;
                
                if (trigger.X+10 >p.middle.X+5 && p.middle.X+5 >= trigger.X && trigger.X!=-100 && trigger.Y < p.middle.Y + 10 && trigger.Y > p.middle.Y - 10)
                {
                    score += 100;
                    label1.Text = score.ToString();
                    dots.dots.Remove(active);
                    trigger = new PointF(-100, -100);
                }
                p.LeftRight();
                p.Turn(2);
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(2);
                    forward += step;
                    UpdatePosition();
                }
                if ((p.middle.X + 7.5f >= l.X - 1 && l.X != 0 && l.Y != 0) || (p.middle2.X + 7.5f >= l2.X - 1 && l2.X != 0 && l2.Y != 0) || (p.middle3.X + 7.5f >= l3.X - 1 && l3.X != 0 && l3.Y != 0))
                {
                    right = false;
                    gameover = true;
                }
                if ((p.middle.X + 7.5f >= valid.X - 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.X + 7.5f >= valid2.X - 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.X + 7.5f >= valid3.X - 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    right=false;
                }
                else
                {
                    p.Turn(2);
                    forward += step;
                    UpdatePosition();
                }

            }
            else if (up == true && hold == false)
            {
                up = true;
                down = false;
                left = false;
                right = false;
                p.UpDown();
                p.Turn(1);
                if (trigger.Y - 10 < p.middle.Y - 5 && p.middle.Y-5 <= trigger.Y && trigger.X < p.middle.X + 10 && trigger.X > p.middle.X - 10)
                {
                    score += 100;
                    label1.Text = score.ToString();
                    dots.dots.Remove(active);
                    trigger = new PointF(-100, -100);
                }
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(1);
                    forward += step;
                    UpdatePosition();
                }
                if ((p.middle.Y - 7.5f <= l.Y + 1 && l.X != 0 && l.Y != 0) || (p.middle2.Y - 7.5f <= l2.Y + 1 && l2.X != 0 && l2.Y != 0) || (p.middle3.Y - 7.5f <= l3.Y + 1 && l3.X != 0 && l3.Y != 0))
                {
                    up = false;
                    gameover = true;
                }

                    if ((p.middle.Y - 7.5f <= valid.Y + 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.Y - 7.5f <= valid2.Y + 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.Y - 7.5f <= valid3.Y + 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    up = false;
                }
                else
                {
                    p.Turn(1);
                    forward += step;
                    UpdatePosition();
                }
            }
            else if (down == true && hold == false)
            {
                
                up = false;
                down = true;
                left = false;
                right = false;
                p.UpDown();
                p.Turn(3);
                if (trigger.Y + 10 > p.middle.Y + 5 && p.middle.Y+5 >= trigger.Y && trigger.X!=-100 && trigger.X < p.middle.X + 10 && trigger.X > p.middle.X - 10)
                {
                    score += 100;
                    label1.Text = score.ToString();
                    dots.dots.Remove(active);
                    trigger = new PointF(-100, -100);
                }
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(3);
                    forward += step;
                    UpdatePosition();
                    
                }
                if ((p.middle.Y + 7.5f == l.Y - 1 && l.X != 0 && l.Y != 0) || (p.middle2.Y + 7.5f == l2.Y - 1 && l2.X != 0 && l2.Y != 0) || (p.middle3.Y + 7.5f == l3.Y - 1 && l3.X != 0 && l3.Y != 0))
                {
                    down = false;
                    gameover = true;
                }

                    if ((p.middle.Y + 7.5f >= valid.Y - 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.Y + 7.5f >= valid2.Y - 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.Y + 7.5f >= valid3.Y - 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    down=false;
                }
                else
                {
                    p.Turn(3);
                    forward += step;
                    UpdatePosition();
                   
                }
            }
            pacman.Top = (int)p.getPos().Y + 1;
            pacman.Left = (int)p.getPos().X ;

            Render();
        }

        public void level1()
        {
            if (level > 3)
                gameend = true;
            DrawMap(level);
            pacman.Image = MyResource.fijo;
        }


        public void DrawMap(int nivel)
        {
            Bitmap bmp = new Bitmap(600, 600);
            g = Graphics.FromImage(bmp);
            map.Image = bmp;
            g.Clear(Color.Black);
            scene = new Scene();
            dots = new Dots();
            ghosts = new Ghosts();
            score = 0;
            step = 3;
            
            if (nivel == 1)
            {
                for (int x = 0; x < mapaBase.map0.GetLength(0); x++)
                {
                    for (int y = 0; y < mapaBase.map0.GetLength(1); y++)
                    {


                        if (mapaBase.map0[y, x] == 1)
                        {
                            Figure fig = new Figure();
                            fig.Lines.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            scene.Figures.Add(fig);
                        }
                        else if (mapaBase.map0[y, x] == 2)
                        {
                            p = new Player(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15 - 15));
                            p.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            p.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            p.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            p.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));


                        }
                        else if (mapaBase.map0[y, x] == 3 )
                        {
                            Dot dot = new Dot(new PointF(x * 15 + 7.5f, y * 15 + 7.5f));
                            dot.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            dot.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            dot.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            dot.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            dots.dots.Add(dot);
                        }
                        else if (mapaBase.map0[y, x] == 4)
                        {
                            gh = new Ghost(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15 - 15));
                            gh.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            gh.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            gh.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            gh.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            ghosts.ghosts.Add(gh);

                        }

                        //guía panel cuadrado para código 
                        //g.DrawRectangle(Pens.Gray, x * 15, y * 15, 15, 15);
                    }
                }

                Render();

            }
            else if(nivel == 2)
            {
                for (int x = 0; x < mapaL2.map0.GetLength(0); x++)
                {
                    for (int y = 0; y < mapaBase.map0.GetLength(1); y++)
                    {


                        if (mapaL2.map0[y, x] == 1)
                        {
                            Figure fig = new Figure();
                            fig.Lines.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            scene.Figures.Add(fig);
                        }
                        else if (mapaL2.map0[y, x] == 2)
                        {
                            p = new Player(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15 - 15));
                            p.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            p.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            p.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            p.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));


                        }
                        else if (mapaL2.map0[y, x] == 3)
                        {
                            Dot dot = new Dot(new PointF(x * 15 + 7.5f, y * 15 + 7.5f));
                            dot.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            dot.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            dot.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            dot.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            dots.dots.Add(dot);
                        }
                        else if (mapaL2.map0[y, x] == 4)
                        {
                            gh = new Ghost(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15 - 15));
                            gh.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            gh.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            gh.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            gh.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            ghosts.ghosts.Add(gh);
                        }

                        //guía panel cuadrado para código 
                        //g.DrawRectangle(Pens.Gray, x * 15, y * 15, 15, 15);
                    }
                }

                Render();

            }
            else if (nivel == 3)
            {
                for (int x = 0; x < mapaL3.map0.GetLength(0); x++)
                {
                    for (int y = 0; y < mapaBase.map0.GetLength(1); y++)
                    {


                        if (mapaL3.map0[y, x] == 1)
                        {
                            Figure fig = new Figure();
                            fig.Lines.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            fig.Lines.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            scene.Figures.Add(fig);
                        }
                        else if (mapaL3.map0[y, x] == 2)
                        {
                            p = new Player(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15 - 15));
                            p.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            p.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            p.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            p.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));


                        }
                        else if (mapaL3.map0[y, x] == 3)
                        {
                            Dot dot = new Dot(new PointF(x * 15 + 7.5f, y * 15 + 7.5f));
                            dot.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            dot.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            dot.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            dot.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            dots.dots.Add(dot);
                        }
                        else if (mapaL3.map0[y, x] == 4)
                        {
                            gh = new Ghost(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15 - 15));
                            gh.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                            gh.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                            gh.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                            gh.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                            ghosts.ghosts.Add(gh);
                        }

                        //guía panel cuadrado para código 
                        //g.DrawRectangle(Pens.Gray, x * 15, y * 15, 15, 15);
                    }
                }

                Render();

            }

        }

        public void Render()
        {
            g.Clear(Color.Black);
            for(int f=0; f<scene.Figures.Count; f++)
            {
                for (int l = 0; l<scene.Figures[f].Lines.Count; l++)
                {
                    g.DrawLine(Pens.Blue, scene.Figures[f].Lines[l].a, scene.Figures[f].Lines[l].b);
                }
            }
            for(int i=0; i < dots.dots.Count; i++)
            {
                g.FillEllipse(Brushes.White, dots.dots[i].location.X, dots.dots[i].location.Y, 3, 3);
            }
            
            Verify();
            VerifiyP();
            VerifyG();
            //DrawPlayer();
            DrawGhost();
            if (dots.dots.Count == 0)
            {
                level += 1;
                level1();
            }
            if (gameover)
            {
                g.Clear(Color.Black);
                gameover = false;
                score = 0;
                
                DrawMap(level);
            }
            label1.Text = score.ToString();
            if (gameend)
            {
                g.Clear(Color.Black);
                label1.Text = "Game Won";
                left = false;
                right=false;
                up = false;
                down = false;
            }
                
            
            map.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        /*public void DrawPlayer()
        {
            if (GhostHit())
            {
                g.FillEllipse(Brushes.Red, p.pos.X, p.pos.Y, 15, 15);
            }else
                g.FillEllipse(Brushes.Yellow, p.pos.X, p.pos.Y, 15, 15);

            for (int i = 0; i<p.hb.Count; i++)
            {
                g.DrawLine(Pens.Red, p.hb[i].a, p.hb[i].b);
            }
            //g.DrawLine(Pens.Red, p.middle2, valid2);
            //g.DrawLine(Pens.Red, p.middle3, valid3);

        }*/
        public void DrawGhost()
        {
            for (int i = 0; i < ghosts.ghosts.Count; i++)
            {
                g.FillEllipse(Brushes.Red, ghosts.ghosts[i].pos.X, ghosts.ghosts[i].pos.Y, 15, 15);
            }

        }

        public void UpdatePosition()
        {
            float f = (float)forward / 50;
            if (p.pos.X > 605)
            {
                p.middle.X = -50f;
            }
            if (p.pos.X < -20)
            {
                p.middle.X = 650f;
            }
            if (p.pos.Y > 605)
            {
                p.middle.Y = -50f;
            }
            if (p.pos.Y < -20)
            {
                p.middle.Y = 650f;
            }
            p.middle = Util.Instance.NextStep(p.middle, p.lookAt, f);
            p.middle2 = Util.Instance.NextStep(p.middle2, p.lookAt2, f);
            p.middle3 = Util.Instance.NextStep(p.middle3, p.lookAt3, f);
            p.hb[0].a = p.pos;
            p.hb[0].b = new PointF(p.pos.X + 15, p.pos.Y);
            p.hb[1].a = p.hb[0].b;
            p.hb[1].b = new PointF(p.hb[1].a.X, p.hb[1].a.Y + 15);
            p.hb[2].a = p.hb[1].b;
            p.hb[2].b = new PointF(p.hb[2].a.X-15, p.hb[2].a.Y);
            p.hb[3].a = p.hb[2].b;
            p.hb[3].b = new PointF(p.hb[3].a.X, p.hb[3].a.Y - 15);


            p.pos = new PointF(p.middle.X - 7.5f, p.middle.Y - 7.5f);

            Render();
            forward = 0;
        }


        public void Verify()
        {
            PointF collision, collision2, collision3;
            Figure figure;
            Line line, user, user2, user3;

            PointF tmp;
            float dTemp,dTemp2, dTemp3, d, d2, d3;

            dTemp = float.MaxValue;
            dTemp2 = float.MaxValue;
            dTemp3 = float.MaxValue;

            valid = new PointF();
            valid2 = new PointF();
            valid3 = new PointF();
            user = new Line(p.middle, p.lookAt);
            user2 = new Line(p.middle2, p.lookAt2);
            user3 = new Line(p.middle3, p.lookAt3);

            for (int i=0; i<scene.Figures.Count; i++)
            {
                figure = scene.Figures[i];
                for (int j=0; j<figure.Lines.Count; j++)
                {
                    line = figure.Lines[j];
                    if(Util.Instance.Intersect(user, line))
                    {
                        collision = Util.Instance.FindPoint(user, line);
                        d = Util.Instance.Distance(collision, p.middle);

                        if (d < dTemp)
                        {
                            dTemp = d;
                            valid = collision;
                            
                        }
                    }
                    if (Util.Instance.Intersect(user2, line))
                    {
                        collision2 = Util.Instance.FindPoint(user2, line);
                        d2 = Util.Instance.Distance(collision2, p.middle2);

                        if (d2 < dTemp2)
                        {
                            dTemp2 = d2;
                            valid2 = collision2;

                        }
                    }
                    if (Util.Instance.Intersect(user3, line))
                    {
                        collision3 = Util.Instance.FindPoint(user3, line);
                        d3 = Util.Instance.Distance(collision3, p.middle3);

                        if (d3 < dTemp3)
                        {
                            dTemp3 = d3;
                            valid3 = collision3;

                        }
                    }
                }
            }
            //g.FillEllipse(Brushes.Red, valid.X - 1, valid.Y - 1, 3, 3);
            //g.FillEllipse(Brushes.Red, valid2.X - 1, valid2.Y - 1, 3, 3);
            //g.FillEllipse(Brushes.Red, valid3.X - 1, valid3.Y - 1, 3, 3);
            distance = dTemp;

        }

        public void VerifiyP()
        {
            PointF collision;
            Dot dot;
            Line line, user;

            PointF tmp;
            float dTemp, d;

            dTemp = float.MaxValue;

            valid = new PointF();
            user = new Line(p.middle, p.lookAt);

            for (int i=0; i<dots.dots.Count; i++)
            {
                dot = dots.dots[i];
                for (int j=0; j<dot.hb.Count; j++)
                {
                    line = dot.hb[j];
                    if(Util.Instance.Intersect(user, line))
                    {
                        collision = Util.Instance.FindPoint(user, line);
                        d = Util.Instance.Distance(collision, p.middle);
                        if (d < dTemp)
                        {
                            dTemp = d;
                            trigger = collision;
                            active = dot;
                        }
                    }
                }
            }
            //g.FillEllipse(Brushes.Red, trigger.X - 1, trigger.Y - 1, 3, 3);
            distance = dTemp;

        }

        public void VerifyG()
        {
            PointF collision, collision2, collision3;
            Ghost ghost;
            Line line, user, user2, user3;

            PointF tmp;
            float dTemp, dTemp2, dTemp3, d, d2, d3;

            dTemp = float.MaxValue;
            dTemp2 = float.MaxValue;
            dTemp3 = float.MaxValue;

            l = new PointF();
            l2 = new PointF();
            l3 = new PointF();
            user = new Line(p.middle, p.lookAt);
            user2 = new Line(p.middle2, p.lookAt2);
            user3 = new Line(p.middle3, p.lookAt3);

            for (int i = 0; i < ghosts.ghosts.Count; i++)
            {
                ghost = ghosts.ghosts[i];
                for (int j = 0; j < ghost.hb.Count; j++)
                {
                    line = ghost.hb[j];
                    if (Util.Instance.Intersect(user, line))
                    {
                        collision = Util.Instance.FindPoint(user, line);
                        d = Util.Instance.Distance(collision, p.middle);

                        if (d < dTemp)
                        {
                            dTemp = d;
                            l = collision;

                        }
                    }
                    if (Util.Instance.Intersect(user2, line))
                    {
                        collision2 = Util.Instance.FindPoint(user2, line);
                        d2 = Util.Instance.Distance(collision2, p.middle2);

                        if (d2 < dTemp2)
                        {
                            dTemp2 = d2;
                            l2 = collision2;

                        }
                    }
                    if (Util.Instance.Intersect(user3, line))
                    {
                        collision3 = Util.Instance.FindPoint(user3, line);
                        d3 = Util.Instance.Distance(collision3, p.middle3);

                        if (d3 < dTemp3)
                        {
                            dTemp3 = d3;
                            l3 = collision3;

                        }
                    }
                }
            }
            //g.FillEllipse(Brushes.Red, l.X - 1, l.Y - 1, 3, 3);
            //g.FillEllipse(Brushes.Red, l2.X - 1, l2.Y - 1, 3, 3);
            //g.FillEllipse(Brushes.Red, l3.X - 1, l3.Y - 1, 3, 3);
            distance = dTemp;

        }

        /*public bool GhostHit()
        {
            PointF collision, tmp;
            float dTemp, d;
            tmp = new PointF();
            dTemp = float.MaxValue;
            for (int i=0; i < p.hb.Count; i++)
            {
                for (int j=0; j < gh.hb.Count; j++)
                {
                    if (Util.Instance.Intersect(p.hb[i], gh.hb[j]))
                    {
                        collision = Util.Instance.FindPoint(p.hb[i], gh.hb[j]);
                        d = Util.Instance.Distance(collision, p.middle);
                        if (d < dTemp)
                        {
                            dTemp = d;
                            tmp = collision;
                            
                        }
                        return true;
                    }
                }
            }
            g.FillEllipse(Brushes.Green, tmp.X - 1, tmp.Y - 1, 5, 5);
            return false;
        }*/

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right )
            {
                right = true;
                left = false;
                up = false;
                down = false;
                hold = false;
                l = new PointF(0, 0);
                l2 = new PointF(0, 0);
                l3 = new PointF(0, 0);
                trigger = new PointF(0, 0);

                pacman.Image = MyResource.pac_man_d;
            }
            else if (e.KeyData == Keys.Left )
            {
                left = true;
                right = false;
                up = false;
                down = false;
                hold = false;
                l = new PointF(0, 0);
                l2 = new PointF(0, 0);
                l3 = new PointF(0, 0);
                trigger = new PointF(0, 0);
                pacman.Image = MyResource.pac_man_i;
            }
            else if (e.KeyData == Keys.Up )
            {
                up = true;
                right = false;
                left = false;
                down = false;
                hold = false;
                l = new PointF(0, 0);
                l2 = new PointF(0, 0);
                l3 = new PointF(0, 0);
                trigger = new PointF(0, 0);
                pacman.Image = MyResource.pac_man_ar;
            }
            else if (e.KeyData == Keys.Down)
            {
                down = true;
                right = false;
                left = false;
                up = false;
                hold = false;
                l = new PointF(0, 0);
                l2 = new PointF(0, 0);
                l3 = new PointF(0, 0);
                trigger = new PointF(0, 0);
                pacman.Image = MyResource.pac_man_ab;
            }
        }

    }
}
