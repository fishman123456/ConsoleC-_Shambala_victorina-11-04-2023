using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleC_Shambala_victorina_11_04_2023
{
    
    public class Victorina_questions_ansver
    {
        public string Questions { get; set; }
        public string [] Ansver { get; set; } 
       

       // public string retmenu;

        public Victorina_questions_ansver() { }
        public Victorina_questions_ansver(string  questions, string [] ansver)
        {
            Questions = questions;
            Ansver = ansver;
        }
      
        public void MethodAdd()
        {
            Console.WriteLine("Введите вопрос: ");
            string question = Console.ReadLine();
            Questions = question;
            Console.WriteLine("Введите варианты ответов: ");
            Console.WriteLine("Для окончания введите *");
            int length = 100;
            for (int i = 0; i < length; i++)
            {
            string ansver = Console.ReadLine();
                if (Console.ReadLine() == "*") { break; }
            // добавление вопроса и ответа в поля обьекта
            Ansver [i] = ansver;
            }

            Console.WriteLine("Вопрос и ответы добавлены");
        }

        public override string ToString()
        {
            foreach (string que in Questions) { Console.WriteLine("Вопрос - " + que); }
            foreach (string ans in Ansver) { Console.WriteLine("Ответ - " + ans); }
            
            //return ("English " + Ansver.ToString() +"\t" + "Russian " + Questions.ToString());
            return "";
        }
    }
}
