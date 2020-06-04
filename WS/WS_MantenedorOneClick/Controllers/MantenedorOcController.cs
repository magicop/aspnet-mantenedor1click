using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WS_MantenedorOneClick.Models.Contracts;

namespace WS_MantenedorOneClick.Controllers
{
    public class MantenedorOcController : ApiController
    {
        private IMantenedorOcRepository _mwRepository;

        public MantenedorOcController(IMantenedorOcRepository mwRepository)
        {
            this._mwRepository = mwRepository;
        }

        #region Gets
        [HttpGet]
        [Route("api/GetProductoCod/{codigo}")]
        public IHttpActionResult GetProductoCod(int codigo)
        {
            try
            {

                var productos = _mwRepository.obtenerProductoCod(codigo);

                if (productos != null)
                {
                    return Ok(productos);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/ListarProductos/{isapre}")]
        public IHttpActionResult ListarProductos(string isapre)
        {
            try
            {

                var productos = _mwRepository.listarProductos(isapre);

                if (productos != null)
                {
                    return Ok(productos);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion

        #region Posts
        [HttpGet]
        [Route("api/GetProductos/{rut}")]
        public IHttpActionResult GetProductos(int rut)
        {
            try
            {

                var productos = _mwRepository.obtenerProductos(rut);

                if (productos != null)
                {
                    return Ok(productos);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/PostActivarEstado/{rut}/{codProducto}")]
        public IHttpActionResult PostActivarEstado(int rut, int codProducto)
        {
            try
            {
                var estado = _mwRepository.activarEstado(rut, codProducto);

                if (estado == true)
                {
                    return Ok(estado);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/PostAgregarProducto/{codproducto}/{nombre}/{fechaInicio}/{isapre}/{usuarioCreador}/{valor}/{beneficiario}")]
        public IHttpActionResult PostAgregarProducto(int codproducto, string nombre, DateTime fechaInicio, string isapre, string usuarioCreador, double valor, string beneficiario)
        {
            try
            {
                var estado = _mwRepository.agregarProducto(codproducto, nombre, fechaInicio, isapre, usuarioCreador, valor, beneficiario);

                //if (estado.validacionMensaje == true)
                //{
                //    return Ok(estado);
                //}
                //else
                //{
                //    return Ok(estado.mensajeError);
                //}
                 return Ok(estado);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/PostEditarProducto/{codproducto}/{isapre}/{nombre}/{estado}/{valor}/{beneficiario}/{confirmacion}")]
        public IHttpActionResult PostEditarProducto(int codproducto, string isapre, string nombre, string estado, double valor, string beneficiario, int confirmacion)
        {
            try
            {
                var editar = _mwRepository.editarProducto(codproducto, isapre, nombre, estado, valor, beneficiario, confirmacion);

                if (editar == true)
                {
                    return Ok(editar);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [HttpPost]
        [Route("api/PostTerminarVigencia/{codproducto}/{isapre}/")]
        public IHttpActionResult PostTerminarVigencia(int codproducto, string isapre)
        {
            try
            {
                var editar = _mwRepository.terminarVigencia(codproducto, isapre);

                if (editar == true)
                {
                    return Ok(editar);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/PostCambiarProducto/{codprodold}/{codprodnew}/{isapre}")]
        public IHttpActionResult PostCambiarProducto(int codprodold, int codprodnew, string isapre)
        {
            try
            {
                var editar = _mwRepository.cambiarProducto(codprodold, codprodnew, isapre);

                //if (editar == true)
                //{
                //    return Ok(editar);
                //}
                //return NotFound();

                return Ok(editar);

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion
    }
}