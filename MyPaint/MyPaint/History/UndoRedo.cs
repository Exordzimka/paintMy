using System.Collections.Generic;
using MyPaint.Figures;

namespace MyPaint.History
{
    public class UndoRedo
    {
        private readonly Stack<ICommand> undocommands = new Stack<ICommand>();
        private readonly Stack<ICommand> redocommands = new Stack<ICommand>();

        public Picture Picture { get; set; }

        public void Redo(/*int levels*/)
        {
            // for (int i = 1; i <= levels; i++)
            // {
                if (redocommands.Count != 0)
                {
                    ICommand command = redocommands.Pop();
                    command.Execute();
                    undocommands.Push(command);
                }
                Picture.Manipulator.Attach(null);
            // }
        }

        public void Undo(/*int levels*/)
        {
            // for (int i = 1; i <= levels; i++)
            // {
                if (undocommands.Count != 0)
                {
                    ICommand command = undocommands.Pop();
                    command.UnExecute();
                    redocommands.Push(command);
                }
                Picture.Manipulator.Attach(null);
            // }
        }

        public void InsertInUnDoRedoForCreate(Figure figure)
        {
            ICommand cmd = new CreateCommand(Picture, figure);
            undocommands.Push(cmd);
            redocommands.Clear();
        }
        
        public void InsertInUnDoRedoForMove(Figure figure, float changeX, float changeY)
        {
            ICommand cmd = new MoveCommand(changeX, changeY, figure);
            undocommands.Push(cmd);
            redocommands.Clear();
        }

        public void InsertInUnDoRedoForResize(Figure figure,float changeWidth, float changeHeight)
        {
            ICommand cmd = new ResizeCommand(changeWidth, changeHeight, figure);
            undocommands.Push(cmd);
            redocommands.Clear();
        }
    }
}