using API.Models;
using API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustController : ControllerBase
    {
        private readonly ICustService _custService;

        public CustController(ICustService custService)
        {
            _custService = custService;

        }

        [EnableCors("Policy")]
        [HttpGet("GetAllCustPhone")]
        public object GetAllCustPhone()
        {
            var data = _custService.GetAllCustPhone();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [EnableCors("Policy")]
        [HttpGet("GetCustPhoneByCustId")]
        public object GetCustPhoneByCustId(string custId)
        {
            var data = _custService.GetCustPhoneByCustId(custId);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            //return data.Count() == 0 ? NotFound("Cust ID Not Found") : Ok(json);
            return Ok(json);
        }

        [EnableCors("Policy")]
        [HttpGet("GetCustPhoneByStatus")]
        public object GetCustPhoneByStatus(bool status)
        {
            var data = _custService.GetCustPhoneByStatus(status);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return data.Count() == 0 ? NotFound("Status Not Found") : Ok(json);
        }

        [EnableCors("Policy")]
        [HttpPost("AddPhone")]
        public async Task<object> AddPhone([FromBody] CustPhone custPhone)
        {
            try
            {
                if (_custService.CheckExists(custPhone))
                    return BadRequest("Same Customer and Phone exist in the system");

                var action = await _custService.AddPhone(custPhone);

                return Ok("Created Successfully");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [EnableCors("Policy")]
        [HttpDelete("DeletePhone")]
        public object DeletePhone(CustPhone custPhone)
        {
            try
            {
                var action = _custService.DeletePhone(custPhone);

                if (action)
                    return Ok();
                else
                    return NotFound("Cust ID or Phone No Not Found");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [EnableCors("Policy")]
        [HttpPut("UpdatePhoneStatus")]
        public object UpdatePhoneStatus(CustPhone custPhone)
        {
            try
            {
                var action = _custService.UpdatePhoneStatus(custPhone);
                if (action)
                    return Ok();
                else
                    return NotFound("Cust ID or Phone No Not Found");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [EnableCors("Policy")]
        [HttpPut("TogglePhoneStatus")]
        public object TogglePhoneStatus(CustPhone custPhone)
        {
            try
            {
                var action = _custService.TogglePhoneStatus(custPhone);
                if (action)
                    return Ok();
                else
                    return NotFound("Cust ID or Phone No Not Found");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
