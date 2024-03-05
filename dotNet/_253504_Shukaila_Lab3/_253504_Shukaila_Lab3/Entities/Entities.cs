using _253504_Shukaila_Lab3.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _253504_Shukaila_Lab3.Entities;

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
    public Tariff Tariff { get; } // тариф
    public Passenger Passenger { get; } // пассажир

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
    private Dictionary<string, Tariff> tariffs = new(); // список тарифов
    private List<Ticket> tickets = new(); // список проданных билетов
    private List<Passenger> passengers = new(); // список пассажиров 

    public delegate void AirportEventHandler(string message);

    public event AirportEventHandler tariffsChanged;
    public event AirportEventHandler passengersChanged;
    public event AirportEventHandler ticketPurchased;

    // метод для добавления тарифа
    public void AddTariff(string name, Tariff tariff)
    {
        tariffs.Add(name, tariff);
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
    public Dictionary<string, Tariff> GetTariffs()
    {
        return tariffs;
    }

    // метод для возврата всех пассажиров на определенную дату
    public List<Passenger> GetPassengersOnCertainDate(DateTime date)
    {
        var passengersOnDate = new List<Passenger>();

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

    // Метод для получения тарифов, отсортированных по стоимости
    public List<string> GetSortedTariffNamesByCost()
    {
        var sortedTariffs = tariffs
            .Values
            .OrderBy(t => t.Cost);

        return sortedTariffs
            .Select(t => t.Direction)
            .ToList();
    }

    // Метод для получения общей стоимости всех купленных в аэропорту билетов
    public decimal GetTotalTicketsCost()
    {
        return tickets
            .Sum(ticket => ticket.Cost);
    }

    // Метод для получения общей стоимости всех купленных пассажиром билетов в соответствии с действующими тарифами
    public decimal GetTotalCostForPassenger(string passengerPassportData)
    {
        return tickets
            .Where(ticket => ticket.Passenger.PassportData == passengerPassportData)
            .Sum(ticket => ticket.Cost);
    }

    // Метод для получения имени пассажира, заплатившего максимальную сумму
    public string GetPassengerWithMaxCost()
    {
        var passengerWithMaxCost = tickets.GroupBy(ticket => ticket.Passenger.PassportData)
                                          .Select(group => new
                                          {
                                              PassportData = group.Key,
                                              TotalCost = group.Sum(ticket => ticket.Cost)
                                          })
                                          .OrderByDescending(group => group.TotalCost)
                                          .FirstOrDefault();

        return passengerWithMaxCost?.PassportData;
    }

    // Метод для получения количества пассажиров, заплативших больше определенной суммы
    public int GetPassengerCountWithCostGreaterThan(decimal costThreshold)
    {
        return tickets
            .GroupBy(ticket => ticket.Passenger.PassportData)
            .Count(group => group.Sum(ticket => ticket.Cost) > costThreshold);
    }

    // Метод для получения пассажирами списка сумм, заплаченных по каждому направлению
    public Dictionary<string, decimal> GetPassengerCostByDirection()
    {
        var passengerCostByDirection = tickets
            .GroupBy(ticket => ticket.Tariff.Direction)
            .ToDictionary(group => group.Key, group => group
            .Sum(ticket => ticket.Cost));
        return passengerCostByDirection;
    }
}
