using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw10A
{
    internal class RectangleSimulator
    {
        private List<Rectangle> rectangles = new List<Rectangle>();
        /// <summary>
        /// Добавление прямоугольника
        /// </summary>
        /// <param name="rect"></param>
        public void AddRectangle(Rectangle rect)
        {
            rectangles.Add(rect);
        }
        /// <summary>
        /// Добавление прямоугольника по двум точкам
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public void AddRectangle(Point p1, Point p2)
        {
            rectangles.Add(new Rectangle(p1, p2));
        }
        /// <summary>
        /// Получение массива прямоугольников согласно заданному предикату.
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public Rectangle[] RectanglesPred(Predicate<Rectangle> pred)
        {
            return rectangles.Where(r => pred(r)).ToArray();
        }
        /// <summary>
        /// Определение наиболее удалённого от центра координат прямоугольника.
        /// </summary>
        /// <returns></returns>
        public Rectangle MostDistantRectangle()
        {
            if (rectangles.Count == 0)
                return null;
            return rectangles.OrderByDescending(r => r.DistanceFromCentreToRect()).First();
        }

    }
}
