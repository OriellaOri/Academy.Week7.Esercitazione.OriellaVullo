using Academy.Week7.Esercitazione.Core1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Academy.Week7.Esercitazione.WCF
{
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        IEnumerable<Client> FetchClients();

        [OperationContract]
        bool CreateClient(Client newC);

        [OperationContract]
        bool EditClient(Client editedC);

        [OperationContract]
        bool DeleteClientById(int idC);
    }


}
