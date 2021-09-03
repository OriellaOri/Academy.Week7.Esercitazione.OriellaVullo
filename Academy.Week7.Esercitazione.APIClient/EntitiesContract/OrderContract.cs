using System;

namespace Academy.Week7.Esercitazione.APIClient.EntitiesContract
{
    public  class OrderContract
    {
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public string OrderCode { get; set; }
        public string ProductCode { get; set; }
        public decimal Amount { get; set; }
        public int IdClient { get; set; }
    }
}