using Alg.Core.Dto;
using Alg.Services.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Alg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private DataFactory _dataFactory;
        public MainController(DataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }

        [HttpGet("{id}", Name = "Get1")]
        public IActionResult getTextLength(int id, [FromQuery] QueryDto data)
        {
            try
            {
                var r = _dataFactory.GetInstance(id);
                return Ok(r.GetLength(data.Description ?? ""));
            }
            catch (ArgumentException)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}