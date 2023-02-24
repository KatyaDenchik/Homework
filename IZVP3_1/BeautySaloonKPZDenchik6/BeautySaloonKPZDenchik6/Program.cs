
using BeautySaloonKPZDenchik6.Controllers;
using BeautySaloonKPZDenchik6.Loggers;

try
{
    Start();
}
catch (Exception e)
{
    Logger.Fatal(e.Message);
}

static void Start()
{
    //throw new Exception("Фатальна помилка!");
    Console.WriteLine("Всього було продано послуг:\n");
    BeautySaloonController.ShowStatistics();

    Console.WriteLine("\nНайкраще продалась наступна послуга:");
    BeautySaloonController.ShowTopService();

    Console.WriteLine("\nБажаєте отримати цю iнформацiю у виглядi csv файлу?");
    if (Console.ReadLine().Equals("так", StringComparison.InvariantCultureIgnoreCase))
    {
        BeautySaloonController.PrintStatistics();
        Console.WriteLine($"\nIнформацiя записана до файлу, який знаходиться за шляхом:\n{BeautySaloonController.PathToCsv}\n");
    }

    Console.WriteLine("\nБажаєте дiзнатись кiлькiсть продаж конкретної послуги?");
    if (Console.ReadLine().Equals("так", StringComparison.InvariantCultureIgnoreCase))
    {
        Console.WriteLine("\nВведiть її назву");
        var name = Console.ReadLine();
        Console.WriteLine($"\nНазва: {name}; Кiлькiсть: {BeautySaloonController.GetCountSales(name)}");
    }
}