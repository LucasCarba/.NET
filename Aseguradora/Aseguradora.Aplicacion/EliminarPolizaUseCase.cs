namespace Aseguradora.Aplicacion;
public class EliminarPolizaUseCase
{
    private readonly IPoliza _poliza;

    public EliminarPolizaUseCase(IPoliza poliza)
    {
        _poliza = poliza;
    }

    public void Ejecutar(int Id)
    {

           // throw new ArgumentException("La póliza no existe en el repositorio.");

        _poliza.Eliminar(Id);
    }
}
