using System;
using System.Threading;

namespace ConsoleApp7.StopwatchLogic
{
    public class HighPrecisionStopwatch
    {
        private double _elapsedSeconds = 0;
        private bool _isRunning = false;
        private readonly object _lock = new object();

        public double ElapsedSeconds
        {
            get
            {
                lock (_lock)
                {
                    return _elapsedSeconds;
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                lock (_lock)
                {
                    return _isRunning;
                }
            }
        }

        public void StartStopToggle()
        {
            lock (_lock)
            {
                _isRunning = !_isRunning;
            }
        }

        public void Reset()
        {
            lock (_lock)
            {
                _elapsedSeconds = 0;
            }
        }

        public void Run()
        {
            var lastTime = DateTime.UtcNow;
            while (true)
            {
                Thread.Sleep(10); // 0.01秒刻み
                if (IsRunning)
                {
                    var now = DateTime.UtcNow;
                    var delta = (now - lastTime).TotalSeconds;
                    lock (_lock)
                    {
                        _elapsedSeconds += delta;
                    }
                    lastTime = now;
                }
                else
                {
                    // 停止中は基準時間を更新
                    lastTime = DateTime.UtcNow;
                }
            }
        }
    }
}
