using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    public class PersonaJuridicaIndexModel
    {
        public PersonaJuridicaIndexTable Table { get; set; }
    }
    
    public class PersonaJuridicaIndexTable : BasicTable<PersonaJuridicaIndexTableRow>
    {
    }
    
    public class PersonaJuridicaIndexTableRow
    {
        public Int32 PersonaJuridicaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Persona Jurídica")]
    public class PersonaJuridicaDetailModel
    {
        public Int32 PersonaJuridicaId { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
    
    [Description("Persona Jurídica")]
    public class PersonaJuridicaEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }
    }
}