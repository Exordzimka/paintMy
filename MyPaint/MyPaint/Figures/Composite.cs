using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MyPaint.Figures
{
    public class Composite : Figure
    {
        private readonly List<Figure> figures = new List<Figure>();
        public override bool Touch(float x, float y)
        {
            return figures.Any(figure => figure.Touch(x, y));
        }

        public List<Figure> Figures => figures;

        public override void Move(float x, float y)
        {
            var kx = x - getX;
            var ky = y - getY;
            foreach (var figure in figures)
            {
                figure.Move(figure.getX + kx/*x-getX*/,figure.getY + ky/*y-getY*/);
            }
            base.Move(x,y);
        }

        public override void Resize(float width, float height)
        {
            if (getWidth > 0 && getHeight > 0)
            {
                float kxWidth = width / getWidth;
                float kyHeight = height / getHeight;
                foreach (var figure in figures)
                {
                    figure.Resize(figure.getWidth*kxWidth,figure.getHeight*kyHeight);
                    figure.Move(getX+kxWidth*(figure.getX-getX), getY+kyHeight*(figure.getY-getY));
                }
                base.Resize(width,height);
            }
        }

        public override void Draw(Graphics graphics)
        {
            foreach (var figure in figures)
            {
                figure.Draw(graphics);
            }
        }

        public void AddFigure(Figure figure)
        {
            if (figures.Count == 0)
            {
                figures.Add(figure);
                base.Move(figure.getX, figure.getY);
                base.Resize(figure.getWidth, figure.getHeight);
            }
            else
            {
                if (figures.Contains(figure))
                    return;
                if(figure == null)
                    return;
                if(figure == this)
                    return;
                figures.Add(figure);
                var rightBorderOfLastFigure = figure.getX + figure.getWidth;
                var bottomBorderOfLastFigure = figure.getY + figure.getHeight;
                var leftBorderOfLastFigure = figure.getX;
                var topBorderOfLastFigure = figure.getY;
                var rightBorderOfComposite = getX + getWidth;
                var bottomBorderOfComposite = getY + getHeight;
                var leftBorderOfComposite = getX;
                var topBorderOfComposite = getY;
                if (leftBorderOfLastFigure < leftBorderOfComposite)
                {
                    base.Move(leftBorderOfLastFigure,getY);
                    base.Resize(rightBorderOfComposite-getX, bottomBorderOfComposite-getY);
                }

                if (topBorderOfLastFigure < topBorderOfComposite)
                {
                    base.Move(getX, topBorderOfLastFigure);
                    base.Resize(rightBorderOfComposite-getX, bottomBorderOfComposite-getY);
                }
                if(rightBorderOfLastFigure>rightBorderOfComposite)
                    base.Resize( rightBorderOfLastFigure-getX, getHeight);
                if(bottomBorderOfLastFigure>bottomBorderOfComposite)
                    base.Resize(getWidth, bottomBorderOfLastFigure-getY);
                
            }
        }

        public void Clear()
        {
            figures.Clear();
            base.Move(0,0);
            base.Resize(0,0);
        }

        public override Figure Clone()
        {
            Composite clonedFigure = new Composite();
            clonedFigure.Move(getX, getY);
            clonedFigure.Resize(getWidth, getHeight);
            clonedFigure.Pen = new Pen(Pen.Color);
            foreach (var figure in Figures)
            {
                clonedFigure.AddFigure(figure.Clone());
            }
            return clonedFigure;
        }
    }
}