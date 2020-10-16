using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace Clock
{
    public partial class myWatch : UserControl
    {
        const float PI = 3.14F;

        float fRadius, fCenterX, fCenterY, fCenterCircleRadius, fHourLength;
        float fMinLength, fSecLength, fHourThickness, fMinThickness, fSecThickness;
        bool bDraw5MinuteTicks = true;
        bool bDraw1MinuteTicks = true;
        float fTicksThickness = 2;

        Color hrColor = Color.Red;
        Color minColor = Color.Black;
        Color secColor = Color.Black;

        Color circleColor = Color.Black;
        Color ticksColor = Color.Green;

        SolidBrush numberic = new SolidBrush(Color.White);
        SolidBrush cant = new SolidBrush(Color.Black);



        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                cant.Color = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
                ticksColor = colorDialog2.Color;
        }

        private DateTime time;

        public myWatch()
        {
            InitializeComponent();
        }

        private void myWatch_Resize(object sender, EventArgs e)
        {
            this.Width = this.Height;
            this.fRadius = this.Height / 2;
            this.fCenterX = this.ClientSize.Width / 2;
            this.fCenterY = this.ClientSize.Height / 2;
            this.fHourLength = (float)this.Height / 3 / 1.85F;
            this.fMinLength = (float)this.Height / 3 / 1.20F;
            this.fSecLength = (float)this.Height / 3 / 1.15F;
            this.fHourThickness = (float)this.Height / 100;
            this.fMinThickness = (float)this.Height / 150;
            this.fSecThickness = (float)this.Height / 200;
            this.fCenterCircleRadius = this.Height / 50;
            timer1.Start();
        }
        private void myWatch_Load(object sender, EventArgs e)
        {
            time = DateTime.Now;
            this.myWatch_Resize(sender, e);
        }

        private void Clock_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(cant, 0,0, this.Width, this.Height);
            e.Graphics.FillEllipse(numberic, 6,6,this.Width-12,this.Height-12);
            float fRadHr = (time.Hour % 12 + time.Minute / 60F) * 30 * PI / 180;
            float fRadMin = (time.Minute) * 6 * PI / 180;
            float fRadSec = (time.Second) * 6 * PI / 180;

            DrawLine(this.fHourThickness, this.fHourLength, hrColor, fRadHr, e);
            DrawLine(this.fMinThickness, this.fMinLength, minColor, fRadMin, e);
            DrawLine(this.fSecThickness, this.fSecLength, secColor, fRadSec, e);


            for (int i = 0; i < 60; i++)
            {
                if (this.bDraw5MinuteTicks == true && i % 5 == 0) // Draw 5 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                    fCenterX + (float)(this.fRadius / 1.50F * Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.50F * Math.Cos(i * 6 * PI / 180)),
                    fCenterX + (float)(this.fRadius / 1.65F * Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.65F * Math.Cos(i * 6 * PI / 180)));
                }
                else if (this.bDraw1MinuteTicks == true) // draw 1 minute ticks
                {

                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                    fCenterX + (float)(this.fRadius / 1.50F * Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.50F * Math.Cos(i * 6 * PI / 180)),
                    fCenterX + (float)(this.fRadius / 1.55F * Math.Sin(i * 6 * PI / 180)),
                    fCenterY - (float)(this.fRadius / 1.55F * Math.Cos(i * 6 * PI / 180)));
                }
            }

            //draw circle at center
            e.Graphics.FillEllipse(new SolidBrush(circleColor), 
                fCenterX - fCenterCircleRadius / 2, fCenterY - fCenterCircleRadius / 2, 
                fCenterCircleRadius, fCenterCircleRadius);
            this.myWatch_Resize(sender, e);
        }

        private void DrawLine(float fThickness, float fLength, Color color, float fRadians, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, fThickness),
            fCenterX - (float)(fLength / 9 * Math.Sin(fRadians)),
            fCenterY + (float)(fLength / 9 * Math.Cos(fRadians)),
            fCenterX + (float)(fLength * Math.Sin(fRadians)),
            fCenterY - (float)(fLength * Math.Cos(fRadians)));

        }
        private void DrawPolygon(float fThickness, float fLength, Color color, float fRadians, PaintEventArgs e)
        {

            PointF A = new PointF((float)(fCenterX + fThickness * 2 * Math.Sin(fRadians + PI / 2)),
            (float)(fCenterY - fThickness * 2 * Math.Cos(fRadians + PI / 2)));
            PointF B = new PointF((float)(fCenterX + fThickness * 2 * Math.Sin(fRadians - PI / 2)),
            (float)(fCenterY - fThickness * 2 * Math.Cos(fRadians - PI / 2)));
            PointF C = new PointF((float)(fCenterX + fLength * Math.Sin(fRadians)),
            (float)(fCenterY - fLength * Math.Cos(fRadians)));
            PointF D = new PointF((float)(fCenterX - fThickness * 4 * Math.Sin(fRadians)),
            (float)(fCenterY + fThickness * 4 * Math.Cos(fRadians)));
            PointF[] points = { A, D, B, C };
            e.Graphics.FillPolygon(new SolidBrush(color), points);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;
            this.Refresh();
        }

    }
}
