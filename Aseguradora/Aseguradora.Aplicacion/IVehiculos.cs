namespace Aseguradora.Aplicacion;
public interface IVehiculos
{
//Vehiculo ObtenerPorId(int id);
void Agregar(Vehiculo vehiculo);
void Modificar(Vehiculo vehiculo);
void Eliminar(int id);
List<Vehiculo> ListarVehiculo();
}
