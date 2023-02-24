Question question1 = new Question
{
    Question_ = "Машини мають свiдомiсть.",
    Answer = false,
    Difficulty = "легко"
};
Question question2 = new Question
{
    Question_ = "Iснують паралельнi всесвiти.",
    Answer = false,
    Difficulty = "складно"
};
Question question3 = new Question
{
    Question_ = "Ми були б щасливiшими, якби знали сенс життя.",
    Answer = true,
    Difficulty = "легко"
};
Question question4 = new Question
{
    Question_ = "Iснує таке поняття, як правда.",
    Answer = true,
    Difficulty = "легко"
};
Question question5 = new Question
{
    Question_ = "Можлива подорож у часi.",
    Answer = false,
    Difficulty = "складно"
};
Question question6 = new Question
{
    Question_ = "Є таке поняття, як зараження раком.",
    Answer = false,
    Difficulty = "складно"
};
Question question7 = new Question
{
    Question_ = "Iснує межа в тому, наскiльки розумними можуть бути люди та спiльноти.",
    Answer = true,
    Difficulty = "легко"
};
Question question8 = new Question
{
    Question_ = "Старiння неминуче.",
    Answer = true,
    Difficulty = "легко"
};
Question question9 = new Question
{
    Question_ = "Вегетарiанцi можуть їсти печиво у формi тварин",
    Answer = true,
    Difficulty = "легко"
};
Question question10 = new Question
{
    Question_ = "Адам та Єва мали пупок",
    Answer = false,
    Difficulty = "легко"
};

List<Question> listOfQuestions = new List<Question>();
listOfQuestions.Add(question1);
listOfQuestions.Add(question2);
listOfQuestions.Add(question3);
listOfQuestions.Add(question4);
listOfQuestions.Add(question5);
listOfQuestions.Add(question6);
listOfQuestions.Add(question7);
listOfQuestions.Add(question8);
listOfQuestions.Add(question9);
listOfQuestions.Add(question10);

string answer;
bool result;
int countMistakes = 0;

var CheckAnswer = (bool answer, string stringAnswer) =>
{
    stringAnswer = stringAnswer.ToLower();
    if (stringAnswer == "так" || stringAnswer == "вірю")
    {
        if (true == answer) return true;
        else return false;
    }
    else if (stringAnswer == "нi" || stringAnswer == "не вірю")
    {
        if (false == answer) return true;
        else return false;
    }
    return false;
};

Console.Write("Оберiть складнiсть (легко/складно/обидва): ");
string difficult = Console.ReadLine();
if (difficult.StartsWith("ле"))
{
    var newList = listOfQuestions.Where(x => x.Difficulty.Contains("лег"));
    listOfQuestions = newList.ToList();
}
else if (difficult.StartsWith("ск"))
{
    var newList = listOfQuestions.Where(x => x.Difficulty.Contains("ск"));
    listOfQuestions = newList.ToList();
}

for (int i = 0; i < listOfQuestions.Count; i++)
{
    Console.WriteLine("\n" + listOfQuestions[i].Question_);
    Console.Write("Ваша вiдповiдь: так(вірю)/нi(не вірю): ");
    answer = Console.ReadLine();
    result = CheckAnswer(listOfQuestions[i].Answer, answer);
    if (result)
    {
        Console.WriteLine("Правильна вiдповiдь!");
    }
    else
    {
        Console.WriteLine($"Не правильна вiдповiдь! Кiлькiсть допущених помилок: {++countMistakes}");
        Console.Write("Правильна відповідь: ");
        if (listOfQuestions[i].Answer == true)
        {
            Console.WriteLine("так");
        }
        else
        {
            Console.WriteLine("нi");
        }
        if (countMistakes == 3)
        {
            Console.WriteLine("\nВи програли!");
            break;
        }
    }
}
if (countMistakes != 3)
{
    Console.WriteLine("\nВи перемогли!");
}
class Question
{
    public string Difficulty;
    public string Question_;
    public bool Answer;
}
