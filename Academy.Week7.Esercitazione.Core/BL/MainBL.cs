using Academy.Week7.Esercitazione.Core.Entities;
using Academy.Week7.Esercitazione.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Week7.Esercitazione.Core.BL
{
    public class MainBL : IMainBL
    {
        private IOrderRepository orderRepo;
        private IClientRepository clientRepo;

        public MainBL(IOrderRepository oRepo, IClientRepository cRepo)
        {
            orderRepo = oRepo;
            clientRepo = cRepo;
        }


        /* ADD */
        public bool AddClient(Client newClient)
        {
            if (newClient == null)
                return false;

            return clientRepo.Add(newClient);
        }

        public bool AddOrder(Order newOrder)
        {
            if (newOrder == null)
                return false;

            return orderRepo.Add(newOrder);
        }

        /* DELETE */
        public bool DeleteClientById(int id)
        {
            if (id <= 0)
                return false;

            return clientRepo.DeleteById(id);
        }

        public bool DeleteOrderById(int id)
        {
            if (id <= 0)
                return false;

            return orderRepo.DeleteById(id);
        }

        /* FETCH */
        public List<Client> FetchClients(Func<Client, bool> filter = null)
        {
            if (filter != null)
                return clientRepo.Fetch().Where(filter).ToList();

            return clientRepo.Fetch();
        }

        public List<Order> FetchOrders(Func<Order, bool> filter = null)
        {
            if (filter != null)
                return orderRepo.Fetch().Where(filter).ToList();

            return orderRepo.Fetch();
        }

        /* FETCH BY ID */
        public Client GetClientByID(int id)
        {
            if (id <= 0)
                return null;

            return clientRepo.GetByID(id);
        }

        public Order GetOrderByID(int id)
        {
            if (id <= 0)
                return null;

            return orderRepo.GetByID(id);
        }

        /* UPDATE */
        public bool UpdateClient(Client upClient)
        {
            if (upClient == null)
                return false;

            return clientRepo.Update(upClient);
        }

        public bool UpdateOrder(Order upOrder)
        {
            if (upOrder == null)
                return false;

            return orderRepo.Update(upOrder);
        }
    }
}
