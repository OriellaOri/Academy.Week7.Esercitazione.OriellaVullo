﻿using Academy.Week7.Esercitazione.Core1;
using Academy.Week7.Esercitazione.Core1.BL;
using Academy.Week7.Esercitazione.Core1.Entities;
using Academy.Week7.Esercitazione.Core1.Interfaces;
using Academy.Week7.Esercitazione.EF1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Academy.Week7.Esercitazione.WCF
{
    public class ClientService : IClientService
    {
        // Business Layer 
        IMainBL mainBL;

        // costruttore con risoluzione dipendenze 
        public ClientService()
        {
            // Configurazione DI
            DependencyContainer.Register<IMainBL, MainBL>();
            DependencyContainer.Register<IClientRepository, EfClientRepository>();
            DependencyContainer.Register<IOrderRepository, EfOrderRepository>();

            // Risoluzione
            mainBL = DependencyContainer.Resolve<IMainBL>();
        }

        public bool CreateClient(Client newC)
        {
            if (newC == null)
                return false;

            return this.mainBL.AddClient(newC);
        }

        public bool DeleteClientById(int idC)
        {
            if (idC > 0)
                return this.mainBL.DeleteClientById(idC);

            return false;
        }

        public bool EditClient(Client editedC)
        {
            if (editedC == null)
                return false;

            return this.mainBL.UpdateClient(editedC);
        }

        public IEnumerable<Client> FetchClients()
        {
            return mainBL.FetchClients();
        }
    }
}