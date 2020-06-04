using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WS_MantenedorOneClick.Models.Contracts;
using WS_MantenedorOneClick.Models.Dto;
using WS_MantenedorOneClick.Models.Entities;

namespace WS_MantenedorOneClick.Models.Repositories
{
    public class MantenedorOcRepository : IMantenedorOcRepository
    {
        
        #region Gets
        public ICollection<Producto> obtenerProductos(int rut)
        {
            try
            {
                using (var context = new MantenedorOneClickEntities())
                {
                    var codError = new System.Data.Entity.Core.Objects.ObjectParameter("oCOD_ERROR", typeof(string));
                    var msjError = new System.Data.Entity.Core.Objects.ObjectParameter("oMSG_ERROR", typeof(string));

                    var productosEntity = context.PKG_MANTENEDOR_1CLICK_BUSCARPRODUCTOS(rut.ToString(), codError, msjError);

                    List<Producto> listProductos = new List<Producto>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in productosEntity)
                    {
                        listProductos.Add(mapper.ToDTO(item));
                    }

                    return listProductos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<ProductoOc> obtenerProductoCod(int codigo)
        {
            try
            {
                using (var context = new MantenedorOneClickEntities())
                {
                    var codError = new System.Data.Entity.Core.Objects.ObjectParameter("oCOD_ERROR", typeof(string));
                    var msjError = new System.Data.Entity.Core.Objects.ObjectParameter("oMSG_ERROR", typeof(string));

                    var productosEntity = context.PKG_MANTENEDOR_1CLICK_BUSCARPRODUCTOCOD(codigo, codError, msjError);

                    List<ProductoOc> listProductos = new List<ProductoOc>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in productosEntity)
                    {
                        listProductos.Add(mapper.ToDTO(item));
                    }

                    return listProductos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<ProductoOc> listarProductos(string isapre)
        {
            try
            {
                using (var context = new MantenedorOneClickEntities())
                {
                    var codError = new System.Data.Entity.Core.Objects.ObjectParameter("oCOD_ERROR", typeof(string));
                    var msjError = new System.Data.Entity.Core.Objects.ObjectParameter("oMSG_ERROR", typeof(string));

                    var productosEntity = context.PKG_MANTENEDOR_1CLICK_LISTARPRODUCTOS(isapre, codError, msjError);

                    List<ProductoOc> listProductos = new List<ProductoOc>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in productosEntity)
                    {
                        listProductos.Add(mapper.ToDTO(item));
                    }

                    return listProductos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region Posts
        public bool activarEstado(int rut, int codproducto)
        {
            try
            {
                using (var context = new MantenedorOneClickEntities())
                {
                    var codError = new System.Data.Entity.Core.Objects.ObjectParameter("oCOD_ERROR", typeof(string));
                    var msjError = new System.Data.Entity.Core.Objects.ObjectParameter("oMSG_ERROR", typeof(string));

                    var apEntity = context.PKG_MANTENEDOR_1CLICK_ACTIVARESTADO(rut.ToString(), codproducto, codError, msjError);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ProductoOc agregarProducto(int codproducto, string nombre, DateTime fechaInicio, string isapre, string usuarioCreador, double valor, string beneficiario)
        {
            try
            {
                using (var context = new MantenedorOneClickEntities())
                {
                    var aux_fechaInicio = fechaInicio.ToShortDateString();
                    var codError = new System.Data.Entity.Core.Objects.ObjectParameter("oCOD_ERROR", typeof(string));
                    var msjError = new System.Data.Entity.Core.Objects.ObjectParameter("oMSG_ERROR", typeof(string));

                    var apEntity = context.PKG_MANTENEDOR_1CLICK_AGREGARPRODUCTO(codproducto, nombre, Convert.ToDateTime(aux_fechaInicio), isapre, usuarioCreador, Convert.ToDecimal(valor), beneficiario, codError, msjError);

                    if (string.IsNullOrEmpty(msjError.Value.ToString()))
                    {
                        ProductoOc p = new ProductoOc();
                        p.mensajeError = msjError.Value.ToString();
                        p.validacionMensaje = true;
                        return p;

                        //return true;
                    }
                    else
                    {
                        ProductoOc p = new ProductoOc();
                        p.mensajeError = msjError.Value.ToString();
                        p.validacionMensaje = false;
                        return p;

                        //return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool editarProducto(int codproducto, string isapre, string nombre, string estado, double valor, string beneficiario, int confirmacion)
        {
            try
            {
                using (var context = new MantenedorOneClickEntities())
                {
                    var codError = new System.Data.Entity.Core.Objects.ObjectParameter("oCOD_ERROR", typeof(string));
                    var msjError = new System.Data.Entity.Core.Objects.ObjectParameter("oMSG_ERROR", typeof(string));

                    var apEntity = context.PKG_MANTENEDOR_1CLICK_EDITARPRODUCTO(codproducto, isapre, nombre, estado, Convert.ToDecimal(valor), beneficiario, confirmacion, codError, msjError);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public bool terminarVigencia(int codproducto, string isapre)
        {
            try
            {
                using (var context = new MantenedorOneClickEntities())
                {
                    var codError = new System.Data.Entity.Core.Objects.ObjectParameter("oCOD_ERROR", typeof(string));
                    var msjError = new System.Data.Entity.Core.Objects.ObjectParameter("oMSG_ERROR", typeof(string));

                    var apEntity = context.PKG_MANTENEDOR_1CLICK_TERMINARVIGENCIA(codproducto, isapre, codError, msjError);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ProductoOc cambiarProducto(int codprodold, int codprodnew, string isapre)
        {
            try
            {
                using (var context = new MantenedorOneClickEntities())
                {
                    var codError = new System.Data.Entity.Core.Objects.ObjectParameter("oCOD_ERROR", typeof(string));
                    var msjError = new System.Data.Entity.Core.Objects.ObjectParameter("oMSG_ERROR", typeof(string));

                    var apEntity = context.PKG_MANTENEDOR_1CLICK_CAMBIARPRODUCTO(codprodold, codprodnew, isapre, codError, msjError);

                    if (string.IsNullOrEmpty(msjError.Value.ToString()))
                    {
                        ProductoOc p = new ProductoOc();
                        p.mensajeError = msjError.Value.ToString();
                        p.validacionMensaje = true;
                        return p;

                        //return true;
                    }
                    else
                    {
                        ProductoOc p = new ProductoOc();
                        p.mensajeError = msjError.Value.ToString();
                        p.validacionMensaje = false;
                        return p;

                        //return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        #endregion
    }
}