namespace main
{
    class Test
    {
        static public void Main()
        {
            Persistencia p = new Persistencia();

            // ----------------------------------------------------
            // 1. Crear lista de tareas para guardar
            // ----------------------------------------------------
            List<Tarea> tareas = new List<Tarea>()
        {
            new Tarea("Comprar pan", "Ir a la tienda a comprar pan"),
            new Tarea("Estudiar C#", "Repasar clases y practicar ejercicios"),
            new Tarea("Llamar a Juan", "Preguntar sobre el proyecto")
        };

            Console.WriteLine("Guardando tareas en persistenciaTareas.json...");
            p.serializer(tareas);
            Console.WriteLine("Tareas guardadas.\n");


            // ----------------------------------------------------
            // 2. Leer el archivo persistenciaTareas.json
            // ----------------------------------------------------
            Console.WriteLine("Leyendo tareas desde el archivo...");
            List<Tarea>? cargadas = p.deserializer();

            if (cargadas == null)
            {
                Console.WriteLine("No se pudieron cargar las tareas (archivo vacío o error).");
                return;
            }

            Console.WriteLine("\n=== TAREAS CARGADAS ===");

            foreach (var t in cargadas)
            {
                Console.WriteLine($"Título: {t.titulo}");
                Console.WriteLine($"Descripción: {t.descripccion}");
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Fin de prueba.");
            Console.ReadKey(true);

        }
    }
}
