using System;
using System.Collections.Generic;
using System.Drawing;
using MyPaint.Figures;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint.Selecting;

namespace MyPaint
{
    class FigureManager
    {
        private List<Figure> figures;
        private Manipulator manipulator;
        private bool mouseDown;

        public FigureManager()
        {
            manipulator = new Manipulator();
            figures = new List<Figure>();
            figures.AddRange(manipulator.GetHandlers);
        }
        
        public bool MouseIsDown => mouseDown;

        public void MouseDown()
        {
            mouseDown = true;
        }

        public void MouseUp()
        {
            mouseDown = false;
        }

        public void Add(Figure figure)
        {
            figures.Add(figure);
        }

        public Manipulator Manipulator
        {
            get => manipulator;
        }

        public void Draw(Graphics graphics)
        {
            if (manipulator.Selected != null)
                manipulator.Draw(graphics);
            foreach (Figure figure in figures)
            {
                if(!(figure is Handler))
                    figure.Draw(graphics);
            }
        }

        public Figure GetFigure(float x, float y)
        {
            for (int i = figures.Count - 1; i >= 0; i--)
            {
                if (figures[i].touch(x, y))
                    return figures[i];
            }

            return null;
        }

        public List<Figure> getFigures() => figures;
    }
}
