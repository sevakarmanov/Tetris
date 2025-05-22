// See https://aka.ms/new-console-template for more information

using System.Reflection.Emit;
using Tetris;

namespace Tetris
{
    class Program
    {
        static Figure currentFigure;
        static FigureGenerator generator;
        static void Main(string[] args)
        {

            Field.Width = 40;
            Field.Height = 30;

            generator = new FigureGenerator(Field.Width/ 2, 0, '*');
            currentFigure = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandleKey(currentFigure, key);
                    ProcessResult(result, ref currentFigure);
                }

            }
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
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


