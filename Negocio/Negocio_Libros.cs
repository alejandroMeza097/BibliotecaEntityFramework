using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Negocio_Libros
    {

        //INSTANCIA DE LA CAPA DE DATOS...
        Datos_Libros datosLibros = new Datos_Libros();


        //METODO PARA OBTENER LIBROS...
        public List<Libros> ObtenerLibros()
        {
            return datosLibros.ObtenerLibros();
        }

        //METODO PARA AGREGAR LIBRO...
        public void AgregarLibro(Libros objLibro) 
        {
            datosLibros.AgregarLibro(objLibro);
        }


        //METODO PARA OBTENER LIBRO POR ID...
        public Libros ObtenerLibroPorId(int id)
        {
            return datosLibros.ObtenerLibroPorId((int)id);  
        }

        //METODO PARA ELMINAR LIBROS...
        public void ElimnarLibro(int id)
        {
            datosLibros.EliminarLibro(id);
        }

        //METODO PARA EDITAR LIBROS...
        public void EditarLibros(Libros objLibroEditado) 
        { 
            datosLibros.EditarLibro(objLibroEditado);
        }

    }
}
