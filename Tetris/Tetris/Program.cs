// See https://aka.ms/new-console-template for more information

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Square s = new Square(2, 5, '*');
            s.Draw();

            Stick st = new Stick(4, 8, '#');
            st.Draw();

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
    }
}

