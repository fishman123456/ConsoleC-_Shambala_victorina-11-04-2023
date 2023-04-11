using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleC_Shambala_victorina_11_04_2023
{

  
    public class Manager_Menu
    {
        public static void UserMenu()
        {
            ClassVictorin classDiction = new ClassVictorin();
            #region
            bool flag = true;
            do
            {
                Console.WriteLine("\tНажмите на клавишу для выбора действия");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.NumPad0:
                        Console.WriteLine("\n Exit");
                        System.Threading.Thread.Sleep(1000);// пауза в 1 секунду
                        flag = false;
                        break;
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("\nПоиск вопроса");
                        //classDiction.Deser();
                        classDiction.MethodFindEngRuss();

                        break;
                    case ConsoleKey.NumPad2:
                          Console.WriteLine("\nДобавление вопросов в викторину\n");
                        // Victorina_ansver_questions.ReturnMenu("add");
                        Victorina_questions_ansver keyValue = new Victorina_questions_ansver();
                        keyValue.MethodAdd();
                        classDiction.AddObject(keyValue);
                        classDiction.Ser();
                        break;
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("\nСчитывание из файла");
                        //Console.WriteLine("Введите имя файла");
                        //string filename = Console.ReadLine();
                        classDiction.Deser();
                        break;
                    case ConsoleKey.NumPad4:
                        Console.WriteLine("\nУдаление вопроса из викторины");
                        classDiction.MethodDeleteEngRuss();
                        classDiction.NewXML();
                        break;
                    case ConsoleKey.NumPad5:
                        Console.WriteLine("\nСохранить в файл");
                        classDiction.Ser();
                        break;
                    //case ConsoleKey.NumPad6:
                    //    Console.WriteLine("\nNumPad6");
                    //    break;
                    //case ConsoleKey.NumPad7:
                    //    Console.WriteLine("\nNumPad7");
                    //    break;
                    //case ConsoleKey.NumPad8:
                    //    Console.WriteLine("\nNumPad8");
                    //    break;
                    ////case ConsoleKey.NumPad9:
                    ////    System.Threading.Thread.Sleep(500);// пауза в 1 секунду
                       
                    ////    Console.WriteLine("Файл очищен");
                    ////    break;
                    default:
                        Console.WriteLine("\tНажмите клавишу из меню\n");
                        System.Threading.Thread.Sleep(500);// пауза в 1 секунду
                        Console.Clear();
                        UserHint();
                        break;
                }
            } while (flag == true); 
            #endregion
           
        }
        public static void UserHint() 
        {
            Console.WriteLine("\n Программа Викторина\n ");
            Console.WriteLine("\tNumPad0. Для выхода из программы"); // работает
            Console.WriteLine("\tNumPad1. Поиск вопроса ");
            Console.WriteLine("\tNumPad2. Добавление вопросов в викторину "); // работает
            Console.WriteLine("\tNumPad3. Считывание из файла"); // работает
            Console.WriteLine("\tNumPad4. Удаление вопроса из викторины");
            Console.WriteLine("\tNumPad5. Сохранить в файл");// работает
            //Console.WriteLine("6. Добавление слова в словарь (нажмите для ввода слова)\n");
            //Console.WriteLine("7. Добавление слова в словарь (нажмите для ввода слова)\n");
            //Console.WriteLine("8. Добавление слова в словарь (нажмите для ввода слова)\n");
           // Console.WriteLine("\t9. Стереть файл\n");
        }
    }
}
