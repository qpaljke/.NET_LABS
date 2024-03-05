using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253504_Shukaila_Lab1.Collections;
using _253504_Shukaila_Lab1.Entities;
namespace _253504_Shukaila_Lab1.Contracts;

internal interface IAirports
{
    public void AddTariff(Tariff tariff);
    public void RegisterTicketPurchase(Ticket ticket);
    public decimal CalculatePassengerTicketsCost(Passenger passenger);
    public decimal CalculateAllTicketsCost();
    public MyList<Tariff> GetTariffs();

}
