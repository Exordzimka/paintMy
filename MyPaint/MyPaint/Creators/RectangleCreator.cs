using MyPaint.Figures;

namespace MyPaint.Creators
{
    public class RectangleCreator : Creator
    {
        public override Figure CreateFigure(float x, float y, float width, float height)
        {
            Rectangle rect = new Rectangle();
            rect.Move(x, y);
            rect.Resize(width, height);
            return rect;
        }
    }
}
