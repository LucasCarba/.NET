  
namespace Aseguradora.Aplicacion;
public interface IPoliza
{
    void Agregar(Poliza poliza);
    void Actualizar(Poliza poliza);
    void Eliminar(int id);
    List<Poliza> ListarPoliza();
}
