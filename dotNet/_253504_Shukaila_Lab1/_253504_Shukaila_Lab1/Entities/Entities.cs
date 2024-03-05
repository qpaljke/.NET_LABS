namespace _253504_Shukaila_Lab1.Entities;
using _253504_Shukaila_Lab1.Contracts;
using _253504_Shukaila_Lab1.Collections;

public class Tariff
{
    public string Direction { get; set; } // направление
    public decimal Cost { get; set; } // стоимость
}

// класс пассажира
public class Passenger
{
    public string PassportData { get; set; } // паспортные данные

    public Passenger(string passportData)
    {
        PassportData = passportData;
    }
}

// класс билета
public class Ticket
{
    public Tariff Tariff { get; set; } // тариф
    public Passenger Passenger { get; set; } // пассажир

    public decimal Cost // стоимость билета
    {
        get { return Tariff.Cost; }
    }

    public Ticket(Tariff tariff, Passenger passenger)
    {
        Tariff = tariff;
        Passenger = passenger;
    }
}

// класс кассы аэропорта
public class Airport : IAirports
{
    private MyList<Tariff> tariffs = new(); // список тарифов
    private MyList<Ticket> tickets = new(); // список проданных билетов
    private MyList<Passenger> passengers = new(); // список пассажиров

    // метод для добавления тарифа
    public void AddTariff(Tariff tariff)
    {
        tariffs.Add(tariff);
    }

    // метод для регистрации покупки билета
    public void RegisterTicketPurchase(Ticket ticket)
    {
        tickets.Add(ticket);
    }

    // метод для расчета стоимости билетов, купленных пассажиром
    public decimal CalculatePassengerTicketsCost(Passenger passenger)
    {
        decimal cost = 0;
        foreach (Ticket ticket in tickets)
        {
            if (ticket.Passenger == passenger)
            {
                cost += ticket.Cost;
            }
        }
        return cost;
    }

    // метод для расчета стоимости всех проданных билетов
    public decimal CalculateAllTicketsCost()
    {
        decimal cost = 0;
        foreach (Ticket ticket in tickets)
        {
            cost += ticket.Cost;
        }
        return cost;
    }

    // метод для получения списка тарифов
    public MyList<Tariff> GetTariffs()
    {
        return tariffs;
    }
}
