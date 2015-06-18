using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;

namespace MingaDigital.App.Controllers
{
    [Route("equipos")]
    public class EquipoController
        : BasicCrudController<
            MainContext,
            Equipo,
            EquipoIndexModel,
            EquipoIndexTableRow,
            EquipoDetailModel,
            EquipoEditorModel
        >
    {
        protected override IEnumerable<EquipoIndexTableRow> GetIndexRows(EquipoIndexModel model)
        {
            var query =
                Db.Equipo
                .Select(x => new EquipoIndexTableRow
                {
                    ActivoMingaId = x.ActivoMingaId,
                    Detalle = x.Detalle,
                    Estado = (int)x.Estado
                });

            var result = query.ToArray();

            return result;
        }

        protected override EquipoDetailModel EntityToDetailModel(Equipo entity)
        {
            return new EquipoDetailModel
            {
                ActivoMingaId = entity.ActivoMingaId,
                Detalle = entity.Detalle,
                Estado = (int) entity.Estado
            };
        }

        protected override EquipoEditorModel GetInitialEditorModel()
        {
            return new EquipoEditorModel();
        }

        protected override EquipoEditorModel EntityToEditorModel(Equipo entity)
        {
            return new EquipoEditorModel
            {
                Detalle = entity.Detalle,
                Estado = (int)entity.Estado
            };
        }

        protected override Equipo EditorModelToEntity(EquipoEditorModel model)
        {
            var entity = new Equipo();
            ApplyEditorModel(model, entity);
            return entity;
        }

        protected override void ApplyEditorModel(EquipoEditorModel model, Equipo entity)
        {
            entity.Detalle = model.Detalle;
            entity.Estado = (EstadoEquipo)model.Estado;
        }
    }
}
