using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Domain.DTOs;
public class AddCarDto
{
    [Required] public string Auction { get; set; } = null!;
    public int Year { get; set; }
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Equipment { get; set; } = null!;
    public string VIN { get; set; } = null!;
    public int Final_Bid { get; set; }
    public int Lot { get; set; }
    public string Seller { get; set; } = null!;
    public string Loss { get; set; } = null!;
    public string PrimaryDamage { get; set; } = null!;
    public string  SecondaryDamage { get; set; } = null!;
    public int Odometer { get; set; }
    public string StartCode { get; set; } = null!;
    public string Key { get; set; } = null!;
    public string Airbag { get; set; } = null!;
    public string VINStatus { get; set; } = null!;
    public string BodyType { get; set; } = null!;
    public string Transmission { get; set; } = null!;
    public string ManufacturedIn { get; set; } = null!;
    public string SellingBranch { get; set; } = null!;
     public DateTimeOffset AuctionDate { get; set; } 

    public List<IFormFile> CarImages { get; set; } = null!;
}
