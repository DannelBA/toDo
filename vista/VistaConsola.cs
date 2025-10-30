using Spectre.Console;

namespace Vista
{
    class VistaConsola
    {
        TareaControlador tc = new TareaControlador();
        public List<Tarea> listarTareas(List<Tarea> tareas)
        {
            return null;
        }

        public void cargarArchivos()
        {
            Console.Clear();
            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    var task1 = ctx.AddTask("[green]Cargando tus tareas.[/]");
                    

                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(10);
                        task1.Value(i);
                        if(i == 50){ task1.Value(i); };
                        if(i == 90){ task1.Description("Ya casi esta listo."); task1.Value(i);};
                        if(i == 99){ task1.Description("listo."); task1.Value(100);};
                    }
                });

            Console.ReadKey();

        }
    }
}
