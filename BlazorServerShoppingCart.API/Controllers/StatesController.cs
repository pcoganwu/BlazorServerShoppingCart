using BlazorServerShoppingCart.DataAccess;
using BlazorServerShoppingCart.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorServerShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;

        public StatesController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        // GET: api/<StatesController>
        [HttpGet]
        public async Task<ActionResult<State>> GetAllStates()
        {
            try
            {
                return Ok(await _stateRepository.GetAllStates());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // GET api/<StatesController>/5
        [HttpGet("{stateCode}")]
        public async Task<ActionResult<State>> GetState(string stateCode)
        {
            try
            {
                return await _stateRepository.GetState(stateCode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        // POST api/<StatesController>
        [HttpPost]
        public async Task<ActionResult<State>> CreateState([FromBody] State state)
        {
            try
            {
                var stateToCreate = await _stateRepository.AddState(state);
                return CreatedAtAction(nameof(GetState), new { stateCode = stateToCreate.StateCode }, stateToCreate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating a new State");
            }
            
        }

        // PUT api/<StatesController>/5
        [HttpPut]
        public async Task<ActionResult<State>> UpdateState([FromBody] State state)
        {
            try
            {
                if (state is null)
                {
                    return BadRequest("Invalid request");
                }

                var stateToUpdate = await _stateRepository.GetState(state.StateCode);
                if (stateToUpdate is not null)
                {
                    return await _stateRepository.UpdateState(state);
                }
                else
                {
                    return NotFound($"State with the code = {state.StateCode} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating State");
            }
        }

        // DELETE api/<StatesController>/5
        [HttpDelete("{stateCode}")]
        public async Task<ActionResult<State>> DeleteState(string stateCode)
        {
            try
            {
                var stateToDelete = await _stateRepository.GetState(stateCode);
                if (stateToDelete is not null)
                {
                    return await _stateRepository.DeleteState(stateCode);
                }
                else
                {
                    return NotFound($"State with the code = {stateCode} cannot be found");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting State");
            }
        }
    }
}
