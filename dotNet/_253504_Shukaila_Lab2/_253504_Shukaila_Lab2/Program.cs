using _253504_Shukaila_Lab2.Entities;
using _253504_Shukaila_Lab2.Collections;
namespace _253504_Shukaila_Lab2;

internal class Program
{
    static void Main(string[] args)
    {
        Journal journal = new();
        Airport airport = new();

        airport.tariffsChanged += journal.AddEvent;
        airport.passengersChanged += journal.AddEvent;
        airport.ticketPurchased += journal.AddEvent;

        airport.AddTariff(new Tariff { Direction = "Moscow", Cost = 1000, Date = new DateTime(2023, 09, 14)});
        airport.AddTariff(new Tariff { Direction = "New York", Cost = 3000, Date = new DateTime(2022, 02, 21)});
        airport.AddTariff(new Tariff { Direction = "Paris", Cost = 2000, Date = new DateTime(2023, 03, 07) });

        // выводим список тарифов на экран
        Console.WriteLine("Tariffs:");
        foreach (Tariff tariff in airport.GetTariffs())
        {
            Console.WriteLine($"Direction: {tariff.Direction}, Cost: {tariff.Cost}");
        }

        // регистрируем покупку билетов
        Passenger passenger1 = new Passenger("Valère");
        airport.AddPassenger(passenger1);
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[0], passenger1));
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[1], passenger1));
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[2], passenger1));

        Passenger passenger2 = new Passenger("Maxim");
        airport.AddPassenger(passenger2);
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[0], passenger2));
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[1], passenger2));


        // расчет стоимости купленных билетов первым пассажиром
        Console.WriteLine($"Passenger 1 ticket cost: {airport.CalculatePassengerTicketsCost("Valère")}");

        // расчет стоимости купленных билетов вторым пассажиром 
        Console.WriteLine($"Passenger 2 ticket cost: {airport.CalculatePassengerTicketsCost("Maxim")}");

        // расчет стоимости всех проданных билетов
        Console.WriteLine($"All tickets cost: {airport.CalculateAllTicketsCost()}");

        journal.PrintEvents();

        Console.ReadKey();
    }

}
