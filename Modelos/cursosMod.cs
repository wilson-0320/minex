using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minex_prueba.BD;
namespace minex_prueba.Modelos
{
    public class cursosMod
    {
        public static string listaCurso()
        {

            return conexion.lista("cursos");



        }
        public static bool addCurso(string nombre, string descripcion, string codigo)
        {


            if (codigo == null)
            {
                return true;

            }
            else
            {
                String datos = (codigo + "!" + nombre + "!" + descripcion + "\n");
                conexion.conectar(datos, "cursos");

                return true;

            }






        }

        public static bool updateCurso(string nombre, string descripcion, string codigo)
        {


            if (codigo == null)
            {
                return false;

            }
            else
            {
                String datos = (codigo + "!" + nombre + "!" + descripcion + "\n");
                return conexion.update(datos, "cursos", codigo);


            }


        }


        public static bool deleteCurso( string codigo)
        {


            if (codigo == null)
            {
                return false;

            }
            else
            {
               
                return conexion.delete( "cursos", codigo);


            }


        }


    }
}
