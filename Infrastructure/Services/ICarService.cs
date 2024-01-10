using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Services;

public interface ICarService
{
    Task<List<Car>> GetAllCars();
    Task<string> AddCar(AddCarDto model);
    Task<string> UpdateCar(Car model);
    Task<string> DeleteCar(int courseId);

}
