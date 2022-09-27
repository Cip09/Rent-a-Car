using DB.DTO;
using DB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    public class SmartDeviceController : Controller
    {
        private ISmartDeviceServices smartDeviceServices;


        public SmartDeviceController(ISmartDeviceServices ismartDeviceServices)
        {
            this.smartDeviceServices = ismartDeviceServices;

        }

        [HttpPost("/addSmartDevice")]
        public IActionResult addSmartDevice([FromBody] SmartDeviceDTO smartDeviceDTO)
        {

            if (ModelState.IsValid)
            {
                smartDeviceServices.addSmartDevice(smartDeviceDTO);
                return Ok(new {messege="Smart was add" });
            }
            else
            {
                return BadRequest();

            }

        }

        [HttpPost("/addSmartDeviceToUser/{idUser}")]
        public IActionResult addSmartDeviceToUser([FromBody] SmartDeviceDTO smartDeviceDTO, [FromRoute] string idUser) {

            if (ModelState.IsValid)
            {
                smartDeviceServices.addSmartDeviceToUser(smartDeviceDTO, idUser);
                return Ok("Merge :)");
            }
            else {

                return BadRequest();
            }

            
        }

        [HttpDelete("/deleteSmartDevice/{idSmartDevice}")]
        public IActionResult deleteSmartDevice([FromRoute] int idSmartDevice, [FromRoute]string idClient) {
            if (idSmartDevice != 0) {
                smartDeviceServices.deleteSmartDevice(idSmartDevice, idClient);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("/updateSmartDevice/{idSmartDevice}")]
        public IActionResult updateSmartDevice([FromBody] SmartDeviceDTO smartDeviceDTO, [FromRoute] int idSmartDevice) {
            smartDeviceServices.updateSmartDevice(smartDeviceDTO, idSmartDevice);

            return Ok(new {response="Smart device was updated" });
        }

        [HttpGet("/getSmartDevice")]
        public IActionResult getSmartDevice() {
            var result = smartDeviceServices.getSmartDevices();
            return Ok(result);
        }

    }
}
