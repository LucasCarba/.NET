using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;
public class repositorioTitularTXT : ITitular
{
     readonly string _nombreArch = "C:/Users/Notebook/Aseguradora/Aseguradora.Consola/titulares.txt";

     public void Agregar(Titular titular){
            using var sw = new StreamWriter(_nombreArch, true);
            sw.WriteLine(titular.Id + "," + titular.Apellido + "," + titular.Nombre + "," + titular.DNI + "," + titular.Telefono + "," + titular.Direccion + "," + titular.Telefono);     
     }

     public void Modificar(Titular titular){
        StreamReader lectura;
        StreamWriter escribir;
        string? cadena;
        bool encontrado = false;
        string[] campos=new string[7];
        char[] separador = {','};
        try {
            lectura = File.OpenText("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/titulares.txt");
            escribir = File.CreateText("tmpT.txt");
            cadena = lectura.ReadLine();
            while(cadena!=null && encontrado==false){
                        campos=cadena.Split(separador);
                        if(campos[3].Trim().Equals(titular.DNI)){
                            encontrado=true;
                            Console.WriteLine("******************************");
                            Console.WriteLine("Dato encontrado con DNI->",titular.DNI);  
                            escribir.WriteLine(titular.Id + "," + titular.Apellido + "," + titular.Nombre + "," + titular.DNI + "," + titular.Telefono + "," + titular.Direccion + "," + titular.Telefono);
                            Console.WriteLine("REGISTRO MODIFICADO");
                     } else{
                            escribir.WriteLine(cadena);
                        }
                        cadena = lectura.ReadLine();
                    }
                    if(encontrado==false){
                        Console.WriteLine("No se encontro el titular con ese DNI");
                    } 
                lectura.Close();
                escribir.Close();
                //Elimino.
                File.Delete("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/titulares.txt");
                //Muevo lo que tiene tmp a polizas (realizo el Renombrado). 
                File.Move("tmpT.txt","C:/Users/Notebook/Aseguradora/Aseguradora.Consola/titulares.txt");
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
        string[] campos=new string[7];
        char[] separador = {','};
        try {
            lectura = File.OpenText("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/titulares.txt");
            escribir = File.CreateText("tmpT.txt");
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
        File.Delete("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/titulares.txt");
        //Muevo lo que tiene tmp a titulares.txt (realizo el Renombrado). 
        File.Move("tmpT.txt","C:/Users/Notebook/Aseguradora/Aseguradora.Consola/titulares.txt");
        }
        catch(FileNotFoundException fe){
            Console.WriteLine("ERROR" + fe.Message);
        }catch(Exception e){
            Console.WriteLine("ERROR" + e.Message);
        }
     }

    public List<Titular> ListarTitular()
    {
        var resultado = new List<Titular>();
        using var sr = new StreamReader(_nombreArch);
        while (!sr.EndOfStream){
                var titular = new Titular();
                titular.Id = int.Parse(sr.ReadLine() ?? "");
                titular.Apellido = sr.ReadLine() ?? "";
                titular.Nombre = sr.ReadLine() ?? "";
                titular.DNI = sr.ReadLine() ?? "";
                titular.Telefono= sr.ReadLine() ?? "";
                titular.Direccion = sr.ReadLine() ?? "";
                titular.CorreoElectronico = sr.ReadLine() ?? "";
                resultado.Add(titular);
            }
        return resultado;

     }
}