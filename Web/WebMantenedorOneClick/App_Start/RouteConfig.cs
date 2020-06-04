using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebMantenedorOneClick
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            #region MantenedorOc
            routes.MapRoute(
                name: "FormBuscarProducto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MantenedorOc", action = "FormBuscar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BuscarProducto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MantenedorOc", action = "Buscar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ActivarProducto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MantenedorOc", action = "ActivarEstado", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "FormCambiarProducto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MantenedorOc", action = "FormCambiarProd", id = UrlParameter.Optional }
            );
            #endregion

            #region Producto
            routes.MapRoute(
                name: "FormBuscarProductoOc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "FormBuscar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BuscarProductoOc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "Buscar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "FormAgregarProductoOc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "FormAgregar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AgregarProductoOc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "Agregar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "FormEditarProductoOc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "FormEditar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditarProductoOc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "Editar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TerminarVigenciaProductoOc",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "TerminarVigencia", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Error",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "Error", id = UrlParameter.Optional }
            );

            #endregion
        }
    }
}
