using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMantenedorOneClick.Models.ApiRest;
using WebMantenedorOneClick.Models.DTO;

namespace WebMantenedorOneClick.Controllers
{
    public class ProductoController : Controller
    {

        #region Variables y Action Index

        // Llama al Api Rest para llamar al Webservice
        IngresosRest _restSip = new IngresosRest();

        public ActionResult Index()
        {
            return View();
        }
        #endregion

        public ActionResult FormAgregar()
        {
            return View(new ProductoOc());
        }

        public ActionResult FormBuscar()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }


        public ActionResult FormEditar(int codproducto, string isapre, string nombre, string estado, double valor, string beneficiario)
        {
            
            ProductoOc p = new ProductoOc();
            p.codigo = codproducto;
            p.nombre = nombre;
            p.estado = estado;
            p.valor = valor;
            p.beneficiario = beneficiario;

            if (isapre == "B")
            {
                p.isapre = "Banmedica";
            }
            else
            {
                p.isapre = "Vida Tres";
            }

            if(beneficiario == "S")
            {
                p.beneficiario = "Selecciona cargas";
            }
            else
            {
                p.beneficiario = "Todas las cargas";
            }

            return View(p);
        }

        public ActionResult Agregar(ProductoOc p)
        {
            try
            { 
                System.Web.HttpContext.Current.Session["usuarioCreador"] = "pedrito";
                

                var aux_fecha = p.fechaInicio.ToShortDateString();
                //var aux_valor = Convert.ToDouble(p.valor);

                var wea = _restSip.PostAgregarProducto(p.codigo, p.nombre, Convert.ToDateTime(aux_fecha), p.isapre, System.Web.HttpContext.Current.Session["usuarioCreador"] as String, p.newValor, p.beneficiario);


                List<ProductoOc> weaList = new List<ProductoOc>();

                if (wea.mensajeError == "OK")
                {
                    weaList = _restSip.GetProductoCod(p.codigo);
                    ViewBag.Ok = "El producto ha sido ingresado correctamente";
                    return View("Buscar", weaList);
                }
                else
                {
                    ViewBag.Wea = wea.mensajeError;
                    return View("Error");
                }
                
            }
            catch(Exception)
            {
                return View("Error"); 
            }
            
        }

        public ActionResult Buscar(ProductoOc p)
        {
            try
            {
                List<ProductoOc> model = _restSip.GetProductoCod(p.codigo);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Editar(ProductoOc p)
        {
            try
            {
                _restSip.PostEditarProducto(p.codigo, p.isapre, p.nombre, p.estado, p.newValor, p.beneficiario, p.confirmo);

                List<ProductoOc> model = _restSip.GetProductoCod(p.codigo);

                ViewBag.Edit = "El producto ha sido modificado correctamente";

                return View("Buscar", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult TerminarVigencia(int codproducto, string isapre)
        {
            try
            {
                _restSip.PostTerminarVigencia(codproducto, isapre);

                List<ProductoOc> model = _restSip.GetProductoCod(codproducto);

                return View("Buscar", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public JsonResult GetProductos(string isapre)
        {
            List<SelectListItem> subCat = new List<SelectListItem>();

            subCat.Add(new SelectListItem
            {
                Text = "Seleccione el producto",
                Value = "0"
            });

            switch (isapre)
            {
                case "B":
                    subCat.Add(new SelectListItem { Text = "111 - Farmacia 80%", Value = "111" });
                    subCat.Add(new SelectListItem { Text = "1111 - Accidentes CSM", Value = "1111" });
                    subCat.Add(new SelectListItem { Text = "123 - Farmacia 80%", Value = "123" });
                    subCat.Add(new SelectListItem { Text = "935 - Dental 80%", Value = "935" });
                    subCat.Add(new SelectListItem { Text = "935 - Farmacia 80%", Value = "935" });
                    subCat.Add(new SelectListItem { Text = "936 - Dental 80%", Value = "936" });
                    subCat.Add(new SelectListItem { Text = "936 - Farmacia 80%", Value = "936" });
                    break;
                case "T":
                    subCat.Add(new SelectListItem { Text = "935 - Farmacia 80%", Value = "935" });
                    subCat.Add(new SelectListItem { Text = "936 - Dental 80%", Value = "936" });
                    break;

                default:
                    break;
            }

            return Json(new SelectList(subCat,
                            "Value", "Text"));
        }

        public ActionResult CambiarProd(ListaProducto p)
        {
            try
            {

                var agregar = _restSip.PostCambiarProducto(p.codigoProductoOld, p.codigoProductoNew, p.isapre);


                List<ProductoOc> pList = new List<ProductoOc>();

                if (agregar.mensajeError == "OK")
                {
                    pList = _restSip.GetProductoCod(p.codigoProductoNew);
                    ViewBag.Ok = "El código de producto ha sido actualizado correctamente";
                    return View("Buscar", pList);
                }
                else
                {
                    ViewBag.Wea = agregar.mensajeError;
                    return View("Error");
                }

            }
            catch (Exception)
            {
                return View("Error");
            }

        }
    }
}