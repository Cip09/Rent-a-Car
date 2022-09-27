using DB.DTO;
using DB.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    public class RentSchedulingController : ControllerBase
    {
        private IRentScheduling _rentScheduling;
        public RentSchedulingController(IRentScheduling rentScheduling)
        {
            this._rentScheduling = rentScheduling;
        }

        [HttpPost("addRentScheduling")]
        public IActionResult addRentScheduling([FromBody] RentSchedulingCarDTO rentScheduling)
        {
            try
            {
                var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Actor)?.Value;
                _rentScheduling.addRentScheduling(rentScheduling, userId);
                return Ok(new { messege = "programare adaugata" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getRequestScheduling")]
        public IActionResult GetRequestScheduling()
        {
            try
            {
                var result = _rentScheduling.GetRentSchedulingCarDTOs();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("response/{id}")]
        public IActionResult ResponseRequestScheduling([FromRoute] int id, [FromBody] bool response)
        {
            try
            {
                _rentScheduling.ResponseRequestScheduling(id, response);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getSchedulingApproved")]
        public IActionResult GetSchedulingApproved()
        {
            try
            {
                var result = _rentScheduling.GetSchedulingCarApproved();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getSchedulingStart")]
        public IActionResult GetSchedulingStart()
        {
            try
            {
                var result = _rentScheduling.GetSchedulingStart();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("retreatRequest")]
        public IActionResult AddRetreatCarRequest([FromBody] RentSchedulingCarDTO requestDTO)
        {
            try
            {
                var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Actor)?.Value;
                _rentScheduling.AddRequestRetreatCar(requestDTO, userId);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getRetreatTemporaryRequest")]
        public IActionResult GetRetreatCarRequestTemporary()
        {
            try
            {
                var result = _rentScheduling.GetRequestRetreatCarTemporary();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getRetreatPermanentRequest")]
        public IActionResult GetRetreatPermanentRequest()
        {
            try
            {
                var result = _rentScheduling.GetRequestRetreatCarPermanent();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getSchedulingRetreatCar/{idCar}/{startDate}/{endDate}")]
        public IActionResult GetSchedulingRetreatCar(int idCar, DateTime startDate, DateTime endDate)
        {
            try
            {
                TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");

                var startDateTimeZone = TimeZoneInfo.ConvertTime(startDate, easternZone);
                var endDateTimeZone = TimeZoneInfo.ConvertTime(endDate, easternZone);

                var result = _rentScheduling.GetNextSchedulingRetreatCar(idCar, startDateTimeZone, endDateTimeZone);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getSchedulingRetreatPermanent/{idCar}/{startDate}")]
        public IActionResult GetSchedulingRetreatPermanent(int idCar, DateTime startDate)
        {
            try
            {
                TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");
                var startDateTimeZone = TimeZoneInfo.ConvertTime(startDate, easternZone);
                var result = _rentScheduling.GetNextSchedulingRetreatCarPermanent(idCar, startDateTimeZone);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("responseRetreatCar/{idRequest}/{typeRetreat}")]
        public IActionResult ResponseRetreatCarRequest(int idRequest, string typeRetreat, [FromBody] bool response)
        {
            try
            {
                _rentScheduling.ResponseRetreatCarRequest(idRequest, typeRetreat, response);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getRentHistoryCar/{idCar}")]
        public IActionResult GetHistoryCar(int idCar)
        {
            try
            {
                var result = _rentScheduling.GetHistoryCar(idCar);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpGet("getAllRentHistoryCar/{idCar}")]
        public IActionResult GetAllHistoryCar(int idCar)
        {
            try
            {
                var result = _rentScheduling.GetAllHistoryCar(idCar);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


    }
}
