using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleC_Shambala_victorina_11_04_2023
{
    internal class ClassVictorin
    {
        //создание списка обьектов
        public List <Victorina_questions_ansver> dictions = new List<Victorina_questions_ansver>();

        // добавление обьекта
        public void AddObject(Victorina_questions_ansver obj)
        {
            dictions.Add(obj);
        }

        // поиск и удаление строк
        public void MethodDeleteEngRuss() // 
        {
            //Victorina_ansver_questions ob = new Victorina_ansver_questions();
            Console.WriteLine("Введите слово для удаления\\изменения ");
            var str = Console.ReadLine();
            int delelement = 0;
            int delelementnumber = 0;
            foreach (Victorina_questions_ansver obj2 in dictions)
            {
               
                if (obj2.Ansver.Contains(str) || (obj2.Questions.Contains(str)))
                {
                    Console.WriteLine("Удаляем ответ\\вопрос!");
                    delelementnumber = delelement;
                    //dictions.Remove(obj2);
                    Console.WriteLine("Вопрос с ответом удален!");
                    break;
                }
                delelement++;
            }
            dictions.RemoveAt(delelementnumber);
           
        }
        ////// Серриализация списка обьектов
        public void MethodFindEngRuss() 
        {
            Console.WriteLine("Введите искомое слово");
            var str  = Console.ReadLine();  
            foreach (Victorina_questions_ansver obj2 in dictions)
            {
               if (obj2.Ansver.Contains(str) || (obj2.Questions.Contains(str)))
                {
                    Console.WriteLine("Есть такой вопрос\\ответ !");
                    Console.WriteLine(obj2.ToString());
                }   
            }
        }
        // Создание нового файла и добавление в него списка обьектов после удаления
        public void NewXML() 
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Victorina_questions_ansver>));
            // сохранение массива в файл
            using (FileStream fsi = new FileStream("ClassVictorin.xml", FileMode.Create))
            {
                formatter.Serialize(fsi, dictions);
            }
        }
        public void Ser()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List <Victorina_questions_ansver>));
            // сохранение массива в файл
            using (FileStream fsi = new FileStream("ClassVictorin.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fsi, dictions);
            }
        }
        ////// Десерриализация списка обьектов с выводом на консоль

        public void Deser()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Victorina_questions_ansver>));
            // восстановление массива из файла
            using (FileStream fs = new FileStream("ClassVictorin.xml", FileMode.OpenOrCreate))
            {
                 dictions = formatter.Deserialize(fs) as List<Victorina_questions_ansver>;

                if (dictions != null)
                {
                    foreach (Victorina_questions_ansver words in dictions)
                    {
                        foreach (char str in words.ToString())
                        {
                            //Console.WriteLine($"English: {Convert.ToString(words.Ansver)} --- Russian: {words.Questions.ToString()}");
                        }
                       
                    }
                }
               
            }
            
        }
       
    }
}


    

     
