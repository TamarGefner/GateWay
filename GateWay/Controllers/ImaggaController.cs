using Microsoft.AspNetCore.Mvc;
using System.Net;
using GateWay.Models;

namespace GateWay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImaggaController : ControllerBase
    {
        [HttpGet("CheckImage")]
        public async Task<IActionResult> CheckImage([FromQuery] string imageUrl, [FromQuery] string description)
        {
            try
            {
                ImaggaModel imaggaModel = new ImaggaModel();

                bool tagExists = await imaggaModel.CheckImage(imageUrl, description);

                // Return appropriate messages based on the result
                if (tagExists)
                {
                    return Ok("Okay, the image contains coffee");
                }
                else
                {
                    return Ok("Problem, this is not an image of coffee");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the request
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}