using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MingaDigital.App.Models
{
    [Description("Equipos")]
    public class EquipoIndexModel : BasicIndexModel<EquipoIndexTableRow>
    {
    }

    public class EquipoIndexTableRow
    {
        public Int32 ActivoMingaId { get; set; }

        [Display(Name = "Detalle")]
        public String Detalle { get; set; }

        [Display(Name = "Estado")]
        public Int32 Estado { get; set; }
    }

    [Description("Equipo")]
    public class EquipoDetailModel
    {
        public Int32 ActivoMingaId { get; set; }

        [Display(Name = "Detalle")]
        public String Detalle { get; set; }

        [Display(Name = "Estado")]
        public Int32 Estado { get; set; }

    }

    [Description("Equipo")]
    public class EquipoEditorModel
    {
        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Detalle")]
        public String Detalle { get; set; }

        [Required(ErrorMessage = "{0} es un campo requerido.")]
        [Display(Name = "Estado")]
        public Int32 Estado { get; set; }
    }
}
