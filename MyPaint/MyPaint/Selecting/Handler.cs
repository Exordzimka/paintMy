using System.Drawing;
using MyPaint.Figures;

namespace MyPaint.Selecting
{
    public class Handler : Ellipse
    {
        private PointF startPoint;
        private static float diameter = 5;
        SolidBrush solidBrush;
        private Edges edge;
        public Handler()
        {
            Pen = new Pen(Color.Blue);
            solidBrush = new SolidBrush(Color.Blue);
            Resize(diameter, diameter);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pen, getX, getY, getWidth, getHeight);
            graphics.FillEllipse(solidBrush, getX, getY, getWidth, getHeight);
        }

        public override bool Touch(float x, float y)
        {
            startPoint.X = x;
            startPoint.Y = y;
            return base.Touch(x, y);
        }

        public Edges GetEdge => edge;

        public void SetEdge(Edges edge)
        {
            this.edge = edge;
        }

        public enum Edges
        {
            Center,
            TopLeft,
            TopRight,
            BotRight,
            BotLeft
        }

        public static float GetDiameter => diameter;
    }
}
