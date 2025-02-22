using ExcelGenerator;

namespace Services;

public class ReportGenerator : IReportGenerator
{
    private readonly IExcelGenerator _excelGenerator;
    private readonly ITimeEntryService _timeEntryService;

    public ReportGenerator(IExcelGenerator excelGenerator, ITimeEntryService timeEntryService)
    {
        _excelGenerator = excelGenerator;
        _timeEntryService = timeEntryService;
    }

    public void GenerateReport(DateTime date)
    {
        string fileName = $"TimeTracking_{date.Year}_{date.Month}_{date.Day}.xlsx";
        string sheetName = $"TimeTracking_{date.Year}_{date.Month}_{date.Day}";
        List<List<string>> lines = new()
        {
            new() { "Full Name", "Entry", "Exit", "WorkedTime" }
        };
        _timeEntryService.GetTimeEntries(date).ToList().ForEach(entry=> {
            lines.Add(new List<string> {entry.FullName, entry.Entry.ToShortDateString(), entry.Exit is null ? "" : ((DateTime)entry.Exit).ToShortDateString(), entry.WorkedTime.ToString()  });
        });
        _excelGenerator.Generate(fileName, sheetName, lines);
    }
}
