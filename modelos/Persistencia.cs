using System.Text.Json;
using System.Collections;

class Persistencia {
    private string namefile = "persistenciaTareas.json";

    public void serializer( List<Tarea> tareas) {
        string json = JsonSerializer.Serialize<List<Tarea>>(tareas);

        File.WriteAllText(namefile, json);
    }
    
    public List<Tarea>? deserializer() {
        string readText = File.ReadAllText(namefile);
        if(readText != null) {
            var tareas = JsonSerializer.Deserialize<List<Tarea>>(readText);
            return tareas;  
        }

        return null;
    }
}