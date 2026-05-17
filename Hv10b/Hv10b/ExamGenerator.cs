using System;
using System.Collections.Generic;
using System.Text;

namespace Hv10b
{
    public class ExamGenerator
    {
        private QuestionBank _bank;

        public ExamGenerator(QuestionBank bank)
        {
            _bank = bank;
        }

        public void GenerateAndSave(int variantCount, int questionsPerVariant, string outputDir)
        {
            System.IO.Directory.CreateDirectory(outputDir);

            Random rnd = new Random();

            for (int v = 1; v <= variantCount; v++)
            {
                List<Question> questions = _bank.GetRandomQuestions(questionsPerVariant);

                System.IO.StreamWriter file1 = new System.IO.StreamWriter(outputDir + "\\var" + v + ".txt");
                file1.WriteLine("Вариант " + v);
                file1.WriteLine("");

                for (int i = 0; i < questions.Count; i++)
                {
                    file1.WriteLine((i + 1) + ". " + questions[i].Text);
                    file1.WriteLine("Ответ: ________");
                    file1.WriteLine("");
                }

                file1.Close();

                System.IO.StreamWriter file2 = new System.IO.StreamWriter(outputDir + "\\podskazki" + v + ".txt");
                file2.WriteLine("Подсказки к варианту " + v);
                file2.WriteLine("");

                for (int i = 0; i < questions.Count; i++)
                {
                    file2.WriteLine("Задание " + (i + 1) + ": " + questions[i].GetHint());
                    file2.WriteLine("");
                }

                file2.Close();

                Console.WriteLine("Вариант " + v + " готов");
            }
        }
    }
}
