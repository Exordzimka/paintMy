using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private List<Figure> figuresStartProperties;
        private readonly UndoRedo undoRedo;
        private Stack<int> undoLevels;
        private Stack<int> redoLevels;

        public Picture()
        {
            undoRedo = new UndoRedo {Picture = this};
            rememberedComposite = new Dictionary<string, Figure>();
            tempGroup = new Composite();
            manipulator = new Manipulator();
            figures = new List<Figure>();
            figures.AddRange(manipulator.GetHandlers);
            figures.Add(tempGroup);
            undoLevels = new Stack<int>();
            redoLevels = new Stack<int>();
            figuresStartProperties = new List<Figure>();
        }

        public bool MouseIsDown => mouseDown;

        public bool CtrlIsDown => ctrlDown;

        public Composite GetTempGroup => tempGroup;

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
            mouseDown = true;
        }

        public void InitializeStartProperties()
        {
            startPositionX = Manipulator.Selected.getX;
            startPositionY = Manipulator.Selected.getY;
            startWidth = Manipulator.Selected.getWidth;
            startHeight = Manipulator.Selected.getHeight;
            figuresStartProperties.Clear();
            foreach (var figure in Manipulator.Selected.Figures)
            {
                figuresStartProperties.Add(figure.Clone());
            }
            
        }
        
        public void MouseUp()
        {
            var selected = Manipulator.Selected;
            var addedLevels = 0;
            if (ChangedPositionOfSelected() && ChangedSizeOfSelected())
            {
                for(var i=0;i<selected.Figures.Count;i++)
                {
                    var figure = selected.Figures[i];
                    var startFigure = figuresStartProperties[i];
                    undoRedo.InsertInUnDoRedoForMove(figure, figure.getX-startFigure.getX, figure.getY-startFigure.getY);
                    undoRedo.InsertInUnDoRedoForResize(figure, figure.getWidth-startFigure.getWidth, figure.getHeight-startFigure.getHeight);
                    addedLevels += 2;
                    redoLevels.Clear();
                }
                undoLevels.Push(addedLevels);
            }
            else
            {
                if (ChangedPositionOfSelected())
                {
                    for(var i=0;i<selected.Figures.Count;i++)
                    {
                        var figure = selected.Figures[i];
                        var startFigure = figuresStartProperties[i];
                        undoRedo.InsertInUnDoRedoForMove(figure, figure.getX-startFigure.getX, figure.getY-startFigure.getY);
                        addedLevels += 1;
                        redoLevels.Clear();
                    }
                    undoLevels.Push(addedLevels);
                }
                else if (ChangedSizeOfSelected())
                {
                    for(var i=0;i<selected.Figures.Count;i++)
                    {
                        var figure = selected.Figures[i];
                        var startFigure = figuresStartProperties[i];
                        undoRedo.InsertInUnDoRedoForResize(figure, figure.getWidth-startFigure.getWidth, figure.getHeight-startFigure.getHeight);
                        addedLevels += 1;
                        redoLevels.Clear();
                    }
                    undoLevels.Push(addedLevels);
                }
                
            }
            
                
            mouseDown = false;
        }

        private bool ChangedPositionOfSelected()
        {
            var selected = Manipulator.Selected;
            if (selected == null)
                return false;
            return Math.Abs(startPositionX - selected.getX) > 0 || Math.Abs(startPositionY - selected.getY) > 0;
        }

        private bool ChangedSizeOfSelected()
        {
            var selected = Manipulator.Selected;
            if (selected == null)
                return false;
            return Math.Abs(startWidth - selected.getWidth) > 0 || Math.Abs(startHeight - selected.getHeight) > 0;
        }
        
        public void Add(Figure figure, bool needToClear)
        {
            figures.Add(figure);
            undoLevels.Push(1);
            undoRedo.InsertInUnDoRedoForCreate(figure, needToClear);
            if (needToClear)
                redoLevels.Clear();
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
            foreach (var figure in figures.Where(figure => !(figure is Handler)))
            {
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
                ClearTempGroup();

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
            if (undoLevels.Count == 0) return;
            var levels = undoLevels.Pop();
            undoRedo.Undo(levels);
            redoLevels.Push(levels);
            manipulator.Attach(null);
            ClearTempGroup();
        }

        public void Redo()
        {
            if (redoLevels.Count == 0) return;
            var levels = redoLevels.Pop();
            undoRedo.Redo(levels);
            undoLevels.Push(levels);
            ClearTempGroup();
        }

        public void ClearTempGroup()
        {
            foreach (var figure in tempGroup.Figures)
            {
                figures.Add(figure);
            }
            tempGroup.Clear();
        }
    }
}
