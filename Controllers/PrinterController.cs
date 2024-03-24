using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAPI.DTOs;
using WebAppAPI.Interfaces;



namespace WebAppAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {
        private IPrinter _printer;

        public PrinterController(IPrinter printer)
        {
            _printer = printer;
        }  

        [HttpGet]
        public async Task<ActionResult<List<Printer>>> GetPrintersList()
        { 
            return await _printer.GetPrinterList();  
        }

        [HttpGet("PrinterById")]
        public async Task<ActionResult<Printer>> GetPrinterById([FromQuery]int id)
        {
            return await _printer.GetPrinterById(id);
        }

        [HttpGet("PrinterByName")]
        public async Task<ActionResult<Printer>> GetPrinterByName([FromQuery] string name)
        {
            return await _printer.GetPrinterByName(name);
        }

        [HttpPost]
        public async Task<ActionResult<Printer>> AddPrinter(Printer printer)
        {
            return await _printer.AddPrinter(printer);
        }

        [HttpPut]
        public async Task<ActionResult<Printer>> UpdatePrinter(Printer printer)
        {
            return await _printer.UpdatePrinter(printer);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePrinter([FromQuery] int id)
        {
            return await _printer.DeletePrinter(id);
        }
    }
}
