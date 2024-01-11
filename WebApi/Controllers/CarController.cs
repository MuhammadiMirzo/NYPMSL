using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _CarService;

    public CarController(ICarService CarService)
    {
        _CarService = CarService;
    }
    [HttpGet("GetCarById")]
    public async Task<GetCarDto> GetCarById(int carId)
    {
        var response = await _CarService.GetCarById(carId);
        return response;
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
    [HttpPost]
    public async Task<string> AddCarAsync([FromForm] AddCarDto car)
    {
        if (ModelState.IsValid)
        {
            var response = await _CarService.AddCar(car);

            return "Car Successifully ADded";
        }

        return "";
    }

    [HttpPut("UpdateCar")]
    public async Task<string> UpdateCarAsync(Car car)
    {
        var response = await _CarService.UpdateCar(car);

        return "Updated";
    }

    [HttpDelete("DeleteCar")]
    public async Task<string> DeleteCarAsync(int CarId)
    {
        var response = await _CarService.DeleteCar(CarId);

        return "Deleted";
    }
}