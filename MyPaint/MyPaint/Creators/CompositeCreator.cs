using MyPaint.Figures;

namespace MyPaint.Creators
{
    public class CompositeCreator : Creator
    {
        public override Figure CreateFigure(float x, float y, float width, float height)
        {
            Composite composite = new Composite();
            /*Rectangle rectangle = new Rectangle();
            Ellipse ellipse = new Ellipse();
            rectangle.Move(0,0);
            rectangle.Resize(50,50);
            ellipse.Move(70,60);
            ellipse.Resize(50,50);
            composite.AddFigure(rectangle);
            composite.AddFigure(ellipse);
            composite.Move(x,y);*/
            return composite;
        }
    }
}