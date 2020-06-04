using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMantenedorOneClick.Models.ApiRest;
using WebMantenedorOneClick.Models.DTO;

namespace WebMantenedorOneClick.Controllers
{
    public class MantenedorOcController : Controller
    {
        #region Variables y Action Index

        // Llama al Api Rest para llamar al Webservice
        IngresosRest _restSip = new IngresosRest();

        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Get

        [HttpGet]
        public ActionResult FormBuscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(Producto p)
        {
            try
            {

                List<Producto> model = _restSip.GetProducto(p.rutAfiliado);
                return View(model);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public ActionResult ActivarEstado(int rutAfiliado, int codProducto)
        {
            try
            {

                _restSip.PostActivarEstado(rutAfiliado, codProducto);

                List<Producto> model = _restSip.GetProducto(rutAfiliado);
                return View("Buscar", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Resultado()
        {
            return View();
        }

        public ActionResult FormCambiarProd()
        {
            return View(new ListaProducto());
        }
        #endregion
    }
}