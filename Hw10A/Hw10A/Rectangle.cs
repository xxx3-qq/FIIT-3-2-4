using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw10A
{
    internal class Rectangle
    {
        public Point TopLeft { get; private set; }
        public Point TopRight { get; private set; }
        public Point BottomLeft { get; private set; }
        public Point BottomRight { get; private set; }
        public Point Center { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }
        /// <summary>
        /// Конструктор класса Rectangle
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <exception cref="ArgumentException"></exception>
        public Rectangle(Point p1, Point p2)
        {
            double minX = Math.Min(p1.X, p2.X);
            double maxX = Math.Max(p1.X, p2.X);
            double minY = Math.Min(p1.Y, p2.Y);
            double maxY = Math.Max(p1.Y, p2.Y);

            Width = maxX - minX;
            Height = maxY - minY;

            TopLeft = new Point(minX, maxY);
            TopRight = new Point(maxX, maxY);
            BottomLeft = new Point(minX, minY);
            BottomRight = new Point(maxX, minY);
            Center = new Point((minX + maxX) / 2, (minY + maxY) / 2);
        }
        /// <summary>
        /// Находит площадь прямоугольника
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            return Width * Height;
        }
        /// <summary>
        /// Находит периметр прямоугольника
        /// </summary>
        /// <returns></returns>
        public double Perimeter()
        {
             return 2 * (Width + Height);
        }
        /// <summary>
        /// Расстояние от центра до ближайшего угла
        /// </summary>
        /// <returns></returns>
        public double DistanceFromCentreToRect()
        {
            Point centre = new Point(0, 0);
            Point closest = GetClosestRect(centre);
            return centre.DistanceTo(closest);
            Point GetClosestRect(Point point)
            {
                var c = new[] { TopLeft, TopRight, BottomLeft, BottomRight };
                Point closest = c[0];
                double minDist = point.DistanceTo(closest);

                foreach (var c1 in c)
                {
                    double dist = point.DistanceTo(c1);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closest = c1;
                    }
                }
                return closest;
            }
        }
        /// <summary>
        /// Поворачивает прямоугольник на альфа градусов вокруг своего центра
        /// </summary>
        /// <param name="alpha"></param>
        public void Rotate(double alpha)
        {
            double corn = alpha * Math.PI / 180.0;
            double cos = Math.Cos(corn);
            double sin = Math.Sin(corn);
            Point RotatePoint(Point p)
            {
                double dx = p.X - Center.X;
                double dy = p.Y - Center.Y;
                double newX = Center.X + dx * cos - dy * sin;
                double newY = Center.Y + dx * sin + dy * cos;
                return new Point(newX, newY);
            }
            TopLeft = RotatePoint(TopLeft);
            TopRight = RotatePoint(TopRight);
            BottomLeft = RotatePoint(BottomLeft);
            BottomRight = RotatePoint(BottomRight);
            Width = TopLeft.DistanceTo(TopRight);
            Height = TopLeft.DistanceTo(BottomLeft);
        }
        /// <summary>
        /// Перемещает прямоугольник на X и Y
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public void Sdvig(double dx, double dy)
        {
            TopLeft = new Point(TopLeft.X + dx, TopLeft.Y + dy);
            TopRight = new Point(TopRight.X + dx, TopRight.Y + dy);
            BottomLeft = new Point(BottomLeft.X + dx, BottomLeft.Y + dy);
            BottomRight = new Point(BottomRight.X + dx, BottomRight.Y + dy);
            Center = new Point(Center.X + dx, Center.Y + dy);
        }
        /// <summary>
        /// Увеличение размеров прямоугольника
        /// </summary>
        /// <param name="widthK"></param>
        /// <param name="heightK"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Uvelich(double widthK, double heightK)
        {
            if (widthK <= 0 || heightK <= 0)
                throw new ArgumentException("Коэффициенты должны быть положительными");

            double newWidth = Width * widthK;
            double newHeight = Height * heightK;
            double halfWidth = newWidth / 2;
            double halfHeight = newHeight / 2;

            TopLeft = new Point(Center.X - halfWidth, Center.Y + halfHeight);
            TopRight = new Point(Center.X + halfWidth, Center.Y + halfHeight);
            BottomLeft = new Point(Center.X - halfWidth, Center.Y - halfHeight);
            BottomRight = new Point(Center.X + halfWidth, Center.Y - halfHeight);

            Width = newWidth;
            Height = newHeight;
        }
        public override string ToString()
        {
            return $"Центр: {Center}, Размеры: {Width:F2} x {Height:F2}";
        }
    }
}
