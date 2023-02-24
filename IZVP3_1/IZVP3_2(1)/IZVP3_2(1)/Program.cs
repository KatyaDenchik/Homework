Owner Katya = new Owner("0971449423", "Високий, вул.Бульварна");
Console.WriteLine("нерухомiсть Katya: ");
Katya.View();

CommercialImmovables flat1 = new CommercialImmovables(3500000, "Харкiв, Холодногiрська", "Не зайнята", "", "+3804535232", 40.5, "Квартира");
Katya.AddItem(flat1);
Console.WriteLine("нерухомiсть Katya пiсля додавання: ");
Katya.View();
Console.Write($"Вартicть нерухомостi за 1кв.м: {Math.Round(flat1.FindPrice(), 2)}");


public class Owner
{
    public string Phone { get; set; }
    public string Address { get; set; }
    public List<Immovables> ListOfProperties { get; set; } = new List<Immovables>();

    public Owner(string phone, string address)
    {
        Phone = phone;
        Address = address;
    }

    public void AddItem(Immovables item)
    {
        ListOfProperties.Add(item);
    }

    public void View()
    {
        Console.WriteLine("Phone: " + Phone);
        Console.WriteLine("Address: " + Address);
        Console.Write("Properties: ");
        if (ListOfProperties.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            for (int i = 0; i < ListOfProperties.Count; i++)
            {
                Console.WriteLine(ListOfProperties[i].Address + " " + ListOfProperties[i].Condition + " Price: " + ListOfProperties[i].Price);
            }
        }
    }
}

public class Immovables
{
    public int Price { get; set; }
    public string Address { get; set; }
    public string Condition { get; set; }
    public string Phone { get; set; }
    public string DateChange { get; set; }
    public double Square { get; set; }

    public Immovables(int price, string address, string condition, string phone, string dateChange, double square)
    {
        Price = price;
        Address = address;
        Condition = condition;
        Phone = phone;
        DateChange = dateChange;
        Square = square;
    }

    public double FindPrice()
    {
        return Price / Square;
    }
}

public class CommercialImmovables : Immovables
{
    public string Appointment { get; set; }

    public CommercialImmovables(int price, string address, string condition, string phone, string dateChange, double square, string appointment) :
        base(price, address, condition, phone, dateChange, square)
    {
        Appointment = appointment;
    }
}

public class Flat : Immovables
{
    public int MaxPeople { get; set; }

    public Flat(int price, string address, string condition, string phone, string dateChange, double square, int maxPeople) :
        base(price, address, condition, phone, dateChange, square)
    {
        MaxPeople = maxPeople;
    }
}

