using Domain.Interfaces;

namespace Domain.Models;

public class PngExportStrategy: IExportStrategy
{
    public void ExportReport()
    {
        Console.WriteLine("Exporting to PNG");
    }
}