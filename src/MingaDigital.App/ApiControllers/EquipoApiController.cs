using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.ApiModels;

namespace MingaDigital.App.ApiControllers
{
    [Route("api/equipo")]
    public class EquipoApiController
    {
        [FromServices]
        public MainContext Db { get; set; }

        [HttpGet("name-search")]
        public IEnumerable<NameSearchApiModel<Int32>> NameSearch(String term)
        {
            var query =
                Db.Equipo
                .Where(x => x.Detalle.ToLower().Contains(term.ToLower()))
                .Select(x => new NameSearchApiModel<Int32>
                {
                    Key = x.ActivoMingaId,
                    Value = x.Detalle
                });

            var result = query.ToArray();

            return result;
        }
    }
}
