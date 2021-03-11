using System;
namespace Maksym_Trokhymets_IS_93
{
    public interface IFigureFactory
    {
        public Triangle GetTriangle();

        public Rectangle GetRectangle();
    }
}
