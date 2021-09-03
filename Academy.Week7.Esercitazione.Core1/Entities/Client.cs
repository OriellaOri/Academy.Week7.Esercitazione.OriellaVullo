using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Academy.Week7.Esercitazione.Core1.Entities
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ClientCode { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
