using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint.Figures;

namespace MyPaint.Creators
{
    class EllipseCreator : Creator
    {
        public override Figures.Figure CreateFigure(float x, float y, float width, float height)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Move(x, y);
            ellipse.Resize(width, height);
            return ellipse;
        }
    }
}
