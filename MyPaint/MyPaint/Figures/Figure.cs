using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint.Figures
{
    public class Figure
    {
        private float x, y, width, height;
        private Pen pen = new Pen(Color.Black);

        public Pen Pen
        {
            get => pen;
            set => pen = value;
        }
        public float getX => x;

        public float getY => y;
        public float getWidth => width;
        public float getHeight => height;

        public virtual bool touch(float x, float y)
        {
            if (x >= getX && x <= getX + getWidth &&
               y >= getY && y <= getY + getHeight)
                return true;
            else
                return false;
        }

        public virtual void Move(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public virtual void Resize(float width, float height)
        {
            this.width = Math.Abs(width);
            this.height = Math.Abs(height);
        }

        public virtual void Draw(Graphics graphics)
        {

        }
    }
}
