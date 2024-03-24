namespace WebAppAPI.DTOs
{
    public class Printer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PrinterType Type { get; set; }   
        public PrinterStatus Status { get; set; }   

        public Printer()
        { }    
        
    }

    public enum PrinterType
    { 
        Ink = 0,
        Jet = 1,
        Laser= 2
    }

    public enum PrinterStatus
    {
        Active = 0,
        Inactive = 1
    }
}
