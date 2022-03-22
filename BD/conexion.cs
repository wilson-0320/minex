using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace minex_prueba.BD
{
    public class conexion
    {

        public static String lista(string tabla)
        {

            String cuerpo="";
            string pathString = @"D:\carpeta\SubFolder\";
            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }
            pathString = pathString + tabla + ".txt";
            string cadena = "[";
            if (File.Exists(pathString))
            {
                StreamReader fileReader = new StreamReader(pathString);
                String[] elementosArchivo = fileReader.ReadToEnd().Split("\n");
                fileReader.Close();

                for (int a = 0; a < elementosArchivo.Length - 1; a++)
                {
                    String[] elementosFila = elementosArchivo[a].Split("!");
                    cadena = cadena + "{";
                   for(int b = 0; b < elementosFila.Length ; b++)
                    {

                        if (tabla.Equals("usuarios"))
                        {
                            switch (b)
                            {
                                case 0:cuerpo = "cui";
                                    break;
                                case 1: cuerpo = "nombre";
                                    break;
                                case 2: cuerpo = "apellido";
                                    break;
                                case 3: cuerpo = "edad";
                                    break;

                            }
                                
                            
                                
                        }

                        if (b == elementosFila.Length - 1)
                        {
                            cadena = cadena + "\""+cuerpo+  "\"" + ":" + elementosFila[b] + "";
                        }
                        else
                        {
                            cadena = cadena + "\"" + cuerpo + "\"" + ":\"" + elementosFila[b] + "\",";
                        }
                       
                        
                       
                    }
                    if (a == elementosArchivo.Length - 2)
                    {
                        cadena = cadena + "}";
                    }
                    else
                    {
                        cadena = cadena + "},";
                    }
                    


                }

                cadena = cadena + "]";
            }


            return cadena;
        }

        public static Boolean conectar(string cadena,string tabla)
        {
            

            string pathString = @"D:\carpeta\SubFolder\";
            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }
            pathString = pathString+tabla+".txt";
          
            if (File.Exists(pathString))
            {
                StreamReader fileReader = new StreamReader(pathString);
                // string cadena = cadena +
                cadena = cadena +fileReader.ReadToEnd();
                fileReader.Close();
                File.WriteAllText(pathString, cadena);
                
            }
            else
            {
                
                File.WriteAllText(pathString, cadena);
                
            }

            
            return true;
        }

        public static Boolean update(string cadena, string tabla,string identificado)
        {
            string texto = "";
            string pathString = @"D:\carpeta\SubFolder\";

            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }

            pathString = pathString  + tabla + ".txt";


            if (File.Exists(pathString))
            {
                StreamReader fileReader = new StreamReader(pathString);
                String[] elementosArchivo = fileReader.ReadToEnd().Split("\n");
                fileReader.Close();

                for (int a = 0; a < elementosArchivo.Length-1; a++)
                {
                    String[] elementosFila = elementosArchivo[a].Split("!");
                    if (elementosFila[0].Equals(identificado))
                    {
                        texto = texto + "" + cadena;
                    }
                    else
                    {
                        texto = texto + "" + elementosArchivo[a]+"\n";
                    }
                }


                File.WriteAllText(pathString, texto);
                return true;


            }
            else
            {
                return false;
            }
            
            


           
        }


        public static Boolean delete(string tabla, string identificado)
        {
            string texto = "";
            string pathString = @"D:\carpeta\SubFolder\";

            if (!System.IO.Directory.Exists(pathString))
            {
                System.IO.Directory.CreateDirectory(pathString);
            }

            pathString = pathString + tabla + ".txt";


            if (File.Exists(pathString))
            {
                StreamReader fileReader = new StreamReader(pathString);
                String[] elementosArchivo = fileReader.ReadToEnd().Split("\n");
                fileReader.Close();

                for (int a = 0; a < elementosArchivo.Length - 1; a++)
                {
                    String[] elementosFila = elementosArchivo[a].Split("!");
                    if (elementosFila[0].Equals(identificado))
                    {
                        
                    }
                    else
                    {
                        texto = texto + "" + elementosArchivo[a] + "\n";
                    }
                }


                File.WriteAllText(pathString, texto);
                return true;


            }
            else
            {
                return false;
            }





        }
    }
}
