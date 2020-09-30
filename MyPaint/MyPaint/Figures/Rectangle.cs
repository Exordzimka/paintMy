using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint.Figures
{
    public class Rectangle : Figure
    {
        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pen, getX, getY, getWidth, getHeight);
        }

    }
}
