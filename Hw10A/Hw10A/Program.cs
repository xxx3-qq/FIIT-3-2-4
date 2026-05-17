namespace Hw10A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var simulator = new RectangleSimulator();

            simulator.AddRectangle(new Point(0, 0), new Point(5, 3));
            simulator.AddRectangle(new Point(2, 2), new Point(6, 2));
            simulator.AddRectangle(new Point(-3, -2), new Point(1, -2));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Все прямоугольники");
                Console.WriteLine("2 - Наиболее удалённый");
                Console.WriteLine("3 - Повернуть");
                Console.WriteLine("4 - Переместить");
                Console.WriteLine("5 - Увеличить");
                Console.WriteLine("6 - Площадь > 15");
                Console.WriteLine("7 - Добавить");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0") break;

                var all = simulator.RectanglesPred(r => true);

                if (choice == "1")
                {
                    Console.WriteLine("Все прямоугольники:");
                    for (int i = 0; i < all.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {all[i]}");
                        Console.WriteLine($"Углы: {all[i].TopLeft}, {all[i].TopRight}, {all[i].BottomRight}, {all[i].BottomLeft}");
                        Console.WriteLine($"Площадь: {all[i].Area()}");
                        Console.WriteLine($"Периметр: {all[i].Perimeter()}");
                    }
                }
                else if (choice == "2")
                {
                    Rectangle mostDistant = simulator.MostDistantRectangle();
                    Console.WriteLine("Наиболее удалённый:");
                    Console.WriteLine(mostDistant);
                    Console.WriteLine($"Расстояние: {mostDistant.DistanceFromCentreToRect()}");
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Выберите номер:");
                    for (int i = 0; i < all.Length; i++) Console.WriteLine($"{i + 1}. {all[i]}");
                    int num = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Угол: ");
                    double angle = double.Parse(Console.ReadLine());
                    Console.WriteLine($"До: {all[num]}");
                    all[num].Rotate(angle);
                    Console.WriteLine($"После: {all[num]}");
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Выберите номер:");
                    for (int i = 0; i < all.Length; i++) Console.WriteLine($"{i + 1}. {all[i]}");
                    int num = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("dx: ");
                    double dx = double.Parse(Console.ReadLine());
                    Console.Write("dy: ");
                    double dy = double.Parse(Console.ReadLine());
                    Console.WriteLine($"До: {all[num]}");
                    all[num].Sdvig(dx, dy);
                    Console.WriteLine($"После: {all[num]}");
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Выберите номер:");
                    for (int i = 0; i < all.Length; i++) Console.WriteLine($"{i + 1}. {all[i]}");
                    int num = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Коэф ширины: ");
                    double wk = double.Parse(Console.ReadLine());
                    Console.Write("Коэф высоты: ");
                    double hk = double.Parse(Console.ReadLine());
                    Console.WriteLine($"До: {all[num]}");
                    Console.WriteLine($"Площадь: {all[num].Area()}, Периметр: {all[num].Perimeter()}");
                    all[num].Uvelich(wk, hk);
                    Console.WriteLine($"После: {all[num]}");
                    Console.WriteLine($"Площадь: {all[num].Area()}, Периметр: {all[num].Perimeter()}");
                }
                else if (choice == "6")
                {
                    Rectangle[] result = simulator.RectanglesPred(r => r.Area() > 15);
                    Console.WriteLine("Площадь больше 15:");
                    foreach (Rectangle r in result) Console.WriteLine($"{r} - площадь {r.Area()}");
                }
                else if (choice == "7")
                {
                    Console.Write("x1: "); double x1 = double.Parse(Console.ReadLine());
                    Console.Write("y1: "); double y1 = double.Parse(Console.ReadLine());
                    Console.Write("x2: "); double x2 = double.Parse(Console.ReadLine());
                    Console.Write("y2: "); double y2 = double.Parse(Console.ReadLine());
                    simulator.AddRectangle(new Point(x1, y1), new Point(x2, y2));
                    Console.WriteLine("Добавлено!");
                }

                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }
    }
}
