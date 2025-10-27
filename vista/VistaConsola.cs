using Spectre.Console;

namespace Vista
{
    class VistaConsola
    {
        public List<Tarea> listarTareas(List<Tarea> tareas)
        {
            int indiceSeleccionado = 0;
            ConsoleKey key;
            do
            {
                AnsiConsole.Clear();

                AnsiConsole.MarkupLine("[bold cyan]Lista de tareas[/]");
                AnsiConsole.MarkupLine("[grey]Usa las feclas para moverte, [green]C[/] para marcar, [red]E[/] para eliminar, [blue]Espacio[/] para salir[/]\n");

                for (int i = 0; i < tareas.Count; i++)
                {
                    var t = tareas[i];
                    string prefijo = i == indiceSeleccionado ? "[yellow]>[/]" : " ";
                    string estado = t.marcador ? "[green]✔[/]" : "[red]✖[/]";
                    string texto = $"{prefijo} {estado} [bold]{t.titulo}[/] [grey]({t.descripccion})[/]";
                    AnsiConsole.MarkupLine(texto);
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        indiceSeleccionado = (indiceSeleccionado - 1 + tareas.Count) % tareas.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        indiceSeleccionado = (indiceSeleccionado + 1) % tareas.Count;
                        break;

                    case ConsoleKey.C: // Marcar/desmarcar completada
                        tareas[indiceSeleccionado].marcador = !tareas[indiceSeleccionado].marcador;
                        break;

                    case ConsoleKey.E: // Eliminar tarea
                        tareas.RemoveAt(indiceSeleccionado);
                        if (tareas.Count == 0)
                            key = ConsoleKey.Enter; // salir si no hay más tareas
                        else
                            indiceSeleccionado = Math.Min(indiceSeleccionado, tareas.Count - 1);
                        break;
                }

            } while (key != ConsoleKey.Spacebar);

            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]✅ Programa finalizado.[/]");
            return tareas;
        }

        public void cargarArchivos(Action accionCarga)
        {
            AnsiConsole.Progress()
            .Columns(new ProgressColumn[]
            {
                new TaskDescriptionColumn(),       // descripción
                new ProgressBarColumn
                {
                    CompletedStyle = new Style(Color.Green),
                    RemainingStyle = new Style(Color.Grey),
                    Width = 40,
                },
                new PercentageColumn(),            // porcentaje
                new RemainingTimeColumn(),         // tiempo restante
                new SpinnerColumn(Spinner.Known.Dots) // animación
            })
            .Start(ctx =>
            {
                var tareaCargaArchivos = ctx.AddTask("[green]Cargando Tareas[/]", maxValue: 100);

                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(10);
                    tareaCargaArchivos.Value = i;

                    if (i == 70)
                        accionCarga();
                }
            });

            Console.Clear();
            Console.WriteLine("Presiona enter para continuar");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
