namespace ExcelGenerator;

public interface IExcelGenerator
{
    public void Generate(string excelName, string sheetName, List<List<string>> data);
}
