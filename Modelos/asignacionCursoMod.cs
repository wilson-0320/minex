using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minex_prueba.BD;
namespace minex_prueba.Modelos
{
    public class asignacionCursoMod
    {

        public static string listaAsignacion()
        {

            return conexion.lista("asignar");



        }

        public static bool addAsignar(string usuario, string curso)
        {


            if (usuario == null | curso== null)
            {
                return true;

            }
            else
            {
                String codigo = DateTime.Now.Year +"-"+ usuario.Substring(0, 1) + "-" + curso.Substring(0, 1);
                String datos = (codigo+"!"+usuario + "!" + curso+"\n");
                conexion.conectar(datos, "asignar");

                return true;

            }






        }

        public static bool updateAsignar(string usuario, string curso, string codigo)
        {


            if (codigo == null)
            {
                return false;

            }
            else
            {
                String datos = (codigo+"!"+usuario + "!" + curso + "\n");
               return conexion.update(datos, "asignar",codigo);


            }


        }


        public static bool deleteAsignar( string codigo)
        {


            if (codigo == null)
            {
                return false;

            }
            else
            {
               
                return conexion.delete( "asignar", codigo);


            }


        }


    }
}
