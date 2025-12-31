using ConsoleApp7.StopwatchLogic;
using System;
using System.Threading;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new HighPrecisionStopwatchV2();

            bool isRunning = false;
            bool exitRequested = false;

            Console.CursorVisible = false;

            while (!exitRequested)
            {
                // キー入力処理
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.Spacebar:
                            if (isRunning)
                            {
                                stopwatch.Stop();
                                isRunning = false;
                            }
                            else
                            {
                                stopwatch.Start();
                                isRunning = true;
                            }
                            break;

                        case ConsoleKey.Backspace: // mac対応
                            stopwatch.Reset();
                            isRunning = false;
                            break;

                        case ConsoleKey.Enter:
                            exitRequested = true;
                            break;
                    }
                }

                // 表示
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(FormatTime(stopwatch.GetElapsedSeconds()));
                Console.WriteLine("Space: Start/Stop  Backspace: Reset  Enter: Exit");

                Thread.Sleep(100); // 0.1秒更新
            }

            Console.CursorVisible = true;
        }

        static string FormatTime(double seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);
            return $"{time.Minutes:D2}:{time.Seconds:D2}.{time.Milliseconds / 100:D1}";
        }
    }
}
