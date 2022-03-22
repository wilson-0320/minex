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
    [Route("cursos/[action]/{id?}")]
    public class cursoController : Controller
    {
        public string addCurso(string nombre,string descripcion,string codigo)
        {
              cursosMod.addCurso(nombre,descripcion,codigo);
            return cursosMod.listaCurso();


        }

        public string updateCurso(string nombre, string descripcion, string codigo)
        {
            cursosMod.updateCurso(nombre, descripcion, codigo);
            return cursosMod.listaCurso();
        }

        public string deleteCurso(string codigo)
        {
             cursosMod.deleteCurso(codigo);
            return cursosMod.listaCurso();
        }

        public String lista()
        {
            return cursosMod.listaCurso();
        }
    }
}
