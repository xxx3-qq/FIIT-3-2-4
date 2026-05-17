using System.Reflection.Emit;

namespace Hv10b
{
    class Program
    {
        static QuestionBank bank;
        static ExamGenerator generator;

        static void Main(string[] args)
        {
            bank = new QuestionBank();
            generator = new ExamGenerator(bank);

            bank.LoadFromFile("questions.txt");

            while (true)
            {
                Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ ===");
                Console.WriteLine("1. Проверка знаний (контрольные работы)");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                    QuizMenu();
                else if (choice == "0")
                    break;
                else
                    Console.WriteLine("Неверный выбор!");
            }
        }

        static void QuizMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== КОНТРОЛЬНЫЕ РАБОТЫ ===");
                Console.WriteLine("1. Сгенерировать варианты");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                    GenerateExam();
                else if (choice == "0")
                    break;
                else
                    Console.WriteLine("Неверный выбор!");
            }
        }

        static void GenerateExam()
        {
            Console.Write("Сколько вариантов? ");
            int variants = int.Parse(Console.ReadLine());

            Console.Write("Сколько вопросов в варианте? ");
            int questions = int.Parse(Console.ReadLine());

            Console.Write("Папка для сохранения: ");
            string dir = Console.ReadLine();

            generator.GenerateAndSave(variants, questions, dir);
            Console.WriteLine("Готово!");
        }
    }
}

