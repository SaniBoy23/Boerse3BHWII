namespace BoerseWebApp3BHWII.Models;

public class Transaktion
{
    public int transaktionid { get; set; }
    
    public int depotid { get; set; }
    
    public int aktienid { get; set; }
    
    public DateTime transaktionsdatum { get; set; }
    
    public bool transaktionstyp { get; set; }
    
    public int anzahl { get; set; }
}
