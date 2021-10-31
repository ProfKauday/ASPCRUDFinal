using ASPCRUDFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPCRUDFinal.Controllers
{
    public class AlumnosAController : Controller
    {
        // GET: AlumnosA
        public ActionResult Index()
        {
            try
            {
                using (var db = new AlumnosContexto())
                {


                    //Envio la Lista a la vista para que la muestre
                    return View(db.AlumnosA.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AlumnosA a)

        { //Verifica el dato qe venga bien del lado servidor
            if (!ModelState.IsValid)

                return View();
            try
            {
                //para que abra y cierre la coneccion
                using (var db = new AlumnosContexto())
                {
                    //a.FechaIncripcion = DateTime.Now;
                    a.Sexo = a.Sexo.ToUpper();
                    db.AlumnosA.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el alumno " + ex.Message);
                return View();
            }



        }

        public ActionResult Editar(int id)

        { //Verifica el dato qe venga bien del lado servidor
            if (!ModelState.IsValid)

                return View();
            try
            {
                //para que abra y cierre la coneccion
                using (var db = new AlumnosContexto())
                {
                    //where lo uso en cualquier caso
                    // Alumnos al = db.Alumnos.Where(a => a.Id == id).FirstOrDefault();
                    //uso el find si solo tengo una clave primaria. no me sirve con clave compuesta
                    AlumnosA alu = db.AlumnosA.Find(id);
                    return View(alu);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el alumno " + ex.Message);
                return View();
            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(AlumnosA a)
        {
            try
            {
                using (var db = new AlumnosContexto())
                {
                    AlumnosA alu = db.AlumnosA.Find(a.id);
                    alu.Nombre = a.Nombre;
                    alu.Apellido = a.Apellido;
                    alu.Direccion = a.Direccion;
                    alu.Telefono = a.Telefono;
                    alu.Sexo = a.Sexo.ToUpper();
                    db.SaveChanges();

                    return RedirectToAction("index");
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Detalles(int id)
        {
            using (var db = new AlumnosContexto())
            {

                AlumnosA alu = db.AlumnosA.Find(id);
                return View(alu);
            }

        }


        public ActionResult Eliminar(int id)
        {
            using (var db = new AlumnosContexto())
            {

                AlumnosA alu = db.AlumnosA.Find(id);
                db.AlumnosA.Remove(alu);
                db.SaveChanges();

                return RedirectToAction("index");
            }

        }
    }
}