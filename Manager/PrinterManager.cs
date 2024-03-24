using Microsoft.EntityFrameworkCore;
using WebAppAPI.DataContext;
using WebAppAPI.DTOs;
using WebAppAPI.Interfaces;

namespace WebAppAPI.Manager
{
    public class PrinterManager : IPrinter
    {
        
        private PrinterContext _printerContext;

        public PrinterManager(PrinterContext printerContext)
        {
            _printerContext = printerContext;
        }

        //private List<Printer> _printerList = new()
        //{
        //    new Printer()
        //    {
        //        Id = 1,
        //        Name = "Test",
        //        Type = PrinterType.Ink,
        //        Status = PrinterStatus.Active

        //    },
        //    new Printer()
        //    {
        //        Id = 2,
        //        Name = "Test2",
        //        Type = PrinterType.Jet,
        //        Status = PrinterStatus.Inactive
        //    },
        //    new Printer()
        //    {
        //        Id = 3,
        //        Name = "Test3",
        //        Type = PrinterType.Laser,
        //        Status = PrinterStatus.Active
        //    }
        //};


        public async Task<List<Printer>> GetPrinterList() 
        {
            //return _printerList;
            return await _printerContext.Printer.ToListAsync();
        }

        public async Task<Printer> GetPrinterById(int printerId)
        {
           return await _printerContext.Printer.FindAsync(printerId);
            //var printerList = GetPrinterList();  
            //var printer = printerList.Find(x => x.Id == printerId);
            //return printer;
        }

        public async Task<Printer> GetPrinterByName(string printerName)
        {
            return await _printerContext.Printer.FirstOrDefaultAsync(x => x.Name == printerName);
            
            //var printerList = GetPrinterList();
            //var printer = printerList.Find(x => x.Name == printerName);
            //return printer;
        }

        public async Task<Printer> AddPrinter(Printer printer)
        {
            //Printer Newprinter = new Printer();

            //Newprinter.Id = printer.Id;
            //Newprinter.Name = printer.Name;
            //Newprinter.Type = printer.Type;
            //Newprinter.Status = printer.Status;

            //_printerList.Add(Newprinter);
            //return Newprinter;

             await _printerContext.AddAsync(printer);  
            await _printerContext.SaveChangesAsync();
            return printer;
            
        }

        public async Task<Printer> UpdatePrinter(Printer updatedPrinter)
        {
            //var ExistedPrinter = GetPrinterById(updatedPrinter.Id);
            var ExistedPrinter = await _printerContext.Printer.FindAsync(updatedPrinter.Id);
            if (ExistedPrinter != null) 
            {
                ExistedPrinter.Name = updatedPrinter.Name;
                ExistedPrinter.Type = updatedPrinter.Type;
                ExistedPrinter.Status = updatedPrinter.Status;
            }
             
            await _printerContext.SaveChangesAsync();
            return updatedPrinter;  
            //ExistedPrinter.Id = updatedPrinter.Id;
            //ExistedPrinter.Name = updatedPrinter.Name;
            //ExistedPrinter.Type = updatedPrinter.Type;
            //ExistedPrinter.Status = updatedPrinter.Status;

            //return ExistedPrinter;
        }

        public async Task<bool> DeletePrinter(int id)
        {
            //var ExistedPrinter = GetPrinterById(id);
            var ExistedPrinter = await _printerContext.Printer.FindAsync(id);
            _printerContext.Remove(ExistedPrinter); 
             await  _printerContext.SaveChangesAsync();  
            return true;    
           //return _printerList.Remove(ExistedPrinter);
 
        }
    }
}