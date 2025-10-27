using Vista;

namespace main
{
    class ProgramMain
    {
        public static void Main()
        {
            TareaControlador tc = new TareaControlador();
            VistaConsola vc = new VistaConsola();

            vc.cargarArchivos(tc.getPersistenciaTareas);

            tc.persistirTareas(vc.listarTareas(tc.listarTareas()));
        }
    }
}