using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using Infrastructure.Services.FileService;


public class CarServices: ICarService
{
    private readonly IFileService _fileService;
     private readonly AplicationDbContext _dbContext;
    public CarServices(AplicationDbContext dbContext, IFileService fileService)
    {
        _dbContext = dbContext;
        _fileService = fileService;
    }

    public async Task<string> AddCar(AddCarDto model)
    {
        var Car = new Car()
        {
            VIN = model.VIN,
            Auction = model.Auction,
            Airbag = model.Airbag,
            VINStatus = model.VINStatus,
            Year = model.Year,
            AuctionDate = model.AuctionDate,
            BodyType = model.BodyType,
            Equipment = model.Equipment,
            Final_Bid = model.Final_Bid,
            Key = model.Key,
            Loss = model.Loss,
            Lot = model.Lot,
            Make = model.Make,
            ManufacturedIn = model.ManufacturedIn,
            Model = model.Model,
            Odometer = model.Odometer,
            PrimaryDamage = model.PrimaryDamage,
            SecondaryDamage = model.SecondaryDamage,
            Seller = model.Seller,
            SellingBranch = model.SellingBranch,
            StartCode = model.StartCode,
            Transmission = model.Transmission,
        };
        await _dbContext.Cars.AddAsync(Car);
        var result = await _dbContext.SaveChangesAsync();

          foreach (var file in model.CarImages)
            {
                var imageName = await _fileService.CreateFile(file.FileName);
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

    public async Task<List<Car>> GetAllCars()
    {
        var allcour = await _dbContext.Cars.ToListAsync();
     
        return allcour;
    }

    public async Task<string> UpdateCar(Car model)
    {
        var Car = await _dbContext.Cars.FindAsync(model.Id);
        
        if(Car==null) return "Data not found !";

       
            Car.VIN = model.VIN;
            Car.Auction = model.Auction;
            Car.Airbag = model.Airbag;
            Car.VINStatus = model.VINStatus;
            Car.Year = model.Year;
            Car.AuctionDate = model.AuctionDate;
            Car.BodyType = model.BodyType;
            Car.Equipment = model.Equipment;
            Car.Final_Bid = model.Final_Bid;
            Car.Key = model.Key;
            Car.Loss = model.Loss;
            Car.Lot = model.Lot;
            Car.Make = model.Make;
            Car.ManufacturedIn = model.ManufacturedIn;
            Car.Model = model.Model;
            Car.Odometer = model.Odometer;
            Car.PrimaryDamage = model.PrimaryDamage;
            Car.SecondaryDamage = model.SecondaryDamage;
            Car.Seller = model.Seller;
            Car.SellingBranch = model.SellingBranch;
            Car.StartCode = model.StartCode;
            Car.Transmission = model.Transmission;
        

        var result = await _dbContext.SaveChangesAsync();

        if(result==0) return "Data not updated !";
        return "Data successfully updated";
    }
}
