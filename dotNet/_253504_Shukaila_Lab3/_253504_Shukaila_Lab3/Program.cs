using _253504_Shukaila_Lab3.Entities;

namespace _253504_Shukaila_Lab3;

class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляр аэропорта
        Airport airport = new Airport();

        // Добавляем несколько тарифов
        airport.AddTariff("Тариф 1", new Tariff { Direction = "Москва", Cost = 100, Date = DateTime.Now });
        airport.AddTariff("Тариф 2", new Tariff { Direction = "Токио", Cost = 150, Date = DateTime.Now });
        airport.AddTariff("Тариф 3", new Tariff { Direction = "Париж", Cost = 250, Date = DateTime.Now });

        // Создаем несколько пассажиров
        Passenger passenger1 = new Passenger("Максим");
        Passenger passenger2 = new Passenger("Павел");
        Passenger passenger3 = new Passenger("Александр");

        // Добавляем пассажиров в аэропорт
        airport.AddPassenger(passenger1);
        airport.AddPassenger(passenger2);
        airport.AddPassenger(passenger3);

        // Регистрируем покупку билетов
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()["Тариф 1"], passenger1));
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()["Тариф 2"], passenger2));
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()["Тариф 3"], passenger3));
        airport.RegisterTicketPurchase(new Ticket(airport.GetTariffs()["Тариф 1"], passenger1));

        // Примеры вызова методов и вывод результатов на консоль
        Console.WriteLine("Список названий всех тарифов, отсортированный по стоимости:");
        var sortedTariffs = airport.GetSortedTariffNamesByCost();
        foreach (var tariffName in sortedTariffs)
        {
            Console.WriteLine(tariffName);
        }

        Console.WriteLine("\nОбщая стоимость всех билетов в аэропорту: " + airport.GetTotalTicketsCost());

        Console.WriteLine("\nОбщая стоимость билетов для пассажира 'Пассажир 1': " + airport.GetTotalCostForPassenger("Максим"));

        Console.WriteLine("\nИмя пассажира, заплатившего максимальную сумму: " + airport.GetPassengerWithMaxCost());

        decimal costThreshold = 200;
        Console.WriteLine("\nКоличество пассажиров, заплативших более " + costThreshold + " рублей за билет: " + airport.GetPassengerCountWithCostGreaterThan(costThreshold));

        Console.WriteLine("\nСписок сумм, заплаченных пассажирами по каждому направлению:");
        var passengerCostByDirection = airport.GetPassengerCostByDirection();
        foreach (var kvp in passengerCostByDirection)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
