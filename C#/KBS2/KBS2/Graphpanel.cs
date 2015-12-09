using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace KBS2Test.model
{
    public partial class Graphpanel : UserControl
    {
        int studentmax;
        const double GRADEMAX = 10;
        const double GRADEINC = 0.5;
        List<Double> Cijfers;
        List<Point> points;
        int maxfrequency = -100;

        public Graphpanel()
        {
            points = new List<Point>();
            Cijfers = this.Testdata();

            InitializeComponent();
        }

        private void Graphpanel_Paint(object sender, PaintEventArgs e)
        {


            #region graphpaper setup
            this.BackColor = Color.White;
            Pen BlckBld = new Pen(Color.Black, 2);
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            int top = 5;
            int bottom = this.Height - 5;
            int left = 5;
            int right = this.Width - 5;
            Point lb = new Point(left, bottom);
            g.DrawLine(BlckBld, lb, new Point(right, bottom));
            g.DrawLine(BlckBld, lb, new Point(left, top));
            Pen gr = new Pen(Color.Gray);
            for (int a = 0; a < 10; a++)
            {
                g.DrawLine(gr, left + right * a / 10, bottom, left + right * a / 10, top);
            }
            #endregion
            if (Cijfers != null)
            {
                points.Clear();
                //create 20 points
                for(int a =2; a < 21; a++)
                {
                    points.Add(new Point(a, 0));
                }
                //get frequency of each point (grade)
                for(int p = 0; p<points.Count;p++)
                {
                    for(int c =0; c < Cijfers.Count; c++)
                    {
                        if ((double)points[p].X/2 == Cijfers[c])
                        {
                            points[p] = new Point(points[p].X, points[p].Y + 1);
                        }
                    }
                    if (points[p].Y > maxfrequency)
                    {
                        maxfrequency = points[p].Y;
                    }
                    Console.WriteLine(points[p]);
                }
                for(int p = 1; p < points.Count; p++)
                {
                    int xa = left + points[p].X * (right - left) / 20;
                    int ya = bottom - points[p].Y * (bottom- top) / (maxfrequency);
                    int xb = left + points[p-1].X * (right - left) / 20;
                    int yb = bottom - points[p-1].Y * (bottom - top) / (maxfrequency);
                    g.DrawLine(new Pen(Color.Red), xa, ya, xb, yb);
                }
            }

        }

        //TODO delete this class
        private List<Double> Testdata()
        {
            List<Double> r = new List<double>();
            //Random rand = new Random();
            //for (int i = 0; i < 30; i++)
            //{
            //    r.Add(rand.Next(9, 100) / 10);
            //    Console.WriteLine(r[i].ToString());
            //}
            r.Add(5.5);
            r.Add(5.5);
            r.Add(5.5);
            r.Add(2.5);
            r.Add(2.5);
            r.Add(2.5);
            r.Add(4.5);
            r.Add(4.5);
            r.Add(4.5);
            r.Add(4.5);
            r.Add(6);
            r.Add(6);
            r.Add(6);
            r.Add(6);
            r.Add(6);
            r.Add(6);
            r.Add(6);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            r.Add(7.5);
            return r;
        }
    }
}
