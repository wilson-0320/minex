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
    [Route("asignar/[action]/{id?}")]
    public class asignarController : Controller
    {

        public String lista()
        {
            return asignacionCursoMod.listaAsignacion();
        }
        public String addAsignar(string usuario,string curso)
        {
            asignacionCursoMod.addAsignar(usuario, curso);
            return asignacionCursoMod.listaAsignacion();


        }

        public string updateAsignar(string usuario, string curso, string codigo)
        {
             asignacionCursoMod.updateAsignar(usuario, curso, codigo);
            return asignacionCursoMod.listaAsignacion();
        }

        public String deleteAsignar(string codigo)
        {
             asignacionCursoMod.deleteAsignar(codigo);
            return asignacionCursoMod.listaAsignacion();
        }
    }
}
