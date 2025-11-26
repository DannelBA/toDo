using Spectre.Console;
using System;

namespace Vista
{
    class VistaConsola
    {
        TareaControlador tc = new TareaControlador();

        public void crearTarea()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Crando tarea.[/]\n");
            AnsiConsole.Markup("[steelblue3]Digita el titulo de la tarea: [/]\n");
            string titulo = Console.ReadLine();
            if(titulo == null)
            {
                AnsiConsole.Markup("[read0]Error al dijitar el titulo.[/]");
                crearTarea();
            }
            AnsiConsole.Markup("[steelblue3]Digita la descripccion de la tarea: [/]\n");
            string descripccion = Console.ReadLine();
            
            tc.agregarTarea(titulo, descripccion);

            listarTareas();

        }
        public void listarTareas()
        {
            List<Tarea> tareas = tc.listarTareas();
            bool execute = true;



            Console.CursorVisible = false;
            ConsoleKey key;
            int select = 0;


            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                AnsiConsole.Clear();
                Console.WriteLine(" ████████╗ ██████╗     ██████╗  ██████╗ \n" +
                                  "╚══ ██╔══╝██╔═══██╗    ██╔══██╗██╔═══██╗\n" +
                                  "    ██║   ██║   ██║    ██║  ██║██║   ██║\n" +
                                  "    ██║   ██║   ██║    ██║  ██║██║   ██║\n" +
                                  "    ██║   ╚██████╔╝    ██████╔╝╚██████╔╝\n" +
                                  "    ╚═╝    ╚═════╝     ╚═════╝  ╚═════╝ \n");

                AnsiConsole.Markup("[darkorange3]Tus tareas:[/]\n\n");

                for (int i = 0; i < tareas.Count; i++)
                {
                    if(select == i)
                    {
                        if(tareas[i].marcador)
                        {
                            AnsiConsole.Markup("\n[skyblue2]"+tareas[i].titulo+"[/]\n[lightskyblue3_1]"+tareas[i].descripccion+"[/] [green]Completada[/]\n");    
                        }else
                        {
                            AnsiConsole.Markup("\n[skyblue2]"+tareas[i].titulo+"[/]\n[lightskyblue3_1]"+tareas[i].descripccion+"[/] [red]No Completada[/]\n");
                        }
                        
                    }else
                    {
                        if(tareas[i].marcador)
                        {
                            AnsiConsole.Markup("\n"+tareas[i].titulo+"\n"+tareas[i].descripccion+" [green]Completada[/]\n");
                        }else
                        {
                            AnsiConsole.Markup("\n"+tareas[i].titulo+"\n"+tareas[i].descripccion+" [red]No Completada[/]\n");
                        }
                           
                    }
                }
                
                AnsiConsole.Markup("\n\n\n\nOprime el boton [green]C[/] para crear una nueva tarea.\n");
                AnsiConsole.Markup("Oprime el boton [green]E[/] para eliminar una tarea.\n");
                AnsiConsole.Markup("Oprime el boton [green]M[/] para marcar o desmarcar una tarea.\n"); 
                AnsiConsole.Markup("Oprime el boton [green]S[/] para salir de la aplicación.\n");   


                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        select++;
                        if(select >= tareas.Count)
                        {
                            select = 0;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        select--;
                        if(select < 0)
                        {
                            select = tareas.Count-1;
                        }
                        break;
                    case ConsoleKey.C:
                        crearTarea();
                        break; 
                    case ConsoleKey.E:
                        select--;
                        tc.eliminarTarea(select);
                        break; 
                    case ConsoleKey.S:
                        tc.persistirTareas();
                        execute = false;
                        break;
                    case ConsoleKey.M:
                        if(!tareas[select].marcador)
                        {
                            tc.marcarTarea(select);    
                        }else
                        {
                            tc.desmarcarTarea(select);
                        }
                        
                        break;

                }

            } while (execute);

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
                        if (i == 50) { task1.Value(i); tc.getPersistenciaTareas();}
                        ;
                        if (i == 90) { task1.Description("Ya casi esta listo."); task1.Value(i); }
                        ;
                        if (i == 99) { task1.Description("listo."); task1.Value(100); }
                        ;
                    }
                });

            Thread.Sleep(200);
            listarTareas();

        }
    }
}
