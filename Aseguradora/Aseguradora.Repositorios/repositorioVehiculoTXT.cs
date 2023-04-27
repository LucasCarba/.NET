using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;
public class repositorioVehiculoTXT : IVehiculos
{
     readonly string _nombreArch = "C:/Users/Notebook/Aseguradora/Aseguradora.Consola/vehiculos.txt";

     public void Agregar(Vehiculo vehiculo){
            using var sw = new StreamWriter(_nombreArch, true);
            sw.WriteLine(vehiculo.Id + "," + vehiculo.Dominio + "," + vehiculo.Marca + "," + vehiculo.AnioFabricacion + "," + vehiculo.TitularId);
            }
     public void Modificar(Vehiculo vehiculo){
        StreamReader lectura;
        StreamWriter escribir;
        string? cadena;
        bool encontrado = false;
        string[] campos=new string[5];
        char[] separador = {','};
        try {
            lectura = File.OpenText("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/vehiculos.txt");
            escribir = File.CreateText("tmpV.txt");
            cadena = lectura.ReadLine();
            while(cadena!=null && encontrado==false){
                        campos=cadena.Split(separador);
                        if(campos[0].Trim().Equals(vehiculo.Id)){
                            encontrado=true;
                            Console.WriteLine("******************************");
                            Console.WriteLine("Dato encontrado con ID->",vehiculo.Id);  
                            escribir.WriteLine(vehiculo.Id + "," + vehiculo.Dominio + "," + vehiculo.Marca + "," + vehiculo.AnioFabricacion + "," + vehiculo.TitularId);
                            Console.WriteLine("REGISTRO MODIFICADO");
                     } else{
                            escribir.WriteLine(cadena);
                        }
                        cadena = lectura.ReadLine();
                    }
                    if(encontrado==false){
                        Console.WriteLine("No se encontro el vehiculo con ese ID");
                    } 
                lectura.Close();
                escribir.Close();
                //Elimino.
                File.Delete("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/vehiculos.txt");
                //Muevo lo que tiene tmpV a vehiculos (realizo el Renombrado). 
                File.Move("tmpV.txt","C:/Users/Notebook/Aseguradora/Aseguradora.Consola/vehiculos.txt");
                }
                catch(FileNotFoundException fe){
                    Console.WriteLine("ERROR" + fe.Message);
                }catch(Exception e){
                    Console.WriteLine("ERROR" + e.Message);
                }
            }

     public void Eliminar(int id){
        StreamReader lectura;
        StreamWriter escribir;
        string? cadena;
        bool encontrado = false;
        string[] campos=new string[5];
        char[] separador = {','};
        try {
            lectura = File.OpenText("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/vehiculos.txt");
            escribir = File.CreateText("tmpV.txt");
            cadena = lectura.ReadLine();
            while(cadena!=null && encontrado==false){
                campos=cadena.Split(separador);
                if(campos[0].Trim().Equals(id)){
                    encontrado=true;  
                } else{
                    escribir.WriteLine(cadena);
                }
                cadena = lectura.ReadLine();
            }
            if(encontrado==false){
                Console.WriteLine("No se encontro el ID");
            } else {
                 Console.WriteLine("Registro eliminado.");
            }
        lectura.Close();
        escribir.Close();
        //Elimino.
        File.Delete("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/vehiculos.txt");
        //Muevo lo que tiene tmp a titulares.txt (realizo el Renombrado). 
        File.Move("tmpV.txt","C:/Users/Notebook/Aseguradora/Aseguradora.Consola/vehiculos.txt");
        }
        catch(FileNotFoundException fe){
            Console.WriteLine("ERROR" + fe.Message);
        }catch(Exception e){
            Console.WriteLine("ERROR" + e.Message);
        }
     }
     public List<Vehiculo> ListarVehiculo()
    {
        var resultado = new List<Vehiculo>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream){
                var vehiculo = new Vehiculo();
                vehiculo.Id = int.Parse(sr.ReadLine() ?? "");
                vehiculo.Dominio = sr.ReadLine() ?? "";
                vehiculo.Marca = sr.ReadLine() ?? "";
                vehiculo.AnioFabricacion = int.Parse(sr.ReadLine() ?? "");
                vehiculo.TitularId= int.Parse(sr.ReadLine() ?? "");
                resultado.Add(vehiculo);
            }
        return resultado;
    }

     

}