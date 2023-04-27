namespace Aseguradora.Aplicacion;
public class AgregarPolizaUseCase
{
    private readonly IPoliza _poliza;
    public AgregarPolizaUseCase(IPoliza poliza)
    {
        _poliza = poliza;
    }
    public void Ejecutar(Poliza p)
    {
        _poliza.Agregar(p);
        p.Id++;
    }
}
