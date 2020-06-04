using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMantenedorOneClick.Models.DTO
{
    public class ProductoOc
    {
        #region Accesadores y Mutadores
        public int id { get; set; }
        [Required]
        public int codigo { get; set; }
        [Required]
        public string nombre { get; set; }
        public DateTime fechaInicio { get; set; }
        [Required]
        public DateTime fechaTermino { get; set; }
        public string estado { get; set; }
        [Required]
        public string isapre { get; set; }
        [Required]
        public string usuarioCreador { get; set; }
        [Required]
        public double valor { get; set; }
        public double newValor { get; set; }
        [Required]
        public string beneficiario { get; set; }

        public string codIsapre { get; set; }
        public SelectList LstIsapres { get; set; }
        public string codBeneficiario { get; set; }
        public SelectList LstBeneficiarios { get; set; }
        public string codEstado { get; set; }
        public SelectList LstEstados { get; set; }
        public bool validacionMensaje { get; set; }
        public string mensajeError { get; set; }
        public int confirmo { get; set; }
        public SelectList LstProductos { get; set; }


        #endregion

        #region Constructor
        public ProductoOc()
        {
            List<SelectListItem> lstIsapre = new List<SelectListItem>();
            List<SelectListItem> lstBeneficiario = new List<SelectListItem>();
            List<SelectListItem> lstEstados = new List<SelectListItem>();

            lstIsapre.Add(new SelectListItem() { Text = "Banmédica", Value = "B" });
            lstIsapre.Add(new SelectListItem() { Text = "Vida Tres", Value = "T" });

            lstBeneficiario.Add(new SelectListItem() { Text = "Selecciona cargas", Value = "S" });
            lstBeneficiario.Add(new SelectListItem() { Text = "Todas las cargas", Value = "N" });

            lstEstados.Add(new SelectListItem() { Text = "Vigente", Value = "V" });
            lstEstados.Add(new SelectListItem() { Text = "No vigente", Value = "E" });

            LstIsapres = new SelectList(lstIsapre, "Value", "Text");
            LstBeneficiarios = new SelectList(lstBeneficiario, "Value", "Text");
            LstEstados = new SelectList(lstEstados, "Value", "Text");

            
        }
        #endregion
    }
}