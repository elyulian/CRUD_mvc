using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_mvc.Models;
using CRUD_mvc.Models.ViewModels;

namespace CRUD_mvc.Controllers
{
    public class DatosController : Controller
    {
        
        // GET: Datos
        public ActionResult Index()
        {
            List<ListDatosViewModel> lst;
            using (CrudEntities1 bd = new CrudEntities1())
            {
                lst = (from d in bd.datos
                       select new ListDatosViewModel
                       {
                           id = d.id,
                           nombre = d.nombre,
                           correo = d.correo
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult listados() {

            using (CrudEntities1 bd = new CrudEntities1())
            {
                return View(bd.datos.ToList());

            }

        } 

        public ActionResult Nuevo()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(DatosViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities1 bd = new CrudEntities1())
                    {
                        var odatos = new datos();
                        odatos.id = model.id;
                        odatos.correo = model.correo;
                        odatos.nombre = model.nombre;
                        odatos.fecha_nacimiento = model.fecha_nacimiento;

                        bd.datos.Add(odatos);
                        bd.SaveChanges();
                    }
                    return Redirect("~/Datos/");
                }

                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            using (CrudEntities1 bd = new CrudEntities1())
            {
                return View(bd.datos.Where(x => x.id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Editar(datos d)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities1 bd = new CrudEntities1())
                    {
                        var datosP = bd.datos.Where(x => x.id == d.id).FirstOrDefault();

                        if (datosP != null)
                        {
                            datosP.nombre = d.nombre;
                            datosP.correo = d.correo;
                            datosP.fecha_nacimiento = d.fecha_nacimiento;
                            datosP.id = d.id;

                            bd.SaveChanges();
                        }
                    
                    }

                    return RedirectToAction("/");
                }

                return View();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {

            using (CrudEntities1 bd = new CrudEntities1())
            {
                var odatos = bd.datos.Find(id);
                bd.datos.Remove(odatos);
                bd.SaveChanges();
            }

            return Redirect("~/Datos/");
        }
    }
}
