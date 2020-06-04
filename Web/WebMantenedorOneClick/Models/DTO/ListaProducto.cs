using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMantenedorOneClick.Models.DTO
{
    public class ListaProducto
    {
        public SelectList LstProductos { get; set; }
        public int codigoProducto { get; set; }
        public int codigoProductoOld { get; set; }
        public int codigoProductoNew { get; set; }
        public string nombreProducto { get; set; }
        public List<SelectListItem> lstIsapre = new List<SelectListItem>();
        public List<SelectListItem> lstProducto = new List<SelectListItem>();
        public SelectList LstIsapres { get; set; }
        public string isapre { get; set; }

        public ListaProducto(int codigo)
        {
            this.codigoProductoOld = 0;
            this.nombreProducto = "";
        }
        public ListaProducto()
        {
            var _restIngresos = new ApiRest.IngresosRest();

            //var lstProductos = _restIngresos.ListarProductos(isapre);
            //LstProductos = new SelectList(lstProductos, "codigoProducto", "nombreProducto");

            lstProducto.Add(new SelectListItem() { Text = "Seleccione el producto", Value = "0" });
            LstProductos = new SelectList(lstProducto, "Value", "Text");

            lstIsapre.Add(new SelectListItem() { Text = "Banmédica", Value = "B" });
            lstIsapre.Add(new SelectListItem() { Text = "Vida Tres", Value = "T" });

            LstIsapres = new SelectList(lstIsapre, "Value", "Text");

        }
    }
}