using System;

namespace Maksym_Trokhymets_IS_93
{ 
    public class Triangle
    {
        public float FindArea(float _a, float _b, float _c)
        {
            if(_a < 0 || _b < 0 || _c < 0 || (_a + _b <= _c) || (_a + _c <= _b) || (_b + _c <= _a))
            {
                Console.WriteLine("Not valid triangle");
                System.Environment.Exit(0);
            }

            float result = (_a + _b + _c) / 2;

            Console.WriteLine("\nArea of triangle: ");

            return (float)Math.Sqrt(result * (result - _a) * (result - _b) * (result - _c));
        }
    }
}