
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using Infrastructure.Services.FileService;
using Domain.DTOs;


public class CarServices: ICarService
{
    private readonly IFileService _fileService;
     private readonly AplicationDbContext _dbContext;
    public CarServices(AplicationDbContext dbContext, IFileService fileService)
    {
        _dbContext = dbContext;
        _fileService = fileService;
    }

    public async Task<string> AddCar(AddCarDto addCar)
    {
        var Car = new Car()
        {
            VIN = addCar.VIN,
            Auction = addCar.Auction,
            Airbag = addCar.Airbag,
            VINStatus = addCar.VINStatus,
            Year = addCar.Year,
            AuctionDate = DateTimeOffset.UtcNow,
            BodyType = addCar.BodyType,
            Equipment = addCar.Equipment,
            Final_Bid = addCar.Final_Bid,
            Key = addCar.Key,
            Loss = addCar.Loss,
            Lot = addCar.Lot,
            Make = addCar.Make,
            ManufacturedIn = addCar.ManufacturedIn,
            Model = addCar.Model,
            Odometer = addCar.Odometer,
            PrimaryDamage = addCar.PrimaryDamage,
            SecondaryDamage = addCar.SecondaryDamage,
            Seller = addCar.Seller,
            SellingBranch = addCar.SellingBranch,
            StartCode = addCar.StartCode,
            Transmission = addCar.Transmission,
        };
        await _dbContext.Cars.AddAsync(Car);
        var result = await _dbContext.SaveChangesAsync();

          foreach (var file in addCar.CarImages)
            {
                var imageName = await _fileService.CreateFile(file);
                var image = new CarImage()
                {
                    CarId = Car.Id,
                    ImageName = imageName
                };
                await _dbContext.CarImages.AddAsync(image);
                await _dbContext.SaveChangesAsync();
            }


        if(result==0) return "Data not added !";
        return "Data successfully added !";
    }

    public async Task<string> DeleteCar(int CarId)
    {
        var Car = await _dbContext.Cars.FindAsync(CarId);
        if(Car==null)return "Not found";
        _dbContext.Cars.Remove(Car);
       var result = await _dbContext.SaveChangesAsync();

        if(result==0) return "Data not deleted !";
        return "Data successfully deleted";
    }

    public async Task<List<GetCarDto>> GetAllCars()
    {
        var allcour = await _dbContext.Cars.Select(
           x => new GetCarDto(){
             Airbag = x.Airbag,
             Auction = x.Auction,
             BodyType = x.BodyType,
             CarImages = x.CarImages.Select(
                x=>x.ImageName).ToList(),
            Equipment = x.Equipment,
            Final_Bid = x.Final_Bid,
            Id = x.Id,
            Key = x.Key,
            Loss = x.Loss,
            Lot = x.Lot,
            Make = x.Make,
            ManufacturedIn = x.ManufacturedIn,
            Model = x.Model,
            Odometer = x.Odometer,
            PrimaryDamage = x.PrimaryDamage,
            SecondaryDamage = x.SecondaryDamage,
            Seller = x.Seller,
            SellingBranch = x.SellingBranch,
            StartCode = x.StartCode,
            Transmission = x.Transmission,
            VIN = x.VIN,
            VINStatus = x.VINStatus,
            Year = x.Year
           }).ToListAsync();
     
        return allcour;
    }

    public async Task<string> UpdateCar(Car addCar)
    {
        var Car = await _dbContext.Cars.FindAsync(addCar.Id);
        
        if(Car==null) return "Data not found !";

       
            Car.VIN = addCar.VIN;
            Car.Auction = addCar.Auction;
            Car.Airbag = addCar.Airbag;
            Car.VINStatus = addCar.VINStatus;
            Car.Year = addCar.Year;
            Car.AuctionDate = addCar.AuctionDate;
            Car.BodyType = addCar.BodyType;
            Car.Equipment = addCar.Equipment;
            Car.Final_Bid = addCar.Final_Bid;
            Car.Key = addCar.Key;
            Car.Loss = addCar.Loss;
            Car.Lot = addCar.Lot;
            Car.Make = addCar.Make;
            Car.ManufacturedIn = addCar.ManufacturedIn;
            Car.Model = addCar.Model;
            Car.Odometer = addCar.Odometer;
            Car.PrimaryDamage = addCar.PrimaryDamage;
            Car.SecondaryDamage = addCar.SecondaryDamage;
            Car.Seller = addCar.Seller;
            Car.SellingBranch = addCar.SellingBranch;
            Car.StartCode = addCar.StartCode;
            Car.Transmission = addCar.Transmission;
        

        var result = await _dbContext.SaveChangesAsync();

        if(result==0) return "Data not updated !";
        return "Data successfully updated";
    }
}
