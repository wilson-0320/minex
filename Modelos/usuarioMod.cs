using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minex_prueba.Datos;
using minex_prueba.BD;
namespace minex_prueba.Modelos
{
    public class usuarioMod
    {

        public static string listaUsuario()
        {

                return conexion.lista( "usuarios");

            

        }

        public static bool addUsuario(string nombre,string apellido,string cui, string edad)
        {

            
                if (cui==null)
                {
                    return true;

                }
                else
                {
                    String datos = (cui + "!" + nombre + "!" + apellido + "!" + edad)+"\n";
                    conexion.conectar(datos, "usuarios");
                    
                    return true;
                    
                }
                

            



        }

        public static bool updateUsuarios(string nombre, string apellido, string cui, string edad)
        {


            if (cui == null)
            {
                return false;

            }
            else
            {
                String datos = (cui + "!" + nombre + "!" + apellido + "!" + edad.ToString()) + "\n";
                return conexion.update(datos, "usuarios", cui);
               

            }
            
            
        }


        public static bool deleteUsuarios(string cui)
        {


            if (cui == null)
            {
                return false;

            }
            else
            {
               
                return conexion.delete( "usuarios", cui);


            }


        }



    }
}
