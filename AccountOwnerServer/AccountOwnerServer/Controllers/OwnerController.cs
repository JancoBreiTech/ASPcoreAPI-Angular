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

namespace AccountOwnerServer.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        //Third add here
        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                var owners = await _repository.Owner.GetAllOwners();
                _logger.LogInfo($"Return all owners from database.");

                var ownerResult = _mapper.Map<IEnumerable<OwnerDTO>>(owners);

                return Ok(ownerResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the GetAllOwners() action : {ex.Message}");
                return StatusCode(500, "Internal Server Error");//change db ID to uniqueidentifier
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerById(id);

                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in the DB.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Owner with id: {id}");
                    var ownerResult = _mapper.Map<OwnerDTO>(owner);

                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById() action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetails(Guid id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerWithDetails(id);

                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id} hasn't been found in the DB.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Owner with details for id: {id} found");
                    var ownerDetails = _mapper.Map<OwnerDTO>(owner);
                    return Ok(ownerDetails);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something wnt wrong inside GetOwnerWithDetails() action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody]OwnerForCreationDTO owner)
        {
            try
            {
                if (owner == null)
                {
                    _logger.LogError("Owner object sent from client is NULL");
                    return BadRequest("Owner object is NULL");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Owner object sent from client");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _mapper.Map<Owner>(owner);

                _repository.Owner.CreateOwner(ownerEntity);
                await _repository.Save();

                var createdOwner = _mapper.Map<OwnerDTO>(ownerEntity);

                return CreatedAtRoute("OwnerById", new { id = createdOwner.Id }, createdOwner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner() action: {ex.Message}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id,[FromBody]OwnerForUpdateDTO owner)
        {
            try
            {
                if (owner == null)
                {
                    _logger.LogError("Owner object from client is null");
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner from client.");
                    return BadRequest("Inavalid model object");
                }

                var ownerEntity =await _repository.Owner.GetOwnerById(id);
                if (ownerEntity == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in the DB.");
                    return NotFound();
                }

                _mapper.Map(owner, ownerEntity);

                _repository.Owner.UpdateOwner(ownerEntity);
                await _repository.Save();

                return NoContent();                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            try
            {
                var owner =await _repository.Owner.GetOwnerById(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                if (_repository.Account.AccountsByOwner(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }

                _repository.Owner.DeleteOwner(owner);
                await _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}