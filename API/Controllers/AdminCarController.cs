
using DB.DTO;
using DB.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    public class AdminCarController : ControllerBase
    {
        private ICarService _carService;

        public AdminCarController(ICarService carService) { 
            this._carService = carService;
        }

        [HttpGet("get")]
        public IActionResult Index() {
            return Ok("esti in index");
        }

         [HttpPost("addCar")]
        public IActionResult AddCar([FromBody]CarDTO car)
        {
            try
            {
                _carService.addCar(car);
                return Ok("Car was added");
            }
            catch (Exception ex) { 
                var message = ex.Message;
            }

            return BadRequest("error added car");

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCar([FromRoute]int id)
        {
            try
            {
                _carService.deleteCar(id);
                return Ok("car deleted");
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return BadRequest(message);
            }
          
        }
        [HttpGet("getAll")]
        public IActionResult GetAllCar() {
            try
            {
                var result = _carService.GetAllCars();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
