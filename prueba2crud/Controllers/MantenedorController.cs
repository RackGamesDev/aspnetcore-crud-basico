using Microsoft.AspNetCore.Mvc;
using prueba2crud.Datos;//importar tanto la carpeta de datos como Models
using prueba2crud.Models;

namespace prueba2crud.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();//tener variable con la clase del script de la carpeta datos
        public IActionResult Listar()//la vista mostrara una lista de contactos (objetos de la db)
        {
            var oLista = _ContactoDatos.Listar();//metodos ya hechos en el script de Datos
            return View(oLista);//el html recibe toda la lista de contactos, el html ya se encargara de dibujarla
        }

        public IActionResult Guardar()//devuelve la vista con el formulario para guardar (no hace nada en la db)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)//recibe objeto y lo guarda en db
        {
            if (!ModelState.IsValid)//para las validaciones
                return View();//en caso de que falle
            var respuesta = _ContactoDatos.Guardar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");//si todo va bien guardando vuelve a Listar()
            else
                return View();//volver al view de guardar si algo va mal
        }
        
        public IActionResult Editar(int IdContacto)//devuelve la vista con el formulario para editar un entry concreto
        {
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)//recibe el objeto y lo reemplaza en la db por el del mismo id (es similar al guardar() con httppost)
        {
            if (!ModelState.IsValid)
                return View();
            var respuesta = _ContactoDatos.Editar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto)//devuelve la vista con todo lo de eliminar (no hace nada en la db)
        {
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)//recibe el objeto y lo elimina (no hacen falta validaciones)
        {
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
//controlador mvc en blanco, el archivo debe acabar en Controller.cs