using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie2.Application;
using Zadanie2.Core;
using Zadanie2.Infrastructure;

namespace Zadanie2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageQueries _packageQueries;
        private readonly ILogger<PackageController> _logger;
        private readonly IPackageCommands _packageCommands;
        private readonly IRecipientQueries _recipientQueries;

        public PackageController(IPackageQueries packageQueries, ILogger<PackageController> logger,
            IPackageCommands packageCommands, IRecipientQueries recipientQueries)
        {
            _packageQueries = packageQueries;
            _logger = logger;
            _packageCommands = packageCommands;
            _recipientQueries = recipientQueries;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetListPackageDTO>>> GetPackages([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                return Ok(await _packageQueries.GetPackages(queryParameters));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            };
        }

        [HttpGet("Id")]
        public async Task<ActionResult<DetailsPackageDTO>> GetPackages(int id)
        {

            try
            {
                var result = await _packageQueries.GetPackage(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            };
        }

        [HttpGet("barcode/Id")]
        public async Task<ActionResult<string>> GetBarCode(int id)
        {

            try
            {
                var result = await _packageQueries.GetBarcodePackageById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            };
        }

        [HttpPost]
 
        public async Task<IActionResult> AddPackage(AddPackageDTO addPackageDTO)
        {
            if(!await  _recipientQueries.Exists(addPackageDTO.RecipientId))
            {
                return BadRequest("No recipient found");
            }

            try
            {
                await _packageCommands.AddPackageCommand(addPackageDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditPackage(EditPackageDTO editPackageDTO,int id)
        {
            if (editPackageDTO.Id != id)
            {
                return BadRequest();
            }
            if (!await _recipientQueries.Exists(editPackageDTO.RecipientId))
            {
                return BadRequest("No recipient found");
            }
            if (!await _packageQueries.Exists(editPackageDTO.Id))
            {
                return BadRequest("No package found");
            }
            try
            {
                await _packageCommands.EditPackageCommand(editPackageDTO);
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
