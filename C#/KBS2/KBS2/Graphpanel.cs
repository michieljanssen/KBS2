using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                #region Cijfers afronden

                for (int b = 0; b < Cijfers.Count; b++)
                {
                    if (Cijfers[b] % GRADEINC != 0)
                    {
                        Cijfers[b] -= 0.1;
                    }
                }


                #endregion
                #region voeg loze cijfers toe ivm een mooie grafiek
                for (int c = 2; c < 21; c++)
                {
                    Cijfers.Add(c / 2);
                }
                #endregion
                #region frequency berekenen en points toevoegen
                for (int prim = 0; prim < Cijfers.Count; prim++)
                {
                    int freq = 0;
                    for (int sec = prim + 1; sec < Cijfers.Count; sec++)
                    {
                        if (Cijfers[prim] == Cijfers[sec])
                        {
                            freq++;
                            Cijfers.RemoveAt(sec);
                            sec = prim + 1;
                        }
                        if (freq > maxfrequency)
                        {
                            maxfrequency = freq;
                        }
                        points.Add(new Point((int)Cijfers[prim] * 10, freq));
                    }
                }
                #endregion
                #region horizontale lijnen tekenen
                for (int d = 0; d < maxfrequency; d++)
                {
                    g.DrawLine(gr, left, bottom - (bottom- top)*d/maxfrequency, right, bottom - (bottom - top) * d / maxfrequency);
                }
                #endregion
                for(int p = 1; p < points.Count; p++)
                {
                    int xa = points[p].X / 10 * (right - left)/10;
                    int ya = bottom - points[p].Y * (bottom- top) / maxfrequency;
                    int xb = points[p-1].X / 10 * (right - left)/10;
                    int yb = bottom - points[p-1].Y * (bottom- top) / maxfrequency;
                    g.DrawLine(new Pen(Color.Red), xa, ya, xb, yb);
                }
            }

        }

        //TODO delete this class
        private List<Double> Testdata()
        {
            List<Double> r = new List<double>();
            Random rand = new Random();
            for (int i = 0; i < 30; i++)
            {
                r.Add(rand.Next(9, 100) / 10);
                Console.WriteLine(r[i].ToString());
            }
            return r;
        }
    }
}
