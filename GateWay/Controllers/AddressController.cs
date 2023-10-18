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
         public async Task<bool> CheckCityAndStreet([FromQuery] string cityName, [FromQuery] string streetName)
         {
             try
             {
                 var _addressModel = new AddressModel();
                 bool exists = await _addressModel.CheckCityAndStreetExists(cityName, streetName);

                 if (exists)
                 {
                    return true;
                 }
                 else
                 {
                    return false;
                 }
             }
             catch (Exception ex)
             {
                 return false;
             }
         }
     }
}