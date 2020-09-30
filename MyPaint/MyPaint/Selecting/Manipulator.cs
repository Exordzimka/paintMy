using System.Collections.Generic;
using MyPaint.Figures;
using MyPaint.Selecting;
using System.Drawing;

namespace MyPaint
{
    class Manipulator : Figure
    {
        private float xTouch, yTouch;
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
            {
                graphics.DrawRectangle(Pen, getX, getY, getWidth, getHeight);
                foreach (Handler handler in handlers)
                {
                    handler.Draw(graphics);
                }
            }
        }

        public void Drag(float x, float y)
        {
            float dx = x - xTouch;
            float dy = y - yTouch;
            xTouch = x;
            yTouch = y;
            Move(getX + dx, getY + dy);
            Update();
        }

        public void Update()
        {
            Selected.Move(getX+different, getY+different);
        }

        public void SetTouchPoint(float x, float y)
        {
            xTouch = x;
            yTouch = y;
        }

        public override void Move(float x, float y)
        {
            base.Move(x, y);
            moveHandlers();
        }

        private void moveHandlers()
        {
            handlers[0].Move(getX + getWidth / 2 - handlers[0].getWidth / 2,
                   getY + getHeight / 2 - handlers[0].getHeight / 2);
            handlers[1].Move(getX - handlers[0].getWidth / 2,
                    getY - handlers[0].getHeight / 2);
            handlers[2].Move(getX + getWidth - handlers[0].getWidth / 2,
                    getY - handlers[0].getHeight / 2);
            handlers[3].Move(getX + getWidth - handlers[0].getWidth / 2,
                    getY + getHeight - handlers[0].getHeight / 2);
            handlers[4].Move(getX - handlers[0].getWidth / 2,
                    getY + getHeight - handlers[0].getHeight / 2);
        }
    }
}
