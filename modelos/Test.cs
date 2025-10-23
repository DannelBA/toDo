class Test
{
    static public void Main()
    {
        List<Tarea> tareas = new List<Tarea>();
        Persistencia pr = new Persistencia();

        Tarea t1 = new Tarea("hacer ejercicio", "salir a correr");
        Tarea t2 = new Tarea("hacer parkour", "salir a saltar por ahi");
        Tarea t3 = new Tarea("tocar guitarra", "practicar 2 horas");

        tareas.Add(t1);
        tareas.Add(t2);
        tareas.Add(t3);

        pr.serializer(tareas);
    }
}