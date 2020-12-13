using System;
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

        public virtual bool Touch(float x, float y)
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

        public virtual Figure Clone()
        {
            Figure clonedFigure = new Figure();
            clonedFigure.Move(getX, getY);
            clonedFigure.Resize(getWidth, getHeight);
            clonedFigure.Pen = new Pen(pen.Color);
            return clonedFigure;
        }
    }
}
