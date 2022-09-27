using DB.DTO;
using DB.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("[controller]")]

    public class RequestController : ControllerBase
    {

        private IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            this._requestService = requestService;
        }

        [HttpGet("getAllRequest")]
        public IActionResult GetAllRequest()
        {

            var result = _requestService.GetAllRequests();
            return Ok(result);
        }

        [HttpPost("addRequest")]
        public IActionResult AddRequest([FromForm] RequestDTO requestDTO)
        {
            try
            {
                var idOwner = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Actor)?.Value;
                _requestService.AddRequest(requestDTO, idOwner);
                return Ok(new {Message = "adaugat" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("updateRequest/{id}")]
        public IActionResult UpdateRequest([FromForm] RequestDTO requestDTO, int id)
        {
            try
            {
                _requestService.updateRequest(requestDTO, id);
                return Ok("update request");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getRequestById/{id}")]
        public IActionResult GetRequestById([FromRoute] int id)
        {
            try
            {
                var result = _requestService.GetRequestsByUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("response/{id}")]
        public IActionResult ResponseRequest([FromRoute]int id, [FromBody] bool response) {
            try
            {
                _requestService.ResponseRequest(id, response);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message); 
            }
            return Ok();
        }

       

    }
}
