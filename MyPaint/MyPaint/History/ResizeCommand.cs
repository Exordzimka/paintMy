using MyPaint.Figures;

namespace MyPaint.History
{
    public class ResizeCommand : ICommand
    {
        private readonly float changeOfWidth;
        private readonly float changeOfHeight;
        private readonly Figure figure;

        public ResizeCommand(float width, float height, Figure figure)
        {
            changeOfWidth = width;
            changeOfHeight = height;
            this.figure = figure;
        }

        public void Execute()
        {
            figure.Resize(figure.getWidth + changeOfWidth, figure.getHeight + changeOfHeight);
        }

        public void UnExecute()
        {
            figure.Resize(figure.getWidth - changeOfWidth, figure.getHeight - changeOfHeight);
        }
    }
}