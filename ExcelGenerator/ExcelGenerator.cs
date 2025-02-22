using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelGenerator;

public class ExcelGenerator : IExcelGenerator
{
    public void Generate(string excelName, string sheetName, List<List<string>> data)
    {
        using (var spreadsheet = SpreadsheetDocument.Create(excelName, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
        {
            var workbookPart = spreadsheet.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            var sheetPart = workbookPart.AddNewPart<WorksheetPart>();
            sheetPart.Worksheet = new Worksheet(new SheetData());

            var sheets = spreadsheet.WorkbookPart.Workbook.AppendChild(new Sheets());
            sheets.Append(new Sheet { Id = spreadsheet.WorkbookPart.GetIdOfPart(sheetPart), SheetId = 1, Name = sheetName });

            var sheetData = sheetPart.Worksheet.GetFirstChild<SheetData>();

            foreach (var rowData in data)
            {
                var row = new Row();
                foreach (var colData in rowData) 
                {
                    row.Append(new Cell { CellValue = new CellValue(colData), DataType = CellValues.String });
                }
                sheetData.Append(row);
            }
            workbookPart.Workbook.Save();
        }
    }
}
