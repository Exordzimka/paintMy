using System.Collections.Generic;
using MyPaint.Figures;

namespace MyPaint.Creators
{
    public class PrototypeCreator : Creator
    {
        private Figure rememberedComposite; 
        public override Figure CreateFigure(float x, float y, float width, float height)
        {
            rememberedComposite.Move(x,y);
            return rememberedComposite;
        }

        public void RememberComposite(Figure figure)
        {
            rememberedComposite = figure.Clone();
        }
    }
}