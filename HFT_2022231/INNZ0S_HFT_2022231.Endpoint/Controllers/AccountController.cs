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
    public class AccountController : ControllerBase
    {
        readonly IAccountServices AccountServices;
        public AccountController(IAccountServices accountServices)
        {
            AccountServices = accountServices;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Account> Get()
        {
            return AccountServices.ReadAll();
        }

        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return AccountServices.Read(id);
        }

        [HttpPost]
        [ActionName("Create")]
        public APIResult Post([FromBody] Account transaction)
        {
            var result = new APIResult(true);

            try
            {
                AccountServices.Create(transaction);
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
        public APIResult Put([FromBody] Account transaction)
        {
            var result = new APIResult(true);

            try
            {
                AccountServices.Update(transaction);
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
                AccountServices.Delete(id);
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
        public IEnumerable<Account> TexanClients()
        {
            return AccountServices.AccountsMadeByTexanClient();
        }
    }
}
