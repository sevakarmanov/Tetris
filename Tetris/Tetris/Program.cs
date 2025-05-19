// See https://aka.ms/new-console-template for more information

using System.Reflection.Emit;
using Tetris;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s = null;

            while (true)
            {
                FigureFall(s, generator);
                s.Draw();
            }

            //Figure s = generator.GetNewFigure();
            //s.Draw();

            //Thread.Sleep(200);

            //s.Hide();
            //s.Rotate();
            //s.Draw();

            //Thread.Sleep(500);

            //s.Hide();
            //s.Move(Direction.RIGHT);
            //s.Draw();

            //Thread.Sleep(500);

            //s.Hide();
            //s.Move(Direction.RIGHT);
            //s.Draw();

            //Thread.Sleep(500);

            //s.Hide();
            //s.Rotate();
            //s.Draw();

            //Figure[] f = new Figure[2];
            //f[0] = new Square(2, 5, '*');
            //f[1] = new Stick(4, 8, '#');

            //foreach (Figure fig in f)
            //{
            //    fig.Draw();
            //}

            //Stick st = new Stick(4, 8, '#');
            //st.Draw();

            //Point p1 = new Point(2, 3, '*');
            //p1.Draw();

            //Point p2 = new Point()
            //{
            //    x = 4,
            //    y = 5,
            //    c = '*'
            //};
            //p2.Draw();

            Console.ReadLine();
        }

        static void FigureFall(Figure fig, FigureGenerator generator)
        {
            fig = generator.GetNewFigure();
            fig.Draw();

            for (int i = 0; i < 15; i++)
            {
                fig.Hide();
                fig.Move(Direction.DOWN);
                fig.Draw();

                Thread.Sleep(200);
            }
        }
    }
}


