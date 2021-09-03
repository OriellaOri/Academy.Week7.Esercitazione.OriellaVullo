using System;
using System.Collections.Generic;

namespace Academy.Week7.Esercitazione.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
