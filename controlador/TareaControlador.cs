using Vista;

class TareaControlador {
    private Persistencia pr = new Persistencia();
    private List<Tarea> tareas = new List<Tarea>();


    public List<Tarea> listarTareas() {
        return tareas;
    }

    public void agregarTarea(string titulo, string descripcion) {
        Tarea t = new Tarea(titulo, descripcion);

        tareas.Add(t);
    }

    public void eliminarTarea(int indice)
    {
        tareas.RemoveAt(indice);
    }

    public void marcarTarea(int i)
    {
        tareas[i].marcador = true;
    }

    public void desmarcarTarea(int i)
    {
        tareas[i].marcador = false;
    }

    public void persistirTareas()
    {
        pr.serializer(tareas);
    }

    public void getPersistenciaTareas()
    {
        List<Tarea> tareas = pr.deserializer();

        this.tareas = tareas;

    }
}