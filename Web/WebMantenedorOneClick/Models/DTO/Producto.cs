using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMantenedorOneClick.Models.DTO
{
    public class Producto
    {
        public int rutAfiliado { get; set; }
        public string nombreAfiliado { get; set; }
        public string isapreAfiliado { get; set; }
        public int codigoProducto { get; set; }
        public string estado { get; set; }
        public int folio { get; set; }
        public string fechaCompra { get; set; }
        public int cargas { get; set; }
        public int visualizaciones { get; set; }
        public SelectList LstProductos { get; set; }
        public string nombreProducto { get; set; }

        

        
    }
}