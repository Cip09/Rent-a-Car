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
    
    public class SmartSenzorController : Controller
    {
        private ISmartSenzorServices smartSenzorServices;

        public SmartSenzorController(ISmartSenzorServices ismartSenzorServices) {
            this.smartSenzorServices = ismartSenzorServices;
        
        }


        [HttpPost("/addSmartSenzor")]
        public IActionResult addSmartDevice([FromBody] SmartSenzorDTO smartSenzorDTO) {
            try
            {
                if (ModelState.IsValid)
                {
                    smartSenzorServices.addSmartSenzor(smartSenzorDTO);
                    return Ok(new { message = "Smart device was added" });
                }
                else
                {
                    return BadRequest("Fail to add new smart device");
                }
            }
            catch (Exception e) {
                return BadRequest(e?.Message?.ToString() +" " + e?.InnerException.Message?.ToString());
            }
        }

        [HttpDelete("/deleteSmartSenzor/{idSmartSenzor}")]
        public IActionResult deleteSmartSenzor([FromRoute] int idSmartSenzor, [FromRoute] int idSmartDevice) {
            if (idSmartSenzor != 0)
            {
                smartSenzorServices.deleteSmartSenzor(idSmartSenzor, idSmartDevice);
                return Ok(new { message = "Smart senzor was deleted"});
            }
            return BadRequest();

           
        }
        [HttpPut("/updateSmartSenzor/{idSmartSenzor}")]
        public IActionResult updateSmartSenzor([FromBody] SmartSenzorDTO smartSenzorDTO, [FromRoute] int idSmartSenzor) {
           var resultUpdate = smartSenzorServices.updateSmartSenzor(smartSenzorDTO, idSmartSenzor);
            return Ok(resultUpdate);
        }

        [HttpGet("/getSmartSenzor")]
        public IActionResult getSmartSenzor() {

            var result = smartSenzorServices.getSmartSenzors();

            return Ok(result);
        }
        

    }
}
