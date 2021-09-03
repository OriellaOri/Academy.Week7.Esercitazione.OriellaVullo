using Academy.Week7.Esercitazione.Core1.Entities;
using System;
using System.Collections.Generic;

namespace Academy.Week7.Esercitazione.Core1.Interfaces
{
    public interface IMainBL
    {
        /* CRUD CLIENT */
        List<Client> FetchClients(Func<Client, bool> filter = null);
        Client GetClientByID(int id);
        bool AddClient(Client newClient);
        bool UpdateClient(Client upClient);
        bool DeleteClientById(int id);

        /* CRUD ORDER */
        List<Order> FetchOrders(Func<Order, bool> filter = null);
        Order GetOrderByID(int id);
        bool AddOrder(Order newOrder);
        bool UpdateOrder(Order upOrder);
        bool DeleteOrderById(int id);
    }
}