using Spectre.Console;

namespace Vista
{
    class VistaConsola
    {
        public static void Main(string[] args)
        {
            AnsiConsole.Markup("[underline red]Hello[/] World!");
            Console.ReadKey(true);


        }

        public void cargarArchivos(Action accionCarga)
        {
            AnsiConsole.Progress()
            .Columns(new ProgressColumn[]
            {
                new TaskDescriptionColumn(),    // Task description
                new ProgressBarColumn {
                    CompletedStyle = new Style(foreground: Color.Green),
                    RemainingStyle = new Style(foreground: Color.Red),
                    IndeterminateStyle = new Style(foreground: Color.Grey)
                },        // Progress bar
                new PercentageColumn(),         // Percentage
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
                Console.ReadKey(true);
            });
        }
    }
}
