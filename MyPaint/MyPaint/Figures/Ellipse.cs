using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.Figures
{
    public class Ellipse : Figure
    {
        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pen, getX, getY, getWidth, getHeight);
        }

        public override bool Touch(float x, float y)
        {
            return Math.Pow((x - GetCenter.X), 2) / Math.Pow(GetBigHalfShaft, 2) + 
                Math.Pow((y - GetCenter.Y), 2) / Math.Pow(GetSmallHalfShaft, 2) <= 1;
        }

        public PointF GetCenter
        {
            get
            {
                PointF point = new PointF();
                point.X = getX + getWidth / 2;
                point.Y = getY + getHeight / 2;
                return point;
            }
        }

        private float GetBigHalfShaft
        {
            get
            {
                if (getWidth > getHeight)
                    return getWidth / 2;
                return getHeight;
            }
        }

        private float GetSmallHalfShaft
        {
            get
            {
                if (getWidth < getHeight)
                    return getWidth / 2;
                return getHeight;
            }
        }
        
        public override Figure Clone()
        {
            Ellipse clonedFigure = new Ellipse();
            clonedFigure.Move(getX, getY);
            clonedFigure.Resize(getWidth, getHeight);
            clonedFigure.Pen = new Pen(Pen.Color);
            return clonedFigure;
        }
    }
}
