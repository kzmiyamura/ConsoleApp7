// IStopwatch.cs
namespace ConsoleApp7.StopwatchLogic
{
    public interface IStopwatch
    {
        void Start();
        void Stop();
        void Reset();
        double ElapsedSeconds { get; }
    }
}