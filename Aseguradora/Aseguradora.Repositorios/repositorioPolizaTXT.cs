using Aseguradora.Aplicacion;
namespace Aseguradora.Repositorios;
public class repositorioPolizaTXT : IPoliza
{
    readonly string _nombreArch = "C:/Users/Notebook/Aseguradora/Aseguradora.Consola/polizas.txt";

    public void Agregar(Poliza poliza)
            {
                using var sw = new StreamWriter(_nombreArch, true);
                sw.WriteLine(poliza.Id + "," + poliza.VehiculoId + "," + poliza.ValorAsegurado + "," + poliza.Franquicia + "," + poliza.TipoCobertura + "," + poliza.FechaInicioVigencia + "," + poliza.FechaFinVigencia);        
               }

    public void Actualizar (Poliza poliza) 
            {
                StreamReader lectura;
                StreamWriter escribir;
                string? cadena;
                bool encontrado = false;
                string[] campos=new string[7];
                char[] separador = {','};
                try {
                    lectura = File.OpenText("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/polizas.txt");
                    escribir = File.CreateText("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/tmp.txt");
                    cadena = lectura.ReadLine();
                    while(cadena!=null){
                        campos=cadena.Split(separador);
                        int idencon = int.Parse(campos[0]);
                        if(idencon.Equals(poliza.Id)){
                            encontrado=true;  
                            Console.WriteLine("******************************"); 
                            escribir.WriteLine(poliza.Id + "," + poliza.VehiculoId + "," + poliza.ValorAsegurado + "," + poliza.Franquicia + "," + poliza.TipoCobertura + "," + poliza.FechaInicioVigencia + "," + poliza.FechaFinVigencia);
                            Console.WriteLine("REGISTRO MODIFICADO");
                            Console.WriteLine("******************************");
                     } else{
                            escribir.WriteLine(cadena);
                        }
                        cadena = lectura.ReadLine();
                    }
                    if(encontrado==false){
                        Console.WriteLine("No se encontro el ID");
                    } 
                lectura.Close();
                escribir.Close();
                //Elimino.
                File.Delete("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/polizas.txt");
                //Muevo lo que tiene tmp a polizas (realizo el Renombrado). 
                File.Move("tmp.txt","C:/Users/Notebook/Aseguradora/Aseguradora.Consola/polizas.txt");
                }
                catch(FileNotFoundException fe){
                    Console.WriteLine("ERROR" + fe.Message);
                }catch(Exception e){
                    Console.WriteLine("ERROR" + e.Message);
                }
            }

    public void Eliminar (int id) {
        StreamReader lectura;
        StreamWriter escribir;
        string? cadena;
        bool encontrado = false;
        string[] campos=new string[7];
        char[] separador = {','};
        try {
            lectura = File.OpenText("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/polizas.txt");
            escribir = File.CreateText("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/tmp.txt");
            cadena = lectura.ReadLine();
            while(cadena!=null){
                campos=cadena.Split(separador);
                int idencon = int.Parse(campos[0]);
                if(idencon.Equals(id)){
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
        File.Delete("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/polizas.txt");
        //Muevo lo que tiene tmp a polizas (realizo el Renombrado). 
        File.Move("C:/Users/Notebook/Aseguradora/Aseguradora.Consola/tmp.txt","C:/Users/Notebook/Aseguradora/Aseguradora.Consola/polizas.txt");
        }
        catch(FileNotFoundException fe){
            Console.WriteLine("ERROR" + fe.Message);
        }catch(Exception e){
            Console.WriteLine("ERROR" + e.Message);
        }
    }
       
    public List<Poliza> ListarPoliza()
        {
            var resultado = new List<Poliza>();
            using var sr = new StreamReader(_nombreArch);
            while (!sr.EndOfStream){
                var poliza = new Poliza();
                poliza.Id = int.Parse(sr.ReadLine() ?? "");
                poliza.VehiculoId = int.Parse(sr.ReadLine() ?? "");
                poliza.ValorAsegurado = int.Parse(sr.ReadLine() ?? "");
                poliza.Franquicia = int.Parse(sr.ReadLine() ?? "");
                poliza.TipoCobertura= sr.ReadLine() ?? "";
                poliza.FechaInicioVigencia =  sr.ReadLine() ?? "";
                poliza.FechaFinVigencia =  sr.ReadLine() ?? "";
                resultado.Add(poliza);
            }
            return resultado;
        }
}

