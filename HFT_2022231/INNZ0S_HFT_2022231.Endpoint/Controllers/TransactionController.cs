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
    public class TransactionController : ControllerBase
    {
        readonly ITransactionServices TransactionServices;
        public TransactionController(ITransactionServices transactionServices)
        {
            TransactionServices = transactionServices;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Transaction> Get()
        {
            return TransactionServices.ReadAll();
        }

        [HttpGet("{id}")]
        public Transaction Get(int id)
        {
            return TransactionServices.Read(id);
        }

        [HttpPost]
        [ActionName("Create")]
        public APIResult Post([FromBody] Transaction transaction)
        {
            var result = new APIResult(true);

            try
            {
                TransactionServices.Create(transaction);
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
        public APIResult Put([FromBody] Transaction transaction)
        {
            var result = new APIResult(true);

            try
            {
                TransactionServices.Update(transaction);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage=ex.Message;
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
                TransactionServices.Delete(id);
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
        public IEnumerable<Transaction> TransactionsWithoutCreditCard()
        {
            return TransactionServices.TransactionsWithoutCreditCard();
        }

    }
}
