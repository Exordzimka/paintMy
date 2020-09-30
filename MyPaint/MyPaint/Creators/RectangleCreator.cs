using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint.Figures;

namespace MyPaint.Creators
{
    class RectangleCreator : Creator
    {
        public override Figure CreateFigure(float x, float y, float width, float height)
        {
            Rectangle rect = new Rectangle();
            rect.Move(x, y);
            rect.Resize(width, height);
            return rect;
        }
    }
}
