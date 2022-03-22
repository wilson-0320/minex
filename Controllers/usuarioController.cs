using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minex_prueba.Datos;
using minex_prueba.Modelos;

namespace minex_prueba.Controllers
{
    [ApiController]
    [Route("usuario/[action]/{id?}")]
    public class usuarioController : Controller
    {
        public string addUsuario(string nombre,string apellido,string cui,string edad)
        {
             usuarioMod.addUsuario(nombre,apellido,cui,edad);
            return usuarioMod.listaUsuario();


        }

        public string updateUsuario(string nombre, string apellido, string cui, string edad)
        {
             usuarioMod.updateUsuarios(nombre, apellido, cui, edad);
            return usuarioMod.listaUsuario();
        }

        public string deleteUsuario(string cui)
        {
            usuarioMod.deleteUsuarios(cui);
            return usuarioMod.listaUsuario();
        }

        public String lista()
        {
            return usuarioMod.listaUsuario();
        }
    }
}
