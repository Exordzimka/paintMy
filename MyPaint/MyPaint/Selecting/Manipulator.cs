using System;
using System.Collections.Generic;
using System.Data;
using MyPaint.Figures;
using MyPaint.Selecting;
using System.Drawing;

namespace MyPaint
{
    class Manipulator : Figure
    {
        private PointF pointTouch;
        private Figure selected;
        private float different = 3;
        List<Handler> handlers;
        private Handler selectedHandler;
        public Manipulator()
        {
            handlers = new List<Handler>(5);
            for (int i = 0; i < 5; i++)
            {
                handlers.Add(new Handler());
                handlers[i].SetEdge((Handler.Edges)i);
            }
            
            Pen = new Pen(Color.Blue);
        }

        public Figure Selected { get => selected; }

        public void Attach(Figure figure)
        {
            selected = figure;
            if (selected != null)
            {
                Resize(selected.getWidth + different * 2, selected.getHeight + different * 2);
                Move(selected.getX - different, selected.getY - different);
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
            if (GetSelectedHandler == null) return;
            PointF pointDiff = new PointF(x-GetTouchPoint().X, y-GetTouchPoint().Y);
            SetTouchPoint(x,y);
            switch (GetSelectedHandler.GetEdge)
            {
                case Handler.Edges.Center:
                    Move(getX + pointDiff.X, getY + pointDiff.Y);
                    break;
                case Handler.Edges.TopLeft:
                    Move(getX + pointDiff.X, getY + pointDiff.Y);
                    Resize(getWidth - pointDiff.X, getHeight - pointDiff.Y);
                    break;
                case Handler.Edges.TopRight:
                    Move(getX, getY + pointDiff.Y);
                    Resize(getWidth + pointDiff.X, getHeight - pointDiff.Y);
                    break;
                case Handler.Edges.BotLeft:
                    Move(getX + pointDiff.X, getY);
                    Resize(getWidth - pointDiff.X, getHeight + pointDiff.Y);
                    break;
                case Handler.Edges.BotRight:
                    Move(getX, getY);
                    Resize(getWidth + pointDiff.X, getHeight + pointDiff.Y);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Handler GetSelectedHandler => selectedHandler;

        public List<Handler> GetHandlers => handlers;

        public void SetSelectedHandler(Figure selectedFigure)
        {
            selectedHandler = (Handler)selectedFigure;
        }

        public void SetTouchPoint(float x, float y)
        {
            pointTouch.X = x;
            pointTouch.Y = y;
        }

        public PointF GetTouchPoint()
        {
            return pointTouch;
        }
        
        public override void Move(float x, float y)
        {
            base.Move(x, y);
            selected.Move(x+different, y+different);
            MoveHandlers();
        }

        public override void Resize(float width, float height)
        {
            base.Resize(width, height);
            selected.Resize(width-different*2, height-different*2);
            MoveHandlers();
        }

        private void MoveHandlers()
        {
            foreach (var handler in handlers)
            {
                PointF point = GetEdgeCoordinate(handler.GetEdge);
                handler.Move(point.X, point.Y);
            }
        }

        private void ChangesHandlesEdges()
        {
            PointF center = GetEdgeCoordinate(Handler.Edges.Center);
            foreach (var handler in handlers)
            {
                handler.SetEdge(whichEdgeCloser(handler.GetCenter, handler.GetEdge));
            }
            MoveHandlers();
        }

        private Handler.Edges whichEdgeCloser(PointF coordinates, Handler.Edges handlerEdge)
        {
            float different = float.MaxValue;
            Handler.Edges closestEdge = Handler.Edges.Center;
            foreach (Handler.Edges edge in Enum.GetValues(typeof(Handler.Edges)))
            {
                PointF currentEdge = GetEdgeCoordinate(edge);
                float lenOfLine = GetLenOfLine(coordinates, currentEdge);
                if (lenOfLine < different)
                {
                    closestEdge = edge;
                    different = lenOfLine;
                }
            }

            return closestEdge;
        }
        
        private PointF GetEdgeCoordinate(Handler.Edges edge)
        {
            PointF coordinates;
            switch (edge)
            {
                case Handler.Edges.Center:
                    coordinates = new PointF(getX + getWidth / 2 - Handler.GetDiameter/2,
                    getY + getHeight / 2 - Handler.GetDiameter/2);
                    break;
                case Handler.Edges.TopLeft:
                    coordinates = new PointF(getX - Handler.GetDiameter/2,
                        getY - Handler.GetDiameter/2);
                    break;
                case Handler.Edges.TopRight:
                    coordinates = new PointF(getX + getWidth - Handler.GetDiameter/2,
                        getY - Handler.GetDiameter/2);
                    break;
                case Handler.Edges.BotRight:
                    coordinates = new PointF(getX + getWidth - Handler.GetDiameter/2,
                        getY + getHeight - Handler.GetDiameter/2);
                    break;
                case Handler.Edges.BotLeft:
                    coordinates = new PointF(getX - Handler.GetDiameter/2,
                        getY + getHeight - Handler.GetDiameter/2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(edge), edge, null);
            }

            return coordinates;
        }

        private float GetLenOfLine(PointF start, PointF end)
        {
            return (float) Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.X, 2));
        }
    }
}
