using System.Text.Json.Serialization;

class Tarea
{
    [JsonInclude]
    public string? titulo { get; set; }
    [JsonInclude]
    public string? descripccion { get; set; }
    [JsonInclude]
    public bool marcador { get; set; } = false;
    
    

    public Tarea() {
        
    }

    public Tarea(string titulo, string descripccion)
    {
        this.titulo = titulo;
        this.descripccion = descripccion;
    }

}