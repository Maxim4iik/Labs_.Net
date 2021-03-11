using System;
namespace Maksym_Trokhymets_IS_93
{
    public class RectangleFigureFactory : IFigureFactory
    {
        public Triangle GetTriangle()
        {
            return new Triangle();
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle();
        }
    }
}
