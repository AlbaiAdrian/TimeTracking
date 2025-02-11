namespace DTO.TimeEntryDTOs;

public class TimeEntryDisplayDTO
{
    public string FullName { get; set;}

    public DateTime Entry { get; set; }

    public DateTime Exit { get; set; }

    public double WorkedTime { get; set; }
}
