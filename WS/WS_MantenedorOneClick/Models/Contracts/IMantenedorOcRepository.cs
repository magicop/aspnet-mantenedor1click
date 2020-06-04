using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WS_MantenedorOneClick.Models.Dto;

namespace WS_MantenedorOneClick.Models.Contracts
{
    public interface IMantenedorOcRepository
    {
        ICollection<Producto> obtenerProductos(int rut);
        ICollection<ProductoOc> obtenerProductoCod(int codigo);
        ICollection<ProductoOc> listarProductos(string isapre);
        bool activarEstado(int rut, int codproducto);
        ProductoOc agregarProducto(int codproducto, string nombre, DateTime fechaInicio, string isapre, string usuarioCreador, double valor, string beneficiario);
        bool editarProducto(int codproducto, string isapre, string nombre, string estado, double valor, string beneficiario, int confirmacion);
        bool terminarVigencia(int codproducto, string isapre);

        ProductoOc cambiarProducto(int codprodold, int codprodnew, string isapre);


    }
}