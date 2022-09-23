using InstantLoan.BL.Repositories;
using InstantLoan.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InstantLoan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {


        private readonly IClientRepository _clientService;

        public ClientController(IClientRepository clientService)
        {
            _clientService = clientService;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _clientService.GetClients();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var clientFound = await _clientService.GetClientById(id);
                if (clientFound == null) return NotFound();

                return Ok(clientFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClientsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client dataClient)
        {
            try
            {
                var resultClient = await _clientService.PostClient(dataClient);
                return Ok(resultClient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Client dataClient)
        {
            try
            {
                if (id != dataClient.Id) return NotFound();
                await _clientService.UpdateClient(id, dataClient);
                return Ok(new { message = "Data updated successfuly." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _clientService.DeleteClientById(id);
                if (result == "NOT_FOUND") return NotFound();
                return Ok(new { message = "Data deleted successfuly." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
