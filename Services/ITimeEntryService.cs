using DTO.TimeEntryDTOs;

namespace Services;

public interface ITimeEntryService
{
    void AddEntry(int userId, DateTime dateTime);

    IEnumerable<TimeEntryDisplayDTO> GetTimeEntries(DateTime dateTime);
}
