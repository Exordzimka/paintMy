using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint.Figures;
using MyPaint.Selecting;
using System.Drawing;

namespace MyPaint
{
    class Manipulator : Figure
    {
        private Figure selected;
        private float different = 3;
        List<Handler> handlers;
        public Manipulator()
        {
            handlers = new List<Handler>(5);
            for (int i = 0; i < 5; i++)
            {
                handlers.Add(new Handler());
            }
            handlers[0].Move(getX + getWidth / 2 - handlers[0].getWidth / 2,
                    getX + getHeight / 2 - handlers[0].getHeight / 2);
            handlers[1].Move(getX - handlers[0].getWidth / 2,
                    getX - handlers[0].getHeight / 2);
            handlers[2].Move(getX + getWidth - handlers[0].getWidth / 2,
                    getX - handlers[0].getHeight / 2);
            handlers[3].Move(getX + getWidth - handlers[0].getWidth / 2,
                    getX + getHeight - handlers[0].getHeight / 2);
            handlers[4].Move(getX - handlers[0].getWidth / 2,
                    getX + getHeight - handlers[0].getHeight / 2);
            Pen = new Pen(Color.Blue);
        }

        public Figure Selected { get => selected; }

        public void Attach(Figure figure)
        {
            selected = figure;
            if (selected != null)
            {
                Move(selected.getX - different, selected.getY - different);
                Resize(selected.getWidth + different * 2, selected.getHeight + different * 2);
            }
        }

        public override void Draw(Graphics graphics)
        {
            if (Selected != null)
                graphics.DrawRectangle(Pen, getX, getY, getWidth, getHeight);
        }

        public override bool touch(float x, float y)
        {
            return base.touch(x, y);
        }
    }
}
