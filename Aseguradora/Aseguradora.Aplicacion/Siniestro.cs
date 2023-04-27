namespace Aseguradora.Aplicacion;
public class Siniestro
{
    public int Id { get; set; }
    public int PolizaId { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaOcurrencia { get; set; }
    public string? DireccionHecho { get; set; }
    public string? DescripcionAccidente { get; set; }
}
