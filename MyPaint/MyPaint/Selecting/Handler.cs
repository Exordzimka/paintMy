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
        private float diameter = 10;
        public Handler()
        {
            Pen = new Pen(Color.Blue);
            Resize(diameter, diameter);
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
        }

        public void Drag(float dx, float dy)
        {

        }

        public void Update()
        {

        }
    }
}
