using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class TimeEntry : Entity
{
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    public DateTime Entry { get; set; }

    public DateTime? Exit { get; set; }

}
