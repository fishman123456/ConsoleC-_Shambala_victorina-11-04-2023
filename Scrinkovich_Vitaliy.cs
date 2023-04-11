using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleC__Shambala_victorina_11_04_2023
{
    internal class Scrinkovich_Vitaliy
    {
[Serializable]
    public class User
    {
        public int Id = 0;
        public string Login = "  ";
        public string Password = "  ";

        public string BirthDate = "  ";

        public List<string> LastVictorinList { get; set; }

        public User() { }
        public override string ToString()
        {
            return Login + " " + Password + " " + BirthDate.ToString();
        }
    }



    [Serializable]
    public class Answer
    {
        public string answerText { get; set; }

        public bool isItRight = false;
        public Answer() { }
        public Answer(string answerText, bool isItRight)
        {
            this.answerText = answerText;
            this.isItRight = isItRight;
        }
        public override string ToString()
        {
            if (isItRight == true) { return "v"; }
            else { return "x"; }
        }

    }

    [Serializable]
    public class Question
    {
        public string questionType = "General";

        public string QuestionText = "";
        public List<Answer> TrueAnswers { get; set; }
        public List<Answer> userAnswers { get; set; }

        public Question() { }
        public Question(string questionType, string QuestionText)
        {
            this.questionType = questionType;
            this.QuestionText = QuestionText;
            this.TrueAnswers = new List<Answer>();
            this.userAnswers = new List<Answer>();
        }
        public void AddAnswer(Answer answer)
        {
            this.TrueAnswers.Add(answer);
        }
        public bool RemoveAnswer() { return true; }

        public List<Answer> giveAllAnswers() { return TrueAnswers; }
        public void setUserAnswers(List<Answer> NewAnswers) { this.userAnswers = NewAnswers; }


        public bool didUserGuess() { return UserGuess(this.userAnswers); }
        public bool UserGuess(List<Answer> answers)
        {
            bool toReturn = true;

            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].isItRight == this.TrueAnswers[i].isItRight) { }
                else { toReturn = false; break; }
            }

            return toReturn;
        }

        public void FullDescription()
        {
            for (int i = 0; i < this.TrueAnswers.Count; i++)
            {
                try
                {
                    Console.Write(" " + TrueAnswers[i].answerText + " answered " + userAnswers[i].ToString() + " true: " + TrueAnswers[i].ToString());
                }
                catch
                {
                    Console.WriteLine(" user did not answer ");
                }
            }
        }
    }



    [Serializable]
    public class Victorina
    {
        public string Name = "unnamed";
        public List<string> gamersTopNames;
        public List<Question> questions;
        private int MaxQuestions;
        private int victorinaCounter;



        public Victorina() { }
        public Victorina(string Name)
        {
            this.Name = Name;
            this.gamersTopNames = new List<string>();
            this.questions = new List<Question>();
        }

        public void AddQuestion(Question question) { questions.Add(question); }

        public Question Givequestion(int questionID) { return questions[questionID]; }

        public void RemoveQuestion(int questionID) { questions.RemoveAt(questionID); }

        public void UserAnswerderThisQuestion() { }
        public void WinMethod() { Console.WriteLine(" U win! "); }

        public Question courateVictorina()
        {
            this.MaxQuestions = questions.Count;
            this.victorinaCounter = 0;

            if (victorinaCounter == this.MaxQuestions)
            {
                this.WinMethod();
                return Givequestion(0);
            }
            else
            {
                Question questionToShow = Givequestion(victorinaCounter);

                victorinaCounter++;
                return questionToShow;
            }
        }
    }


    [Serializable]
    abstract class Spisok
    {
        public void SerializeIT(string filename, object toSerialize)
        {
            XmlSerializer xmlFormat = new XmlSerializer(toSerialize.GetType());
            using (Stream fStream = File.Create(filename))
            {
                xmlFormat.Serialize(fStream, toSerialize);
            }
            WriteLine("Serialized!\n");
        }
        public T DeserializeIT<T>(string filename)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            using (Stream fStream = File.OpenRead(filename))
            {
                T obj = (T)xmlFormat.Deserialize(fStream);
                return obj;
            }
        }
    }

    [Serializable]
    class VictorinaSpisok : Spisok
    {
        public List<Victorina> Victorins = new List<Victorina>();
        public VictorinaSpisok() { }

        public void add(Victorina victorina) { Victorins.Add(victorina); }

        public void Save() { base.SerializeIT("Victorins.xml", Victorins); }
        public void initialize() { this.Victorins = base.DeserializeIT<List<Victorina>>("Victorins.xml"); }
    }


    [Serializable]
    class UsserSpisok : Spisok
    {
        public List<User> users = new List<User>();
        public UsserSpisok() { }

        public void Save() { base.SerializeIT("Users.xml", users); }
        public void initialize() { this.users = base.DeserializeIT<List<User>>("Users.xml"); }
    }


    class Manager
    {
        VictorinaSpisok victorins = new VictorinaSpisok();
        UsserSpisok users = new UsserSpisok();
        public Manager()
        {
            try { this.victorins.initialize(); } catch (Exception e) { }
            try { this.users.initialize(); } catch (Exception e) { }
        }

        public void CreateVictorina()
        {

            Console.WriteLine("Enter VictorinaType:");
            string questionVictorinaType = Console.ReadLine();

            Console.WriteLine("Enter VictorinaName:");
            string VictorinaName = Console.ReadLine();

            Victorina victorina = new Victorina(VictorinaName);

            bool Ended = false;
            while (Ended == false)
            {
                Console.WriteLine("Enter QuestionText:");
                string QuestionText = Console.ReadLine();
                Question question = new Question(questionVictorinaType, QuestionText);
                bool answersEnded = false;
                while (answersEnded == false)
                {
                    Console.WriteLine("Enter Qustion-Answer or 'N' to continueToNextQuestion or 'F' to finish  VictorinaCreation");
                    string answer = Console.ReadLine();
                    if (answer == "N") { answersEnded = true; break; }
                    if (answer == "F") { answersEnded = true; Ended = true; break; }
                    else
                    {
                        Console.WriteLine("isIt True? 1 = True, 0 = False");



                        int isItRight = Convert.ToInt32(Console.ReadLine());
                        bool isItRightbool = false;
                        if (isItRight == 0) { isItRightbool = false; }
                        else if (isItRight == 1) { isItRightbool = true; }

                        Console.WriteLine(isItRight.ToString());
                        Answer ans = new Answer(answer, isItRightbool);
                        question.AddAnswer(ans);
                    }
                }
                victorina.AddQuestion(question);
            }
            victorins.add(victorina);
            victorins.Save();
        }
    }

    class Program
    {



        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.CreateVictorina();

        }


    }

}
}
