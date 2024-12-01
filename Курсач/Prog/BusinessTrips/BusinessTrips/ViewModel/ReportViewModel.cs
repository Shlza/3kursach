using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Reflection.Metadata;
using System.Windows.Documents;

public class ReportViewModel : ViewModelBase
{
    private readonly AppDbContext dbContext;

    public ICommand GeneratePdfReportCommand { get; set; }
    public ICommand GenerateExcelReportCommand { get; set; }

    public ReportViewModel()
    {
        dbContext = new AppDbContext();
        GeneratePdfReportCommand = new RelayCommand(GeneratePdfReport);
        GenerateExcelReportCommand = new RelayCommand(GenerateExcelReport);
    }

    private void GeneratePdfReport()
    {
        var trips = dbContext.BusinessTrips.ToList();

        Document pdfDoc = new Document();
        PdfWriter.GetInstance(pdfDoc, new FileStream("BusinessTripsReport.pdf", FileMode.Create));
        pdfDoc.Open();

        pdfDoc.Add(new Paragraph("Отчет о командировках"));
        foreach (var trip in trips)
        {
            pdfDoc.Add(new Paragraph($"Командировка: {trip.Destination}, Начало: {trip.StartDate}, Конец: {trip.EndDate}, Цель: {trip.Purpose}"));
        }

        pdfDoc.Close();
    }

    private void GenerateExcelReport()
    {
        var trips = dbContext.BusinessTrips.ToList();

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Командировки");
            worksheet.Cell(1, 1).Value = "Место назначения";
            worksheet.Cell(1, 2).Value = "Дата начала";
            worksheet.Cell(1, 3).Value = "Дата окончания";
            worksheet.Cell(1, 4).Value = "Цель";

            int row = 2;
            foreach (var trip in trips)
            {
                worksheet.Cell(row, 1).Value = trip.Destination;
                worksheet.Cell(row, 2).Value = trip.StartDate;
                worksheet.Cell(row, 3).Value = trip.EndDate;
                worksheet.Cell(row, 4).Value = trip.Purpose;
                row++;
            }

            workbook.SaveAs("BusinessTripsReport.xlsx");
        }
    }
}
