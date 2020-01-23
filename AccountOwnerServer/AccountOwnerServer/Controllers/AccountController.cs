using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AccountOwnerServer.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;
        public AccountController(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [Route("api/owner/{ownerId}/account")]
        [HttpGet]
        public ActionResult GetAccountsForOwner(Guid ownerId, [FromQuery] AccountParameters parameters)
        {
            try
            {
                var accounts = _repository.Account.GetAccountsByOwner(ownerId, parameters);

                var metadata = new
                {
                    accounts.TotalCount,
                    accounts.PageSize,
                    accounts.CurrentPage,
                    accounts.TotalPages,
                    accounts.HasNext,
                    accounts.HasPrevious
                };

                var accountsResut = _mapper.Map<IEnumerable<AccountDTO>>(accounts);

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInfo($"Returned {accounts.TotalCount} accounts from database.");

                return Ok(accountsResut);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the GetAllAccounts() action : {ex.Message}");
                return StatusCode(500, "Internal Server Error");//change db ID to uniqueidentifier
            }
            
        }
    }
}