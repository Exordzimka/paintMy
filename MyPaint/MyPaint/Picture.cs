using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MyPaint.Figures;
using MyPaint.Selecting;
using MyPaint.History;

namespace MyPaint
{
    public class Picture
    {
        private readonly List<Figure> figures;
        private readonly Manipulator manipulator;
        private bool mouseDown;
        private bool ctrlDown;
        private Figure rememberedFigure;
        private readonly Composite tempGroup;
        private readonly Dictionary<string, Figure> rememberedComposite;
        private float startPositionX;
        private float startPositionY;
        private float startWidth;
        private float startHeight;
        private readonly UndoRedo undoRedo;

        public Picture()
        {
            undoRedo = new UndoRedo {Picture = this};
            rememberedComposite = new Dictionary<string, Figure>();
            tempGroup = new Composite();
            manipulator = new Manipulator();
            figures = new List<Figure>();
            figures.AddRange(manipulator.GetHandlers);
            figures.Add(tempGroup);
        }

        public bool MouseIsDown => mouseDown;

        public bool CtrlIsDown => ctrlDown;

        public Figure GetTempGroup => tempGroup;

        public void CtrlDown()
        {
            ctrlDown = true;
        }

        public void CtrlUp()
        {
            ctrlDown = false;
        }

        public void MouseDown()
        {
            if (Manipulator.Selected != null)
            {
                startPositionX = Manipulator.Selected.getX;
                startPositionY = Manipulator.Selected.getY;
                startWidth = Manipulator.Selected.getWidth;
                startHeight = Manipulator.Selected.getHeight;
            }
            mouseDown = true;
        }

        public void MouseUp()
        {
            var selected = Manipulator.Selected;
            if (ChangedPositionOfSelected())
                undoRedo.InsertInUnDoRedoForMove(selected, selected.getX-startPositionX, selected.getY-startPositionY);
            if(ChangedSizeOfSelected())
                undoRedo.InsertInUnDoRedoForResize(selected, selected.getWidth-startWidth, selected.getHeight-startHeight);
            mouseDown = false;
        }

        private bool ChangedPositionOfSelected()
        {
            var selected = Manipulator.Selected;
            if (selected == null)
                return false;
            return startPositionX != selected.getX || startPositionY != selected.getY;
        }

        private bool ChangedSizeOfSelected()
        {
            var selected = Manipulator.Selected;
            if (selected == null)
                return false;
            return startWidth != selected.getWidth || startHeight != selected.getHeight;
        }
        
        public void Add(Figure figure)
        {
            figures.Add(figure);
            undoRedo.InsertInUnDoRedoForCreate(figure);
        }

        public void Remove(Figure figure)
        {
            figures.Remove(figure);
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
                if (!(figure is Handler))
                    figure.Draw(graphics);
            }
        }

        public Figure GetFigure(float x, float y)
        {
            for (int i = figures.Count - 1; i >= 0; i--)
            {
                if (figures[i].Touch(x, y))
                {
                    if (figures[i] != tempGroup && figures[i] is Handler == false)
                    {
                        if (tempGroup.Figures.Contains(figures[i]) == false)
                        {
                            if (CtrlIsDown == false)
                            {
                                figures.AddRange(tempGroup.Figures);
                                tempGroup.Clear();
                            }
                            tempGroup.AddFigure(figures[i]);
                            figures.RemoveAt(i);
                        }
                        return tempGroup;
                    }
                    return figures[i];
                }
            }
            
            if (tempGroup.Figures.Count != 0)
            {
                foreach (var figure in tempGroup.Figures)
                {
                    figures.Add(figure);
                }

                tempGroup.Clear();
            }

            return null;
        }

        public void Group(Composite group)
        {
            Composite newGroup = new Composite();
            if (group == tempGroup )
            {
                foreach (var figure in group.Figures)
                {
                    newGroup.AddFigure(figure);
                }

                figures.Add(newGroup);
                group.Clear();
            }
        }

        public void Ungroup(Composite group)
        {
            foreach (var figure in group.Figures)
            {
                figures.Add(figure);
            }
            group.Clear();
            Manipulator.Attach(null);
        }

        public List<Figure> getFigures() => figures;

        public void RememberComposite(Figure figure)
        {
            string index = "remembered" + rememberedComposite.Count;
            rememberedComposite.Add(index, figure);
        }

        public Dictionary<string, Figure> GetRememberedComposites => rememberedComposite;

        public Figure RememberedFigure() => rememberedFigure;

        public void RememberFigure(Figure figure)
        {
            rememberedFigure = figure;
        }

        public void Undo()
        {
            undoRedo.Undo();
        }

        public void Redo()
        {
            undoRedo.Redo();
        }
    }
}
