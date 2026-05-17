using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw10A
{
    internal class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        /// <summary>
        /// Конструктор класса Point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Находит расстояние
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public override string ToString()
        {
            return $"({X:F2}, {Y:F2})";
        }

    }
}
