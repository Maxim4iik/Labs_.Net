using System;

namespace Maksym_Trokhymets_IS_93
{
    class Program
    {
        static void Main(string[] args)
        {
            IFigureFactory figureFactory = new TriangleFigureFactory();
            Triangle triangle = figureFactory.GetTriangle();

            Console.WriteLine(triangle.FindArea(3.0f, 4.0f, 5.0f));

            IFigureFactory figureFactory2 = new RectangleFigureFactory();
            Rectangle rectangle = figureFactory2.GetRectangle();

            Console.WriteLine(rectangle.FindArea(3, 5));
        }
    }
}
