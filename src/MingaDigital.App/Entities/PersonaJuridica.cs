using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class PersonaJuridica
    {
        public Int32 PersonaJuridicaId { get; set; }
        
        [Required]
        public String Nombre { get; set; }

        public Int32 RubroId { get; set; }
        
        public Int32 TipoEmpresaId { get; set; }
        
        public Int32 EncargadoId { get; set; }
        
        [Required]
        public String Nit { get; set; }
        
        public String Direccion { get; set; }
        
        public virtual Rubro Rubro { get; set; }
        
        public virtual TipoEmpresa TipoEmpresa { get; set; }
        
        [ForeignKey(nameof(EncargadoId))]
        public virtual PersonaFisica Encargado { get; set; }
    }
}