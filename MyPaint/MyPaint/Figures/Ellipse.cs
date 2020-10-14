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

        public override bool touch(float x, float y)
        {
            return Math.Pow((x - GetCenter.X), 2) / Math.Pow(getBigHalfShaft, 2) + 
                Math.Pow((y - GetCenter.Y), 2) / Math.Pow(getSmallHalfShaft, 2) <= 1;
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

        private float getBigHalfShaft
        {
            get
            {
                if (getWidth > getHeight)
                    return getWidth / 2;
                return getHeight;
            }
        }

        private float getSmallHalfShaft
        {
            get
            {
                if (getWidth < getHeight)
                    return getWidth / 2;
                return getHeight;
            }
        }
    }
}
