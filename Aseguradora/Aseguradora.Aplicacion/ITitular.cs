namespace Aseguradora.Aplicacion;
public interface ITitular
{
//Titular ObtenerPorId(int id);
void Agregar(Titular titular);
void Modificar(Titular titular);
void Eliminar(int id);
List<Titular> ListarTitular();
}
