using _253504_Shukaila_Lab2.Collections;
using _253504_Shukaila_Lab2.Contracts;
using static _253504_Shukaila_Lab2.Entities.Journal;

namespace _253504_Shukaila_Lab2.Entities;

public class Tariff
{
    public string Direction { get; set; } // направление
    public decimal Cost { get; set; } // стоимость
    public DateTime? Date { get; set; } // дата
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
public class Airport : IAirport
{
    private MyList<Tariff> tariffs = new(); // список тарифов
    private MyList<Ticket> tickets = new(); // список проданных билетов
    private MyList<Passenger> passengers = new(); // список пассажиров 

    public delegate void AirportEventHandler(string message);

    public event AirportEventHandler tariffsChanged;
    public event AirportEventHandler passengersChanged;
    public event AirportEventHandler ticketPurchased;

    // метод для добавления тарифа
    public void AddTariff(Tariff tariff)
    {
        tariffs.Add(tariff);
        tariffsChanged?.Invoke($"Добавлен новый тариф: {tariff.Direction} {tariff.Cost} {tariff.Date}");

    }

    // метод для регистрации покупки билета
    public void RegisterTicketPurchase(Ticket ticket)
    {
        tickets.Add(ticket);
        ticketPurchased?.Invoke($"Куплен новый билет: {ticket.Passenger.PassportData}");
    }

    // метод для добавления пассажира
    public void AddPassenger(Passenger passenger)
    {
        passengers.Add(passenger);
        passengersChanged?.Invoke($"Добавлен новый пассажир: {passenger.PassportData}");
    }

    // метод для расчета стоимости билетов, купленных пассажиром
    public decimal CalculatePassengerTicketsCost(string passengerPassportData)
    {
        decimal cost = 0;

        foreach (Ticket ticket in tickets)
        {
            if (ticket.Passenger.PassportData == passengerPassportData)
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

    // метод для возврата всех пассажиров на определенную дату
    public MyList<Passenger> GetPassengersOnCertainDate(DateTime date)
    {
        var passengersOnDate = new MyList<Passenger>();

        foreach (Ticket ticket in tickets)
        {
            if (ticket.Tariff.Date.HasValue && ticket.Tariff.Date.Value.Date == date.Date)
            {
                if (!passengersOnDate.Contains(ticket.Passenger))
                {
                    passengersOnDate.Add(ticket.Passenger);
                }
            }
        }
        return passengersOnDate;
    }
}