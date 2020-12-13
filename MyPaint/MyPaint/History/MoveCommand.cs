using MyPaint.Figures;

namespace MyPaint.History
{
    public class MoveCommand : ICommand
    {
        private readonly float changeOfX;
        private readonly float changeOfY;
        private readonly Figure figure;

        public MoveCommand(float x, float y, Figure figure)
        {
            changeOfX = x;
            changeOfY = y;
            this.figure = figure;
        }
        
        public void Execute()
        {
            figure.Move(figure.getX + changeOfX, figure.getY + changeOfY);
        }

        public void UnExecute()
        {
            figure.Move(figure.getX - changeOfX, figure.getY - changeOfY);
        }
    }
}