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

        public Graphpanel()
        {
            

            InitializeComponent();
        }

        private void Graphpanel_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White; //set's the background to white
            Point ZERO = new Point(5, this.Height - 10); //ZERO point of the graphpaper
            Point TOPRIGHT = new Point(this.Width - 10, 5); //TOPRIGHT point of the graphpaper
            int WIDTH = Math.Abs(ZERO.X - TOPRIGHT.X); //Width of the graphpaper
            int HEIGHT = Math.Abs(ZERO.Y - TOPRIGHT.Y); // Height of the graphpaper
            Graphics g = e.Graphics;
            Pen black = new Pen(Color.Black,2);
            g.DrawLine(black, ZERO.X, ZERO.Y, TOPRIGHT.X, ZERO.Y); // draws the horizontal line
            g.DrawLine(black, ZERO.X, ZERO.Y, ZERO.X, TOPRIGHT.Y); // draws the vertical line
            Pen gray = new Pen(Color.Gray,2);
            double grade = 0;
            //draw the vertical grid
            while (grade <= GRADEMAX)
            {
                //ERROR HERE WORKING ON IT
                g.DrawLine(gray, ZERO.X + (int)(WIDTH / 10 * grade), ZERO.Y, TOPRIGHT.X + (int)(WIDTH / 10 * grade), TOPRIGHT.Y);
                grade = grade + GRADEINC;
            }
            if(Cijfers != null)
            {
                //Round the cijfers
                for(int i =0; i < Cijfers.Count; i++)
                {
                    if(Cijfers[i]%GRADEINC != 0)
                    {
                        Cijfers[i] = Cijfers[i] - 0.01;
                    }
                }
                //loop and count each grade
                int xmax = 0;
                for(int a=0; a< Cijfers.Count; a++)
                {
                    double gradevalue;
                    double gradefrequency;
                    for(int b = a + 1; b < Cijfers.Count; b++)
                    {

                    }
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
                r.Add(rand.Next(9, 100)/10);
            }
            return r;
        }
    }
}
