using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{

    
    public class Datos_Libros
    {
        //CONTEXTO DE ENTITY...
        EjerciciosGeneralesEntities db = new EjerciciosGeneralesEntities();

        

        //METODO PARA OBTENER TODOS LOS LIBROS...
        /// <summary>
        /// Método para obtener libros.
        /// </summary>
        /// <returns>Regresa una lista con objetos del tipo Libros</returns>
        public List<Libros> ObtenerLibros()
        {
            //TO LIST CONVIERTE LA CONSULTA EN UNA LISTA DE DATOS DEL TIPO (EN ESTE CASO DEL TIPO LIBRO)
            return db.Libros.ToList();
        }

        //METODO PARA AGREGAR LIBRO...
        public void AgregarLibro(Libros libro)
        {
            db.Libros.Add(libro);
            db.SaveChanges();
            db.Dispose();
        }


        //METODO PARA OBTENER LIBRO POR ID...
        public Libros ObtenerLibroPorId(int id) {
            var query = from libro in db.Libros where libro.idLibro == id select libro;
            return query.FirstOrDefault();
        }


        //METODO PARA ELMINAR LIBRO...
        public void EliminarLibro(int id)
        {
            Libros libro = ObtenerLibroPorId(id);
            db.Libros.Remove(libro);
            db.SaveChanges();
            db.Dispose();
        }

        //METODO PARA EDITAR LIBRO...
        public void EditarLibro(Libros objLibroEditado)
        {
            db.Entry(objLibroEditado).State = EntityState.Modified;
            db.SaveChanges();
        }



    }
}
