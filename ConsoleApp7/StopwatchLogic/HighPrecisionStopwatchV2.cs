using System.Diagnostics;

namespace ConsoleApp7.StopwatchLogic
{
    public class HighPrecisionStopwatchV2
    {
        private readonly Stopwatch _stopwatch;

        public HighPrecisionStopwatchV2()
        {
            _stopwatch = new Stopwatch();
        }

        public void Start()
        {
            if (!_stopwatch.IsRunning)
            {
                _stopwatch.Start();
            }
        }

        public void Stop()
        {
            if (_stopwatch.IsRunning)
            {
                _stopwatch.Stop();
            }
        }

        public void Reset()
        {
            _stopwatch.Reset();
        }

        public double GetElapsedSeconds()
        {
            return _stopwatch.Elapsed.TotalSeconds;
        }
    }
}
