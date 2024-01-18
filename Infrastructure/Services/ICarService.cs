using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Services;

public interface ICarService
{
    Task<List<GetCarDto>> GetAllCars();
    Task<string> AddCar(AddCarDto model);
    Task<string> UpdateCar(Car model);
    Task<string> DeleteCar(int courseId);
    Task<GetCarDto?> GetCarById(int carId);
    Task<GetCarDto?> GetCarByVIN(string carVin);

}
