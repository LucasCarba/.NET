namespace Aseguradora.Aplicacion;
public abstract class Persona
{
    public int Id { get; set; }
    public string? DNI { get; set; }
    public string? Apellido { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    
    public override string ToString()
    {
        return $"{Apellido}, {Nombre}";
    }
}

