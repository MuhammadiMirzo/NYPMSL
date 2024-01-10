namespace Domain.DTOs;

public class GetCarDto : AddCarDto
{
    public int Id { get; set; }
    public new List<string>? CarImages { get; set; } 
}
