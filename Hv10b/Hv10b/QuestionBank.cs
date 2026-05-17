using System;
using System.Collections.Generic;
using System.Text;

namespace Hv10b
{
    public class QuestionBank
    {
        private List<Question> _questions = new List<Question>();

        public int Count => _questions.Count;

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Файл {filename} не найден. Создана демо-база.");
                CreateDemoBank();
                return;
            }

            _questions.Clear();
            var lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');
                if (parts.Length >= 2)
                {
                    string hint = parts.Length >= 3 ? parts[2] : null;
                    _questions.Add(new Question(parts[0], parts[1], hint));
                }
            }

            Console.WriteLine($"Загружено {_questions.Count} вопросов из {filename}");
        }


        private void CreateDemoBank()
        {
            _questions.Add(new Question("Сколько будет 2 + 2?", "4", "Сложи два числа"));
            _questions.Add(new Question("Сколько будет 3 * 3?", "9", "Трижды три"));
            _questions.Add(new Question("Корень из 64?", "8", "Какое число в квадрате даёт 64?"));
            _questions.Add(new Question("Сколько дней в неделе?", "7", "Понедельник, вторник..."));
            _questions.Add(new Question("Чему равен прямой угол?", "90", "Градусы"));
        }

        public List<Question> GetRandomQuestions(int count)
        {
            if (count > _questions.Count)
                count = _questions.Count;

            Random rnd = new Random();
            List<Question> result = new List<Question>();
            List<Question> temp = new List<Question>(_questions);

            for (int i = 0; i < count; i++)
            {
                int index = rnd.Next(temp.Count);
                result.Add(temp[index]);
                temp.RemoveAt(index);
            }

            return result;
        }
    }
}
