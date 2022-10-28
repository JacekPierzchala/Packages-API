using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadanie2.Application;
using Zadanie2.Core;
using Zadanie2.Infrastructure;

namespace Zadanie2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {

        private readonly IRecipientCommands _recipientCommands;
        private readonly IRecipientQueries _recipientQueries;
        private readonly ILogger<RecipientController> _logger;

        public RecipientController( IRecipientCommands recipientCommands, IRecipientQueries recipientQueries,
            ILogger<RecipientController> logger)
        {
            _recipientCommands = recipientCommands;
            _recipientQueries = recipientQueries;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipient(AddRecipientDTO recipient)
        {
          
            try
            {
                await _recipientCommands.AddRecipientCommand(recipient);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipient(EditRecipientDTO recipient, int id)
        {
            if(recipient.Id!=id)
            {
                return BadRequest();
            }
            if(!await _recipientQueries.Exists(id))
            {
                return NotFound();
            }
            try
            {
                await _recipientCommands.EditRecipientCommand(recipient);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
