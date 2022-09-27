using DB.DTO;
using DB.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("[controller]")]
    public class UserHistoryController : ControllerBase
    {
        private IUserHistoryService _userHistoryService;
        public UserHistoryController(IUserHistoryService userHistoryService)
        {
            this._userHistoryService = userHistoryService;
        }

        [HttpPost("updateStatus/{id}")]
        public IActionResult updateStatusScheduling([FromRoute] int id, [FromBody] int status)
        {
            try
            {
                _userHistoryService.updateStatus(id, status);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addHistory")]
        public IActionResult addHistoryClient([FromBody] UserHistoryDTO historyDTO)
        {
            try
            {
                _userHistoryService.addHistory(historyDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getUserHistory/{id}")]
        public IActionResult getUserHistory(string id)
        {
            try
            {
                var result = _userHistoryService.GetUserHistory(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
