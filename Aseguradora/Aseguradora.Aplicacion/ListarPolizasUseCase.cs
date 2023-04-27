namespace Aseguradora.Aplicacion;

public class ListarPolizasUseCase
{
    private readonly IPoliza _poliza;

    public ListarPolizasUseCase(IPoliza poliza)
    {
        _poliza = poliza;
    }

    public List<Poliza> Ejecutar()
    {
        return _poliza.ListarPoliza();
    }
}
