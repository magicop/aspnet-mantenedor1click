using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_MantenedorOneClick.Models.Entities;

namespace WS_MantenedorOneClick.Models.Dto
{
    public class MapperEntityToDTO
    {
        public Producto ToDTO(BuscarProductoEntity entity)
        {
            Producto pr = new Producto();

            pr.rutAfiliado = Convert.ToInt32(entity.RUTAFILIADO);
            pr.nombreAfiliado = entity.NOMBREAFILIADO;
            pr.isapreAfiliado = entity.ISAPRE;
            pr.codigoProducto = Convert.ToInt32(entity.CODIGOPRODUCTO);
            pr.estado = entity.ESTADO;
            pr.folio = Convert.ToInt32(entity.FOLIO);
            pr.fechaCompra = entity.FECHACOMPRA.ToString();
            pr.cargas = Convert.ToInt32(entity.CARGAS);
            pr.visualizaciones = Convert.ToInt32(entity.VISUALIZACIONES);

            return pr;

        }

        public ProductoOc ToDTO(BuscarProductoCodEntity entity)
        {
            ProductoOc pr = new ProductoOc();

            pr.id = Convert.ToInt32(entity.IDPRODUCTO);
            pr.codigo = Convert.ToInt32(entity.CODPRODUCTO);
            pr.nombre = entity.NOMBREPRODUCTO;
            pr.fechaInicio = entity.FECHAINICIO;
            pr.fechaTermino = Convert.ToDateTime(entity.FECHATERMINO);
            pr.estado = entity.ESTADO;
            pr.isapre = entity.ISAPRE;
            pr.valor = Convert.ToDouble(entity.VALOR);
            pr.usuarioCreador = entity.USUARIOCREADOR;
            pr.beneficiario = entity.BENEFICIARIO;

            return pr;

        }

        public ProductoOc ToDTO(ListarProductoEntity entity)
        {
            ProductoOc pr = new ProductoOc();

            pr.codigo = Convert.ToInt32(entity.CODIGOPRODUCTO);
            pr.nombre = entity.NOMBREPRODUCTO;

            return pr;

        }
    }
}