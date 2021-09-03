using Academy.Week7.Esercitazione.Core.Entities;
using Academy.Week7.Esercitazione.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Week7.Esercitazione.EF.Repository
{
    public class EfClientRepository : IClientRepository
    {
        private readonly EsercitazioneContext ctx;

        public EfClientRepository()
            : this(new EsercitazioneContext()) { }

        public EfClientRepository(EsercitazioneContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Client newItem)
        {
            if (newItem == null)
                return false;

            try
            {
                ctx.Clients.Add(newItem);
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
                var client = ctx.Clients.Find(id);

                if (client != null)
                    ctx.Clients.Remove(client);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Client> Fetch(Func<Client, bool> filter = null)
        {
            try
            {
                if (filter != null)
                    return ctx.Clients.Where(filter).ToList();

                return ctx.Clients.ToList();
            }
            catch (Exception)
            {
                return new List<Client>();
            }
        }

        public Client GetByID(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Clients.Find(id);
        }

        public bool Update(Client updatedItem)
        {
            if (updatedItem == null)
                return false;

            try
            {
                ctx.Clients.Update(updatedItem);
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
