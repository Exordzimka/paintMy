namespace MyPaint.History
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}