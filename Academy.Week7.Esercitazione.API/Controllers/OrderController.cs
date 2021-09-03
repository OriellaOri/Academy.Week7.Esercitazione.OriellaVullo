using Academy.Week7.Esercitazione.Core1.Entities;
using Academy.Week7.Esercitazione.Core1.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Week7.Esercitazione.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMainBL mainBL;

        public OrderController(IMainBL mainbl)
        {
            mainBL = mainbl;    
        }

        /// <summary>
        /// Recupera tutti gli ordini presnti in DB
        /// </summary>
        /// <returns>Staut 200-OK (List di ordini)</returns>
        [HttpGet]
        public ActionResult Get()
        {
            var result = mainBL.FetchOrders();

            return Ok(result);
        }

        /// <summary>
        /// Crea un ordine. 
        /// I dati del ordine sono passati nel bodi
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns>201-Created</returns>
        [HttpPost]
        public ActionResult Post([FromBody] Order newOrder)
        {
            if (newOrder == null)
                return BadRequest("Invalid Order data");

            if (!mainBL.AddOrder(newOrder))
                return BadRequest("Cannot complete the operation");

            return Ok(newOrder) ;
        }

        /// <summary>
        /// Modifica un ordine già esiste. 
        /// Per fare in modo che la modifica vada a buon fine 
        /// insere tutti i campi anche quelli che non si voglio modificare
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editOrder"></param>
        /// <returns></returns>
        //TODO: se un dato non viene inserito NON viene modificato
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order editOrder)
        {
            if (editOrder == null)
                return BadRequest("Invalid Order data.");

            if (id != editOrder.Id)
                return BadRequest("Order IDs don't match.");

            if (!mainBL.UpdateOrder(editOrder))
                return BadRequest("Operation cannot be completed");

            return Ok();
        }

        /// <summary>
        /// Cancellazione di un ordine 
        /// dato un id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID.");

            var result = mainBL.DeleteOrderById(id);

            if (!result)
                return StatusCode(500, "Cannot complete the operation.");

            return Ok();
        }

    }
}
