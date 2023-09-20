using GateWay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GateWay.Controllers
{

    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpGet("check")]
         public async Task<string> CheckCityAndStreet([FromQuery] string cityName, [FromQuery] string streetName)
         {
             try
             {
                 var _addressModel = new AddressModel();
                 bool exists = await _addressModel.CheckCityAndStreetExists(cityName, streetName);

                 if (exists)
                 {
                     return "City and street exist in the data.";
                 }
                 else
                 {
                     return "City and street not found in the data.";
                 }
             }
             catch (Exception ex)
             {
                 return "ERROR";
             }
         }
     }
}