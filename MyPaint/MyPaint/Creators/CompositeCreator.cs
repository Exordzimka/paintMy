﻿using MyPaint.Figures;

namespace MyPaint.Creators
{
    public class CompositeCreator : Creator
    {
        private Figure rememberedComposite; 
        public override Figure CreateFigure(float x, float y, float width, float height)
        {
            Composite composite = new Composite();
            if (rememberedComposite != null)
                return rememberedComposite;
            return composite;
        }
        
        public void RememberComposite(Figure figure)
        {
            rememberedComposite = figure.Clone();
        }
    }
}