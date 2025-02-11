using AutoMapper;
using DTO.TimeEntryDTOs;
using Entity;
using Repository;

namespace Services;

public class TimeEntryService : ITimeEntryService
{
    private readonly IRepository<TimeEntry> _repository;
    private readonly IMapper _mapper;

    public TimeEntryService(IRepository<TimeEntry> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void AddEntry(int userId, DateTime dateTime)
    {
        var timeEntry = _repository.GetFirstOrDefault(te => te.UserId == userId && te.Entry.Date == dateTime.Date && te.Exit == null);
        if (null == timeEntry)
        {
            TimeEntry addTimeEntry = new TimeEntry() { UserId = userId, Entry = dateTime, Exit = null };
            _repository.Add(addTimeEntry);
            return;
        }

        timeEntry.Exit = dateTime;
        _repository.Update(timeEntry);
    }

    public IEnumerable<TimeEntryDisplayDTO> GetTimeEntries(DateTime dateTime)
    {
        var timeEntries = _repository.GetAll(te => te.Entry.Date == dateTime.Date, te=>te.User);
        return _mapper.Map<IEnumerable<TimeEntryDisplayDTO>>(timeEntries);
    }
}
