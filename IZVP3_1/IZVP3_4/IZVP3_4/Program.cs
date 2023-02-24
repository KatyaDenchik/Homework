Console.Write("Введiть кiлькiсть паличок: ");
int sticks = Int32.Parse(Console.ReadLine());
bool player;
int playerNum;
Console.WriteLine("Введiть номер гравця, хто ходить перший");
Console.WriteLine("1. Комп'ютер");
Console.WriteLine("2. Гравець");
Console.Write("Введiть номер: ");
while (true)
{
    playerNum = Int32.Parse(Console.ReadLine());
    if (playerNum == 1)
    {
        player = false;
        break;
    }
    else if (playerNum == 2)
    {
        player = true;
        break;
    }
    else
    {
        Console.Write("Невiрно введен номер гравця, введiть 1 або 2: ");
    }
}

Game newGame = new Game(sticks, player);
newGame.Notify += newGame.ViewSticks;
newGame.Play();

public class Game
{
    public delegate void SticksViewer();
    public event SticksViewer Notify;

    public int StickCount;
    public bool Player;
    int step;
    Random random = new Random();
    public Game(int stickCount, bool player)
    {
        StickCount = stickCount;
        Player = player;
        ViewSticks();
    }

    public void Play()
    {
        while (StickCount > 1)
        {
            if (Player)
            {
                PlayerStep();
            }
            else
            {
                ComputerStep();
            }
            Player = !Player;
            Notify();
        }
        if (Player)
        {
            Console.WriteLine("Перемiг комп'ютер!");
        }
        else
        {
            Console.WriteLine("Перемiг гравець!");
        }
    }

    public void PlayerStep()
    {
        do
        {
            Console.Write("Введiть число мiж 1 та 3: ");
            step = Int32.Parse(Console.ReadLine());
        } while (step < 1 || step > 3);
        StickCount -= step;
    }

    public void ViewSticks()
    {
        Console.WriteLine($"Кiлькiсть паличок, що залишилась: {StickCount}");
    }

    public void ComputerStep()
    {
        step = random.Next(3) + 1;
        Console.WriteLine($"Комп'ютер обирає вiд 1 до 3: {step}");
        ChangeStick(step);
    }

    public void ChangeStick(int numStick)
    {
        StickCount -= numStick;
    }
}
