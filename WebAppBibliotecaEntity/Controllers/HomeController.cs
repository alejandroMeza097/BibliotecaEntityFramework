using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppBibliotecaEntity.Controllers
{
    public class HomeController : Controller
    {
        //INSTANCIA DE LA CAPA DE NEGOCIOS...

        Negocio_Libros negocioLibros = new Negocio_Libros();
        public ActionResult Index()
        {
            try
            {
                List<Libros> listaLibros = new List<Libros> ();
                listaLibros = negocioLibros.ObtenerLibros();
                return View("Index",listaLibros);
            }
            catch(Exception ex)
            {

            }
            return View("Index");
        }

        //METODO PARA IR A LA VISTA DE AGREGAR...
        /// <summary>
        /// Metodo para la vista de agregar
        /// </summary>
        /// <returns></returns>
        public ActionResult IrAgregar() 
        {
            return View("IrAgregar");
        }


        //METODO PARA AGREGAR UN NUEVO LIBRO...
        public ActionResult AgregarLibro(Libros objLibro)
        {
            try
            {
                negocioLibros.AgregarLibro (objLibro);
                TempData["msg"] = "Libro agregado con exito";
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["err"] = "Libro NO agregado";
                return RedirectToAction("IrAgregar");
            }
        }

        //METODO PARA ELIMINAR NUEVO ELEMENTO...
        public ActionResult EliminarLibro(int id)
        {
            try
            {
                negocioLibros.ElimnarLibro (id);
                TempData["msg"] = "Libro eliminado con exito";
                return RedirectToAction("Index");

            }
            catch(Exception e)
            {
                TempData["err"] = "Libro NO eliminado";
                return RedirectToAction ("Index");  
            }
        }


        //METODO PARA IR A EDITAR...
        public ActionResult IrEditar(int id)
        {
            try
            {   Libros objLibro = new Libros();
                objLibro = negocioLibros.ObtenerLibroPorId(id);
                return View("IrEditar",objLibro);


            }
            catch(Exception e)
            {
                TempData["err"] = "No se puede recuperar la informacion";
                return RedirectToAction("Index");

            }
        }

        //METODO PARA EDITAR LIBRO...
        public ActionResult EditarLibro(Libros objLibro)
        {
            try
            {
                negocioLibros.EditarLibros (objLibro);
                TempData["msg"] = "Libro editado con exito";
                return RedirectToAction("Index");

            }
            catch(Exception e) 
            {
                Libros libro = negocioLibros.ObtenerLibroPorId(objLibro.idLibro);

                return View("IrEditar", libro);
            }
        }





    }
}