namespace Domain.Entities;

public class CarImage
{
    public int Id { get; set; }
    public string ImageName { get; set; }
    public int CarId { get; set; }

    public Car Car { get; set; }
}
