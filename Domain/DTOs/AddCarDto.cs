using Microsoft.AspNetCore.Http;

public class AddCarDto
{
    public string? Auction { get; set; }
    public int Year { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public string? Equipment { get; set; }
    public string? VIN { get; set; }
    public int Final_Bid { get; set; }
    public int Lot { get; set; }
    public string? Seller { get; set; }
    public string? Loss { get; set; }
    public string? PrimaryDamage { get; set; }
    public string?  SecondaryDamage { get; set; }
    public int Odometer { get; set; }
    public string? StartCode { get; set; }
    public string? Key { get; set; }
    public string? Airbag { get; set; }
    public string? VINStatus { get; set; }
    public string? BodyType { get; set; }
    public string? Transmission { get; set; }
    public string? ManufacturedIn { get; set; }
    public string? SellingBranch { get; set; }
    public DateTimeOffset AuctionDate { get; set; } 

    public List<AddCarImageDto>? CarImages { get; set; }
}


public class AddCarImageDto
{
    public IFormFile FileName { get; set; }
}