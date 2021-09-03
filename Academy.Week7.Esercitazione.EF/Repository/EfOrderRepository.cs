using Academy.Week7.Esercitazione.Core.Entities;
using Academy.Week7.Esercitazione.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Week7.Esercitazione.EF.Repository
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly EsercitazioneContext ctx;

        public EfOrderRepository()
            : this(new EsercitazioneContext()) { }

        public EfOrderRepository(EsercitazioneContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Order newItem)
        {
            if (newItem == null)
                return false;

            try
            {
                ctx.Orders.Add(newItem);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                return false;

            try
            {
                var order = ctx.Orders.Find(id);

                if (order != null)
                    ctx.Orders.Remove(order);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> Fetch(Func<Order, bool> filter = null)
        {
            try
            {
                if (filter != null)
                    return ctx.Orders.Where(filter).ToList();

                return ctx.Orders.ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        public Order GetByID(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Orders.Find(id);
        }

        public bool Update(Order updatedItem)
        {
            if (updatedItem == null)
                return false;

            try
            {
                ctx.Orders.Update(updatedItem);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
