using System;
using System.Runtime.Serialization;

namespace Academy.Week7.Esercitazione.Core1.Entities
{
    public class Order
    {        
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public string OrderCode { get; set; }
        public string ProductCode { get; set; }
        public decimal Amount { get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; }
    }
}