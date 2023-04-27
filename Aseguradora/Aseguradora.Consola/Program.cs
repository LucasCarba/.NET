using Aseguradora.Aplicacion;
using Aseguradora.Repositorios;

//Configuramos las dependencias de Polizas
IPoliza poliza = new repositorioPolizaTXT();

//Creo los casos de uso
var agregarPoliza = new AgregarPolizaUseCase(poliza);
var eliminarPoliza = new EliminarPolizaUseCase(poliza);
var modificarPoliza = new ModificarPolizaUseCase(poliza);
var listarPoliza = new ListarPolizasUseCase(poliza);

//Ejecutamos los casos de uso
//metodo agregar poliza funciona.
agregarPoliza.Ejecutar(new Poliza() { Id=1 , VehiculoId=3, ValorAsegurado=255555, Franquicia=28456, TipoCobertura="Todo Riesgo", FechaInicioVigencia="5/1/2008" , FechaFinVigencia="28/02/2024" });
agregarPoliza.Ejecutar(new Poliza() { Id=2 , VehiculoId=2, ValorAsegurado=589555, Franquicia=28996, TipoCobertura="Todo Riesgo", FechaInicioVigencia="5/1/2010" , FechaFinVigencia="28/02/2028" });
agregarPoliza.Ejecutar(new Poliza() { Id=3 , VehiculoId=1, ValorAsegurado=123555, Franquicia=78954, TipoCobertura="Todo Riesgo", FechaInicioVigencia="5/1/2010" , FechaFinVigencia="28/02/2028" });
//metodo eliminar poliza funciona.
//eliminarPoliza.Ejecutar(1);
// metodo modificar funciona
//modificarPoliza.Ejecutar(new Poliza() { Id=2 , VehiculoId=0, ValorAsegurado=00000, Franquicia=00000, TipoCobertura="Todo Riesgo", FechaInicioVigencia="5/1/2010" , FechaFinVigencia="28/02/2028" });

var lista = listarPoliza.Ejecutar();
foreach(Poliza p in lista){
    Console.WriteLine(p);
}