using WebAppAPI.DTOs;

namespace WebAppAPI.Interfaces
{
    public interface IPrinter
    {
        Task<List<Printer>> GetPrinterList();

        Task<Printer> AddPrinter(Printer printer);

        Task<Printer> GetPrinterById(int printerId);
        Task<Printer> GetPrinterByName(string printerName);
        Task<Printer> UpdatePrinter(Printer printer);
        Task<bool> DeletePrinter(int printerId);
    }
}
