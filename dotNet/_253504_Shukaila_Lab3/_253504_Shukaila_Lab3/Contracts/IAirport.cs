using _253504_Shukaila_Lab3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Shukaila_Lab3.Contracts;

internal interface IAirport
{
    public void AddTariff(string name, Tariff tariff);
    public void RegisterTicketPurchase(Ticket ticket);
    public decimal CalculatePassengerTicketsCost(string passengerPassporData);
    public decimal CalculateAllTicketsCost();
    public Dictionary<string, Tariff> GetTariffs();
}
