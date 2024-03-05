using _253504_Shukaila_Lab2.Entities;
using _253504_Shukaila_Lab2.Collections;

namespace _253504_Shukaila_Lab2.Contracts
{
    internal interface IAirport
    {
        public void AddTariff(Tariff tariff);
        public void RegisterTicketPurchase(Ticket ticket);
        public decimal CalculatePassengerTicketsCost(string passengerPassporData);
        public decimal CalculateAllTicketsCost();
        public MyList<Tariff> GetTariffs();
    }
}