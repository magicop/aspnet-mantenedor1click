using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_MantenedorOneClick.Models.Dto
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

    }
}