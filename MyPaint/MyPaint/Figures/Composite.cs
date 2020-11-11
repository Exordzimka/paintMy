using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MyPaint.Figures;

namespace MyPaint
{
    public class Composite : Figure
    {
        List<Figure> figures = new List<Figure>();
        public override bool touch(float x, float y)
        {
            foreach (var figure in figures)
            {
                if (figure.touch(x, y))
                    return true;
            }

            return false;
        }

        public override void Move(float x, float y)
        {
            float kx = x - getX;
            float ky = y - getY;
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
                float rightBorderOfLastFigure = figure.getX + figure.getWidth;
                float bottomBorderOfLastFigure = figure.getY + figure.getHeight;
                float leftBorderOfLastFigure = figure.getX;
                float topBorderOfLastFigure = figure.getY;
                float rightBorderOfComposite = getX + getWidth;
                float bottomBorderOfComposite = getY + getHeight;
                float leftBorderOfComposite = getX;
                float topBorderOfComposite = getY;
                if(rightBorderOfLastFigure>rightBorderOfComposite)
                    base.Resize( rightBorderOfLastFigure-getX, getHeight);
                if(bottomBorderOfLastFigure>bottomBorderOfComposite)
                    base.Resize(getWidth, bottomBorderOfLastFigure-getY);
                if(leftBorderOfLastFigure<leftBorderOfComposite)
                    base.Move(leftBorderOfLastFigure,getY);
                if (topBorderOfLastFigure < topBorderOfComposite)
                    base.Move(getX, topBorderOfLastFigure);
            }
        }

        public void Clear()
        {
            figures.Clear();
        }
    }
}