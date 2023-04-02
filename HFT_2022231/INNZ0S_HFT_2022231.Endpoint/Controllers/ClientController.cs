using INNZ0S_HFT_2022231.Logic.Interfaces;
using INNZ0S_HFT_2022231.Models.Entities;
using INNZ0S_HFT_2022231.Models.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace INNZ0S_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        readonly IClientServices ClientServices;
        public ClientController(IClientServices clientServices)
        {
            ClientServices = clientServices;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Client> Get()
        {
            return ClientServices.ReadAll();
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            return ClientServices.Read(id);

        }

        [HttpPost]
        [ActionName("Create")]
        public APIResult Post([FromBody] Client transaction)
        {
            var result = new APIResult(true);

            try
            {
                ClientServices.Create(transaction);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
                throw;
            }

            return result;
        }

        [HttpPut()]
        [ActionName("Update")]
        public APIResult Put([FromBody] Client transaction)
        {
            var result = new APIResult(true);

            try
            {
                ClientServices.Update(transaction);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
                throw;
            }

            return result;
        }

        [HttpDelete("{id}")]
        public APIResult Delete(int id)
        {
            var result = new APIResult(true);

            try
            {
                ClientServices.Delete(id);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;

                result.ErrorMessage = ex.Message;
                throw;
            }

            return result;
        }

        [HttpGet]
        public IEnumerable<Client> ThisMonthTransaction()
        {
            return ClientServices.ClientsWithTransactionsInThisMonth();
        }

        [HttpGet]
        public IEnumerable<Client> ClientsWithMoreAccounts()
        {
            return ClientServices.ClientsWithMoreAccounts();
        }

        [HttpGet]
        public IEnumerable<Client> ClientsWithTheMostMoney()
        {
            return ClientServices.ClientsSortedByMostMoney();
        }
    }
}
