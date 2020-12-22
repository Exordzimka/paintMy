using MyPaint.Figures;

namespace MyPaint.History
{
    public class CreateCommand : ICommand
    {
        private Figure figure;
        private Picture picture;

        public CreateCommand(Picture picture, Figure figure)
        {
            this.picture = picture;
            this.figure = figure;
        }

        public void Execute()
        {
            picture.Add(figure, false);
        }

        public void UnExecute()
        {
            picture.Remove(figure);
        }
    }
}