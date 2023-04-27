namespace Aseguradora.Aplicacion;
public class Poliza
{
    public int Id { get; set; }
    public int VehiculoId { get; set; }
    public decimal ValorAsegurado { get; set; }
    public decimal Franquicia { get; set; }
    public string? TipoCobertura { get; set; }
    public string?  FechaInicioVigencia { get; set; }
    public string?  FechaFinVigencia { get; set; }
}
