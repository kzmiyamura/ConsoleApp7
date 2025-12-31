using System;
using System.Threading;

namespace ConsoleAppStopwatch
{
    class StopwatchService
    {
        private double _elapsedSeconds;
        private bool _isRunning;
        private readonly object _lock = new object();

        public bool IsRunning
        {
            get { lock (_lock) { return _isRunning; } }
        }

        public void ToggleStartStop()
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

        public double ElapsedSeconds
        {
            get { lock (_lock) { return _elapsedSeconds; } }
        }

        public void Run()
        {
            var lastTime = DateTime.UtcNow;
            while (true)
            {
                Thread.Sleep(10); // 0.01秒刻み
                if (_isRunning)
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
                    // 停止中も基準時間更新
                    lastTime = DateTime.UtcNow;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new StopwatchService();
            var stopwatchThread = new Thread(stopwatch.Run)
            {
                IsBackground = true
            };
            stopwatchThread.Start();

            Console.WriteLine("ストップウォッチ開始: Space で開始/停止, Delete/Backspace でリセット, Enter で終了");

            while (true)
            {
                // 表示更新
                Console.SetCursorPosition(0, 1);
                var totalSeconds = stopwatch.ElapsedSeconds;
                int minutes = (int)(totalSeconds / 60);
                double seconds = totalSeconds % 60;
                Console.Write($"{minutes:D2}:{seconds:00.00}");

                // キー入力の確認
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Spacebar)
                        stopwatch.ToggleStartStop();
                    else if (key == ConsoleKey.Delete || key == ConsoleKey.Backspace)
                        stopwatch.Reset();
                    else if (key == ConsoleKey.Enter)
                        break;
                }

                Thread.Sleep(10); // 表示更新間隔
            }
        }
    }
}
