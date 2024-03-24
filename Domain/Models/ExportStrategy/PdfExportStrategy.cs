using Domain.Interfaces;

namespace Domain.Models;

public class PdfExportStrategy: IExportStrategy
{
    public void ExportReport()
    {
        Console.WriteLine("Exporting to PDF");
    }
}