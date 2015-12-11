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
        int maxfrequency;

        public int graphfrequency
        {
            get { return maxfrequency; }
        }

        public int graphheight
        {
            get { return Bottom - Top; }
        }
            

        public Graphpanel()
        {
            points = new List<Point>();
            Cijfers = this.Testdata();
            this.points_refresh();

            InitializeComponent();
        }

        private void Graphpanel_Paint(object sender, PaintEventArgs e)
        {


            #region graphpaper setup
            this.BackColor = Color.White;
            Pen BlckBld = new Pen(Color.Black, 2);
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            int top = 0;
            int bottom = this.Height - 2;
            int left = 1;
            int right = this.Width;
            Point lb = new Point(left, bottom);
            g.DrawLine(BlckBld, lb, new Point(right, bottom));
            g.DrawLine(BlckBld, lb, new Point(left, top));
            Pen gr = new Pen(Color.Gray);
            //for (int a = 0; a < 11; a++)
            //{
            //    g.DrawLine(gr, left + right * a / 11, bottom, left + right * a / 11, top);
            //}
            #endregion
            if (Cijfers != null)
            {
                this.points_refresh();
                
                for(int p = 0; p < points.Count-1; p++)
                {
                    int xa = left + points[p].X * (right - left) / 22;
                    int ya = bottom - points[p].Y * (bottom - top) / (maxfrequency);
                    int xb = left + points[p+1].X * (right - left) / 22;
                    int yb = bottom - points[p+1].Y * (bottom - top) / (maxfrequency);
                    //g.DrawLine(new Pen(Color.Red, 15), xa, ya, xb, yb);
                    g.FillRectangle(Brushes.Red, (int) (xa-0.1*(xb- xa) + 10), ya,(int)( xb - xa - 15), bottom - ya);
                    
                }



            }

        }
        private void points_refresh()
        {
            points.Clear();
            //create 20 points
            for (int a = 2; a < 22; a++)
            {
                points.Add(new Point(a, 0));
            }

            for (int c = 0; c < Cijfers.Count; c++)
            {
                while (Cijfers[c] % 0.5 != 0)
                {
                    Cijfers[c] = Cijfers[c] - 0.1;
                }
            }
            //get frequency of each point (grade)
            for (int p = 0; p < points.Count; p++)
            {
                for (int c = 0; c < Cijfers.Count; c++)
                {
                    if ((double)points[p].X / 2 == Cijfers[c])
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
            r.Add(1);
            r.Add(2);
            r.Add(3);
            r.Add(4);
            r.Add(5);
            r.Add(6);
            r.Add(7);
            r.Add(8);
            r.Add(9);
            r.Add(10);
            return r;
        }
    }
}
