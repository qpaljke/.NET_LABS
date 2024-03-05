using _253504_Shukaila_Lab1.Entities;

namespace _253504_Shukaila_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Airport airport = new();
            airport.AddTariff(new Tariff { Direction = "Moscow", Cost = 1000 });
            airport.AddTariff(new Tariff { Direction = "New York", Cost = 3000 });
            airport.AddTariff(new Tariff { Direction = "Paris", Cost = 2000 });

            // выводим список тарифов на экран
            Console.WriteLine("Tariffs:");
            foreach (Tariff tariff in airport.GetTariffs())
            {
                Console.WriteLine($"Direction: {tariff.Direction}, Cost: {tariff.Cost}");
            }

            // регистрируем покупку билетов
            Passenger passenger1 = new Passenger("Valère");
            airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[0], passenger1));
            airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[1], passenger1));
            airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[2], passenger1));
            passenger1 = null;

            Passenger passenger2 = new Passenger("Maxim");
            airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[0], passenger2));
            airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()[1], passenger2));

            // расчет стоимости купленных билетов первым пассажиром
            Console.WriteLine($"Passenger1 ticket cost: {airport.CalculatePassengerTicketsCost(passenger1)}");

            // расчет стоимости купленных билетов вторым пассажиром 
            Console.WriteLine($"Passenger1 ticket cost: {airport.CalculatePassengerTicketsCost(passenger2)}");

            // расчет стоимости всех проданных билетов
            Console.WriteLine($"All tickets cost: {airport.CalculateAllTicketsCost()}");

            Console.ReadKey();
        }
    }
}