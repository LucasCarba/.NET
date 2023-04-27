namespace Aseguradora.Aplicacion;
public class ModificarPolizaUseCase
{
    private readonly IPoliza _poliza;

    public ModificarPolizaUseCase(IPoliza poliza)
    {
        _poliza = poliza;
    }

    public void Ejecutar(Poliza p)
    {
        _poliza.Actualizar(p);
    }
}

