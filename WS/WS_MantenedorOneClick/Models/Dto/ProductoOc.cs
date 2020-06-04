using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WS_MantenedorOneClick.Models.Dto
{
    /// <summary>
    /// Esta clase se utiliza para la busqueda
    /// </summary>
    public class ProductoOc
    {
        #region Accesadores y Mutadores
        public int id { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public string estado { get; set; }
        public string isapre { get; set; }
        public string usuarioCreador { get; set; }
        public double valor { get; set; }
        public string beneficiario { get; set; }
        public bool validacionMensaje { get; set; }
        public string mensajeError { get; set; }

        public int confirmacion { get; set; }
        #endregion

    }
}