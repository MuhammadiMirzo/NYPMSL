namespace WebApi.Controllers;
﻿using Domain;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _CarService;

        public CarController(ICarService CarService)
        {
            _CarService = CarService;
        }
        [HttpGet("GetAllCars")]
        public async Task<IActionResult> GetAllCarsAsync()
        {
            var response = await _CarService.GetAllCars();
            return StatusCode(200, response);
        }
        //[HttpGet("GetCar")]
        // public async Task<IActionResult> GetCarAsync(int CarId)
        // {
        //     var response = await _CarService.GetCarAsync(CarId);

        //     return StatusCode(response.StatusCode, response);
        // }
        [HttpPost("AddCar")]
        public async Task<string> AddCarAsync([FromForm]AddCarDto model)
        {
            var response = await _CarService.AddCar(model);

            return "Car Successifully ADded";
        }
        [HttpPut("UpdateCar")]
        public async Task<string> UpdateCarAsync(Car model)
        {
            var response = await _CarService.UpdateCar(model);

            return  "Updated";
        }
        [HttpDelete("DeleteCar")]
        public async Task<string> DeleteCarAsync( int CarId)
        {
            var response = await _CarService.DeleteCar(CarId);

            return "Deleted";
        }
    }

