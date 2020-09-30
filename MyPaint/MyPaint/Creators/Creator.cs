using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint.Figures;

namespace MyPaint.Creators
{
    class Creator
    {
        public virtual Figure CreateFigure(float x, float y, float width, float height)
        {
            return null;
        }
    }
}
