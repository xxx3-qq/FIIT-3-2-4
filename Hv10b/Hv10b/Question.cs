using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Hv10b
{
    public class Question
    {
        public string Text { get; set; }  
        public string CorrectAnswer { get; set; } 

        private string _hint;


        public Question(string text, string correctAnswer, string hint = null)
        {
            Text = text;
            CorrectAnswer = correctAnswer;

            if (hint == null)
                _hint = "Подумайте внимательнее";
            else
                _hint = hint;
        }

        public string GetHint()
        {
            return _hint;
        }

        public bool CheckAnswer(string userAnswer)
        {

            if (userAnswer == null)
            {
                return false;
            }

            if (userAnswer.ToLower() == CorrectAnswer.ToLower())
            {
                return true;
            }

            return false;
        }
    }
}
