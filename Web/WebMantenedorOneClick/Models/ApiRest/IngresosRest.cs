using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using WebMantenedorOneClick.Models.DTO;

namespace WebMantenedorOneClick.Models.ApiRest
{
    public class IngresosRest
    {
        #region Variables y Constructor
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string urlrest { get; set; }

        // Pasa las credenciales para poder conectarse al sistema
        public IngresosRest()
        {
            urlrest = Convert.ToString(ConfigurationManager.AppSettings["RestApiIngresos"]);
            usuario = Convert.ToString(ConfigurationManager.AppSettings["UserIngresos"]);
            contrasena = Convert.ToString(ConfigurationManager.AppSettings["ContrasenaIngresos"]);
        }
        #endregion

        #region Gets
        public List<Producto> GetProducto(int rut)
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetProductos/{0}/", rut);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var productoList = new List<Producto>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new Producto();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice
                    pr.rutAfiliado = stuff[i]["rutAfiliado"] != null ? Convert.ToInt32(stuff[i]["rutAfiliado"].ToString()) : 0;
                    pr.nombreAfiliado = stuff[i]["nombreAfiliado"] != null ? stuff[i]["nombreAfiliado"].ToString() : string.Empty;
                    pr.isapreAfiliado = stuff[i]["isapreAfiliado"] != null ? stuff[i]["isapreAfiliado"].ToString() : string.Empty;
                    pr.codigoProducto = stuff[i]["codigoProducto"] != null ? Convert.ToInt32(stuff[i]["codigoProducto"].ToString()) : 0;
                    pr.estado = stuff[i]["estado"] != null ? stuff[i]["estado"].ToString() : string.Empty;
                    pr.folio = stuff[i]["folio"] != null ? Convert.ToInt32(stuff[i]["folio"].ToString()) : 0;
                    pr.fechaCompra = stuff[i]["fechaCompra"] != null ? stuff[i]["fechaCompra"].ToString() : string.Empty;
                    pr.cargas = stuff[i]["cargas"] != null ? Convert.ToInt32(stuff[i]["cargas"].ToString()) : 0;
                    pr.visualizaciones = stuff[i]["visualizaciones"] != null ? Convert.ToInt32(stuff[i]["visualizaciones"].ToString()) : 0;
                    
                    productoList.Add(pr);
                }
            }

            return productoList;
        }

        public List<ProductoOc> GetProductoCod(int codigo)
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetProductoCod/{0}/", codigo);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var productoList = new List<ProductoOc>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new ProductoOc();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice

                    pr.id = stuff[i]["id"] != null ? Convert.ToInt32(stuff[i]["id"].ToString()) : 0;
                    pr.codigo = stuff[i]["codigo"] != null ? Convert.ToInt32(stuff[i]["codigo"].ToString()) : 0;
                    pr.nombre = stuff[i]["nombre"] != null ? stuff[i]["nombre"].ToString() : string.Empty;
                    pr.fechaInicio = stuff[i]["fechaInicio"] != null ? Convert.ToDateTime(stuff[i]["fechaInicio"].ToString()) : DateTime.Now;
                    pr.fechaTermino = stuff[i]["fechaTermino"] != null ? Convert.ToDateTime(stuff[i]["fechaTermino"].ToString()) : DateTime.Now;
                    pr.estado = stuff[i]["estado"] != null ? stuff[i]["estado"].ToString() : string.Empty;
                    pr.isapre = stuff[i]["isapre"] != null ? stuff[i]["isapre"].ToString() : string.Empty;
                    pr.usuarioCreador = stuff[i]["usuarioCreador"] != null ? stuff[i]["usuarioCreador"].ToString() : string.Empty;
                    pr.valor = stuff[i]["valor"] != null ? Convert.ToDouble(stuff[i]["valor"].ToString()) : 0;
                    pr.beneficiario = stuff[i]["beneficiario"] != null ? stuff[i]["beneficiario"].ToString() : string.Empty;
                    
                    productoList.Add(pr);
                }
            }

            return productoList;
        }

        public List<ListaProducto> ListarProductos(string isapre)
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/ListarProductos/{0}", isapre);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var productoList = new List<ListaProducto>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new ListaProducto(1);

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice

                    pr.codigoProducto = stuff[i]["codigo"] != null ? Convert.ToInt32(stuff[i]["codigo"].ToString()) : 0;
                    pr.nombreProducto = stuff[i]["nombre"] != null ? stuff[i]["nombre"].ToString() : string.Empty;

                    productoList.Add(pr);
                }
            }

            return productoList;
        }
        #endregion

        #region Posts

        public bool PostActivarEstado(int rut, int codproducto)
        {
            var parametros = string.Format("/PostActivarEstado/{0}/{1}", rut, codproducto);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        public ProductoOc PostAgregarProducto(int codproducto, string nombre, DateTime fechaInicio, string isapre, string usuarioCreador, double valor, string beneficiario)
        {
            var aux_fecha = fechaInicio.ToShortDateString();
            string specifier = "G";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("eu-ES");
            var aux_valor = valor.ToString(specifier, CultureInfo.InvariantCulture);

            var parametros = string.Format("/PostAgregarProducto/{0}/{1}/{2}/{3}/{4}/{5}/{6}", codproducto, nombre, aux_fecha, isapre, usuarioCreador, aux_valor, beneficiario);
            JObject stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            ProductoOc pr = new ProductoOc();

            if (stuff.Count > 0)
            {
                pr.mensajeError = stuff["mensajeError"] != null ? stuff["mensajeError"].ToString() : string.Empty;
                pr.validacionMensaje = (bool)stuff["validacionMensaje"];

            }
                

            return pr;
        }

        public bool PostEditarProducto(int codproducto, string isapre, string nombre, string estado, double valor, string beneficiario, int confirmacion)
        {
            string specifier = "G";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("eu-ES");
            var aux_valor = valor.ToString(specifier, CultureInfo.InvariantCulture);

            var parametros = string.Format("/PostEditarProducto/{0}/{1}/{2}/{3}/{4}/{5}/{6}", codproducto, isapre, nombre, estado, aux_valor, beneficiario, confirmacion);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        public bool PostTerminarVigencia(int codproducto, string isapre)
        {
            var parametros = string.Format("/PostTerminarVigencia/{0}/{1}/", codproducto, isapre);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        public ProductoOc PostCambiarProducto(int codprodold, int codprodnew, string isapre)
        {

            var parametros = string.Format("/PostCambiarProducto/{0}/{1}/{2}/", codprodold, codprodnew, isapre);
            JObject stuff = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            ProductoOc pr = new ProductoOc();

            if (stuff.Count > 0)
            {
                pr.mensajeError = stuff["mensajeError"] != null ? stuff["mensajeError"].ToString() : string.Empty;
                pr.validacionMensaje = (bool)stuff["validacionMensaje"];

            }


            return pr;
        }
        #endregion
    }
}