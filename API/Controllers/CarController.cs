using DB.DTO;
using DB.Services;
using DB.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private ICarService _carService { get; set; }
        private IUserHistoryService _userHistoryService;
        private ICategoryServices _categoryService;
        public CarController(ICarService carService, IUserHistoryService userHistoryService, ICategoryServices categoryService)
        {
            this._carService = carService;
            this._userHistoryService = userHistoryService;
            this._categoryService = categoryService;
        }

        [HttpGet("getCarsById")]
        public IActionResult GetCarById()
        {

            var idOwner = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Actor)?.Value;

            //7cf57e37-89be-4708-91ce-ff84f2831ce3
            var result = _carService.GetCarsByUserId(idOwner);

            return Ok(result);
        }
        [HttpGet("getAllCars")]
        public IActionResult GetCars()
        {
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
        [HttpGet("getCarById/{id}")]
        public IActionResult GetCarById(int id)
        {

            try
            {
                var result = _carService.GetCarById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("getDisabledById/{id}")]
        public IActionResult GetDisabledCarById(int id)
        {
            try
            {
                var result = _carService.GetDisabledCarById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getCarHistory/{id}")]
        public IActionResult GetHistoryCarById(int id)
        {

            try
            {
                var result = _carService.GetHistoryCar(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getActivCarForAdmin")]
        public IActionResult GetActivCarForAdmin()
        {
            try
            {
                var result = _carService.GetActivCarForAdmin();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getRetreatCarList")]
        public IActionResult GetRetreatCarList()
        {
            try
            {
                var resut = _carService.GetRetreatCarList();
                return Ok(resut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getDisabledCarList")]

        public IActionResult GetRetreatCar()
        {
            try
            {
                var result = _carService.GetDisabledCarList();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updateCar/{idCar}")]
        public IActionResult UpdateCar(int idCar, [FromBody] UpdateCarDTO newCar)
        {
            try
            {

                _carService.updateCar(idCar, newCar);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getRecommendedCar")]
        public IActionResult getRecommendedCar(int id)
        {

            try
            {
                int top = 3;
                var userId = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Actor)?.Value;
                var userHistory = this._userHistoryService.GetUserHistory(userId);
                var commonHistory = new List<DB.DTO.UserHistoryDTO>();
                var recommendedCarsIds = new List<int>();

                List<string> currentCategories = userHistory.Select(x => x.NameCategoryCar).ToList();


                if (userHistory != null)
                {
                    var currendCarIds = userHistory.Select(x => x.CarId);
                    var allHistory = this._userHistoryService.GetAll().AsEnumerable();
                    var othersWithSameCars = allHistory.Where(x => currendCarIds.Contains(x.CarId) && x.ClientId != userId).Select(x => x.ClientId);
                    if (othersWithSameCars != null)
                    {
                        commonHistory = allHistory.Where(x => othersWithSameCars.Contains(x.ClientId)).ToList();
                    }
                    else
                    {

                        var othersWithSameCategory = allHistory
                            .Select(x => new { x.ClientId, x.NameCategoryCar })
                            .Where(x => currentCategories.Contains(x.NameCategoryCar) && x.ClientId != userId).ToList();

                        foreach (var cat in othersWithSameCategory)
                        {

                            var hist = allHistory.Where(x => x.ClientId == cat.ClientId).ToList<DB.DTO.UserHistoryDTO>();
                            commonHistory.AddRange(hist);
                        }

                    }
                }

                if (!commonHistory.Any())
                {
                    commonHistory = this._userHistoryService.GetAll();
                }


                if (commonHistory.Any())
                {
                    recommendedCarsIds = commonHistory.GroupBy(x => x.CarId)
                        .OrderBy(x => x.Count())
                        .Take(top)
                        .Select(x => x.Key)
                        .ToList();
                }
                else
                {
                    recommendedCarsIds = this._carService.GetAllCars()
                        .OrderBy(x => x.PricePerDay)
                        .Take(top)
                        .Select(x => x.Id)
                        .ToList();
                }


                var cars = this._carService.GetAllCars().Where(x => recommendedCarsIds.Contains(x.Id)).ToList();
                return Ok(cars);
                //return Ok();
            }
            catch (Exception ex)
            {
                //var cars = this._carService.GetAllCars().Take(3);
                var cars = this._carService.GetAllCars().OrderBy(x => x.PricePerDay).Take(3).ToList();
                return Ok(cars);
            }





        }

        [HttpPost("filter")]
        public IActionResult FilterCar([FromBody] Filter filterList)
        {
            try
            {
                var cars = this._carService.GetCarFilter(filterList);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
