using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MyPaint.Figures;

namespace MyPaint.Selecting
{
    public class Handler : Ellipse
    {
        private PointF startPoint = new PointF();
        private float diameter = 5;
        SolidBrush solidBrush;
        public Handler()
        {
            Pen = new Pen(Color.Blue);
            solidBrush = new SolidBrush(Color.Blue);
            Resize(diameter, diameter);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pen, getX, getY, getWidth, getHeight);
            graphics.FillEllipse(solidBrush, getX, getY, getWidth, getHeight);
        }

        public void Drag(float x, float y)
        {
            float dx = x - startPoint.X;
            float dy = y - startPoint.Y;

        }

        public void Update()
        {

        }

        public override bool touch(float x, float y)
        {
            startPoint.X = x;
            startPoint.Y = y;
            return base.touch(x, y);
        }

    }
}
