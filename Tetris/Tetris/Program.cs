// See https://aka.ms/new-console-template for more information

using System.Reflection.Emit;
using System.Timers;
using Tetris;

namespace Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        private static System.Timers.Timer Timer;

        static private Object _lockObject = new object();

        static Figure currentFigure;
        static FigureGenerator generator;

        static void Main(string[] args)
        {

            Field.Width = 20;
            Field.Height = 20;

            generator = new FigureGenerator(Field.Width/ 2, 0, Drawer.DEFAULT_SYMBOL);
            currentFigure = generator.GetNewFigure();

            SetTimer();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigure, key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
            }
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            Timer = new System.Timers.Timer(TIMER_INTERVAL);
            // Hook up the Elapsed event for the timer. 
            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryToClearLine();
                currentFigure = generator.GetNewFigure();
                return true;
            }
            else 
                return false;   
        }

        private static Result HandleKey(Figure f, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return f.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return f.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return f.TryMove(Direction.DOWN);
                case ConsoleKey.Spacebar:
                    return f.TryRotate();
            }
            return Result.SUCCESS;
        }
    }
}


