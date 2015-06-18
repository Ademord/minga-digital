namespace MingaDigital.App.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.accion",
                c => new
                    {
                        accion_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.accion_id);
            
            CreateTable(
                "public.actividad",
                c => new
                    {
                        actividad_id = c.Int(nullable: false, identity: true),
                        titulo = c.String(nullable: false),
                        descripcion = c.String(),
                        tiempo_inicio = c.DateTimeOffset(nullable: false, precision: 7),
                        tiempo_fin = c.DateTimeOffset(nullable: false, precision: 7),
                        realizado = c.Boolean(nullable: false),
                        tipo_actividad_id = c.Int(nullable: false),
                        usuario_creador_id = c.Int(nullable: false),
                        persona_encargada_id = c.Int(nullable: false),
                        telecentro_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.actividad_id)
                .ForeignKey("public.persona_fisica", t => t.persona_encargada_id, cascadeDelete: true)
                .ForeignKey("public.telecentro", t => t.telecentro_id)
                .ForeignKey("public.tipo_actividad", t => t.tipo_actividad_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_creador_id, cascadeDelete: true)
                .Index(t => t.tipo_actividad_id)
                .Index(t => t.usuario_creador_id)
                .Index(t => t.persona_encargada_id)
                .Index(t => t.telecentro_id);
            
            CreateTable(
                "public.persona_fisica",
                c => new
                    {
                        persona_fisica_id = c.Int(nullable: false, identity: true),
                        nombres = c.String(nullable: false),
                        apellidos = c.String(nullable: false),
                        nit = c.String(),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.persona_fisica_id);
            
            CreateTable(
                "public.usuario",
                c => new
                    {
                        usuario_id = c.Int(nullable: false),
                        username = c.String(nullable: false),
                        password_hash = c.Binary(nullable: false),
                        password_salt = c.Binary(nullable: false),
                        password_algorithm = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.usuario_id)
                .ForeignKey("public.persona_fisica", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.usuario_id)
                .Index(t => t.username, unique: true);
            
            CreateTable(
                "public.permiso_global",
                c => new
                    {
                        accion_id = c.String(nullable: false, maxLength: 128),
                        usuario_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.accion_id, t.usuario_id })
                .ForeignKey("public.accion", t => t.accion_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.accion_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "public.establecimiento_minga",
                c => new
                    {
                        establecimiento_minga_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        ubicacion_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.establecimiento_minga_id)
                .ForeignKey("public.ubicacion", t => t.ubicacion_id, cascadeDelete: true)
                .Index(t => t.nombre, unique: true)
                .Index(t => t.ubicacion_id);
            
            CreateTable(
                "public.persona_juridica",
                c => new
                    {
                        persona_juridica_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        rubro_id = c.Int(nullable: false),
                        tipo_empresa_id = c.Int(nullable: false),
                        encargado_id = c.Int(nullable: false),
                        nit = c.String(nullable: false),
                        direccion = c.String(),
                    })
                .PrimaryKey(t => t.persona_juridica_id)
                .ForeignKey("public.persona_fisica", t => t.encargado_id, cascadeDelete: true)
                .ForeignKey("public.rubro", t => t.rubro_id, cascadeDelete: true)
                .ForeignKey("public.tipo_empresa", t => t.tipo_empresa_id, cascadeDelete: true)
                .Index(t => t.rubro_id)
                .Index(t => t.tipo_empresa_id)
                .Index(t => t.encargado_id);
            
            CreateTable(
                "public.rubro",
                c => new
                    {
                        rubro_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.rubro_id);
            
            CreateTable(
                "public.tipo_empresa",
                c => new
                    {
                        tipo_empresa_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.tipo_empresa_id);
            
            CreateTable(
                "public.ubicacion",
                c => new
                    {
                        ubicacion_id = c.Int(nullable: false, identity: true),
                        municipio_id = c.Int(nullable: false),
                        distrito = c.Int(nullable: false),
                        unidad_vecinal = c.Int(nullable: false),
                        direccion = c.String(),
                        geo_coordenada_latitud = c.Decimal(nullable: false, precision: 18, scale: 2),
                        geo_coordenada_longitud = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ubicacion_id)
                .ForeignKey("public.municipio", t => t.municipio_id, cascadeDelete: true)
                .Index(t => t.municipio_id);
            
            CreateTable(
                "public.municipio",
                c => new
                    {
                        municipio_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.municipio_id)
                .Index(t => t.nombre, unique: true);
            
            CreateTable(
                "public.unidad_educativa",
                c => new
                    {
                        unidad_educativa_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        ubicacion_id = c.Int(nullable: false),
                        telecentro_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.unidad_educativa_id)
                .ForeignKey("public.telecentro", t => t.telecentro_id)
                .ForeignKey("public.ubicacion", t => t.ubicacion_id, cascadeDelete: true)
                .Index(t => t.ubicacion_id)
                .Index(t => t.telecentro_id);
            
            CreateTable(
                "public.ctel",
                c => new
                    {
                        ctel_id = c.Int(nullable: false),
                        unidad_educativa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ctel_id)
                .ForeignKey("public.unidad_educativa", t => t.ctel_id, cascadeDelete: true)
                .Index(t => t.ctel_id)
                .Index(t => t.unidad_educativa_id, unique: true);
            
            CreateTable(
                "public.tipo_actividad",
                c => new
                    {
                        tipo_actividad_id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.tipo_actividad_id);
            
            CreateTable(
                "public.activo_minga",
                c => new
                    {
                        activo_minga_id = c.Int(nullable: false, identity: true),
                        establecimiento_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.activo_minga_id)
                .ForeignKey("public.establecimiento_minga", t => t.establecimiento_id, cascadeDelete: true)
                .Index(t => t.establecimiento_id);
            
            CreateTable(
                "public.tipo_componente",
                c => new
                    {
                        tipo_componente_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.tipo_componente_id)
                .Index(t => t.nombre, unique: true);
            
            CreateTable(
                "public.item_movimiento",
                c => new
                    {
                        movimiento_id = c.Int(nullable: false),
                        activo_minga_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.movimiento_id, t.activo_minga_id })
                .ForeignKey("public.activo_minga", t => t.activo_minga_id, cascadeDelete: true)
                .ForeignKey("public.movimiento", t => t.movimiento_id, cascadeDelete: true)
                .Index(t => t.movimiento_id)
                .Index(t => t.activo_minga_id);
            
            CreateTable(
                "public.movimiento",
                c => new
                    {
                        movimiento_id = c.Int(nullable: false, identity: true),
                        origen_id = c.Int(nullable: false),
                        destino_id = c.Int(nullable: false),
                        fecha_hora = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.movimiento_id)
                .ForeignKey("public.establecimiento_minga", t => t.destino_id, cascadeDelete: true)
                .ForeignKey("public.establecimiento_minga", t => t.origen_id, cascadeDelete: true)
                .Index(t => t.origen_id)
                .Index(t => t.destino_id);
            
            CreateTable(
                "public.permiso_rol",
                c => new
                    {
                        accion_id = c.String(nullable: false, maxLength: 128),
                        rol_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.accion_id, t.rol_id })
                .ForeignKey("public.accion", t => t.accion_id, cascadeDelete: true)
                .ForeignKey("public.rol", t => t.rol_id, cascadeDelete: true)
                .Index(t => t.accion_id)
                .Index(t => t.rol_id);
            
            CreateTable(
                "public.rol",
                c => new
                    {
                        rol_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.rol_id)
                .Index(t => t.nombre, unique: true);
            
            CreateTable(
                "public.persona_fisica_ctel",
                c => new
                    {
                        persona_fisica_id = c.Int(nullable: false),
                        ctel_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.persona_fisica_id, t.ctel_id })
                .ForeignKey("public.ctel", t => t.ctel_id, cascadeDelete: true)
                .ForeignKey("public.persona_fisica", t => t.persona_fisica_id, cascadeDelete: true)
                .Index(t => t.persona_fisica_id)
                .Index(t => t.ctel_id);
            
            CreateTable(
                "public.sesion_usuario",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        usuario_id = c.Int(nullable: false),
                        fecha_hora_creacion = c.DateTimeOffset(nullable: false, precision: 7),
                        fecha_hora_expiracion = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "public.ticket",
                c => new
                    {
                        ticket_id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false),
                        prioridad = c.Int(nullable: false),
                        estado_ticket = c.Int(nullable: false),
                        fecha_hora_creado = c.DateTimeOffset(nullable: false, precision: 7),
                        fecha_hora_atendido = c.DateTimeOffset(precision: 7),
                        fecha_hora_cerrado = c.DateTimeOffset(precision: 7),
                        tipo_incidencia_id = c.Int(nullable: false),
                        telecentro_id = c.Int(nullable: false),
                        equipo_id = c.Int(nullable: false),
                        usuario_id = c.Int(nullable: false),
                        encargado_id = c.Int(),
                    })
                .PrimaryKey(t => t.ticket_id)
                .ForeignKey("public.usuario", t => t.encargado_id)
                .ForeignKey("public.equipo", t => t.equipo_id)
                .ForeignKey("public.telecentro", t => t.telecentro_id)
                .ForeignKey("public.tipo_incidencia", t => t.tipo_incidencia_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.tipo_incidencia_id)
                .Index(t => t.telecentro_id)
                .Index(t => t.equipo_id)
                .Index(t => t.usuario_id)
                .Index(t => t.encargado_id);
            
            CreateTable(
                "public.tipo_incidencia",
                c => new
                    {
                        tipo_incidencia_id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.tipo_incidencia_id)
                .Index(t => t.nombre, unique: true);
            
            CreateTable(
                "public.usuario_rol",
                c => new
                    {
                        usuario_id = c.Int(nullable: false),
                        rol_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.usuario_id, t.rol_id })
                .ForeignKey("public.rol", t => t.rol_id, cascadeDelete: true)
                .ForeignKey("public.usuario", t => t.usuario_id, cascadeDelete: true)
                .Index(t => t.usuario_id)
                .Index(t => t.rol_id);
            
            CreateTable(
                "public.almacen",
                c => new
                    {
                        establecimiento_minga_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.establecimiento_minga_id)
                .ForeignKey("public.establecimiento_minga", t => t.establecimiento_minga_id)
                .Index(t => t.establecimiento_minga_id);
            
            CreateTable(
                "public.componente",
                c => new
                    {
                        activo_minga_id = c.Int(nullable: false),
                        tipo_componente_id = c.Int(nullable: false),
                        marca = c.String(),
                        caracteristica = c.String(),
                        equipo_id = c.Int(),
                    })
                .PrimaryKey(t => t.activo_minga_id)
                .ForeignKey("public.activo_minga", t => t.activo_minga_id)
                .ForeignKey("public.tipo_componente", t => t.tipo_componente_id, cascadeDelete: true)
                .ForeignKey("public.equipo", t => t.equipo_id)
                .Index(t => t.activo_minga_id)
                .Index(t => t.tipo_componente_id)
                .Index(t => t.equipo_id);
            
            CreateTable(
                "public.equipo",
                c => new
                    {
                        activo_minga_id = c.Int(nullable: false),
                        detalle = c.String(),
                        estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.activo_minga_id)
                .ForeignKey("public.activo_minga", t => t.activo_minga_id)
                .Index(t => t.activo_minga_id);
            
            CreateTable(
                "public.telecentro",
                c => new
                    {
                        establecimiento_minga_id = c.Int(nullable: false),
                        patrocinador_id = c.Int(),
                        proveedor_internet_id = c.Int(),
                        estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.establecimiento_minga_id)
                .ForeignKey("public.establecimiento_minga", t => t.establecimiento_minga_id)
                .ForeignKey("public.persona_juridica", t => t.patrocinador_id)
                .ForeignKey("public.persona_juridica", t => t.proveedor_internet_id)
                .Index(t => t.establecimiento_minga_id)
                .Index(t => t.patrocinador_id)
                .Index(t => t.proveedor_internet_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.telecentro", "proveedor_internet_id", "public.persona_juridica");
            DropForeignKey("public.telecentro", "patrocinador_id", "public.persona_juridica");
            DropForeignKey("public.telecentro", "establecimiento_minga_id", "public.establecimiento_minga");
            DropForeignKey("public.equipo", "activo_minga_id", "public.activo_minga");
            DropForeignKey("public.componente", "equipo_id", "public.equipo");
            DropForeignKey("public.componente", "tipo_componente_id", "public.tipo_componente");
            DropForeignKey("public.componente", "activo_minga_id", "public.activo_minga");
            DropForeignKey("public.almacen", "establecimiento_minga_id", "public.establecimiento_minga");
            DropForeignKey("public.usuario_rol", "usuario_id", "public.usuario");
            DropForeignKey("public.usuario_rol", "rol_id", "public.rol");
            DropForeignKey("public.ticket", "usuario_id", "public.usuario");
            DropForeignKey("public.ticket", "tipo_incidencia_id", "public.tipo_incidencia");
            DropForeignKey("public.ticket", "telecentro_id", "public.telecentro");
            DropForeignKey("public.ticket", "equipo_id", "public.equipo");
            DropForeignKey("public.ticket", "encargado_id", "public.usuario");
            DropForeignKey("public.sesion_usuario", "usuario_id", "public.usuario");
            DropForeignKey("public.persona_fisica_ctel", "persona_fisica_id", "public.persona_fisica");
            DropForeignKey("public.persona_fisica_ctel", "ctel_id", "public.ctel");
            DropForeignKey("public.permiso_rol", "rol_id", "public.rol");
            DropForeignKey("public.permiso_rol", "accion_id", "public.accion");
            DropForeignKey("public.item_movimiento", "movimiento_id", "public.movimiento");
            DropForeignKey("public.movimiento", "origen_id", "public.establecimiento_minga");
            DropForeignKey("public.movimiento", "destino_id", "public.establecimiento_minga");
            DropForeignKey("public.item_movimiento", "activo_minga_id", "public.activo_minga");
            DropForeignKey("public.activo_minga", "establecimiento_id", "public.establecimiento_minga");
            DropForeignKey("public.establecimiento_minga", "ubicacion_id", "public.ubicacion");
            DropForeignKey("public.actividad", "usuario_creador_id", "public.usuario");
            DropForeignKey("public.actividad", "tipo_actividad_id", "public.tipo_actividad");
            DropForeignKey("public.actividad", "telecentro_id", "public.telecentro");
            DropForeignKey("public.unidad_educativa", "ubicacion_id", "public.ubicacion");
            DropForeignKey("public.unidad_educativa", "telecentro_id", "public.telecentro");
            DropForeignKey("public.ctel", "ctel_id", "public.unidad_educativa");
            DropForeignKey("public.ubicacion", "municipio_id", "public.municipio");
            DropForeignKey("public.persona_juridica", "tipo_empresa_id", "public.tipo_empresa");
            DropForeignKey("public.persona_juridica", "rubro_id", "public.rubro");
            DropForeignKey("public.persona_juridica", "encargado_id", "public.persona_fisica");
            DropForeignKey("public.actividad", "persona_encargada_id", "public.persona_fisica");
            DropForeignKey("public.usuario", "usuario_id", "public.persona_fisica");
            DropForeignKey("public.permiso_global", "usuario_id", "public.usuario");
            DropForeignKey("public.permiso_global", "accion_id", "public.accion");
            DropIndex("public.telecentro", new[] { "proveedor_internet_id" });
            DropIndex("public.telecentro", new[] { "patrocinador_id" });
            DropIndex("public.telecentro", new[] { "establecimiento_minga_id" });
            DropIndex("public.equipo", new[] { "activo_minga_id" });
            DropIndex("public.componente", new[] { "equipo_id" });
            DropIndex("public.componente", new[] { "tipo_componente_id" });
            DropIndex("public.componente", new[] { "activo_minga_id" });
            DropIndex("public.almacen", new[] { "establecimiento_minga_id" });
            DropIndex("public.usuario_rol", new[] { "rol_id" });
            DropIndex("public.usuario_rol", new[] { "usuario_id" });
            DropIndex("public.tipo_incidencia", new[] { "nombre" });
            DropIndex("public.ticket", new[] { "encargado_id" });
            DropIndex("public.ticket", new[] { "usuario_id" });
            DropIndex("public.ticket", new[] { "equipo_id" });
            DropIndex("public.ticket", new[] { "telecentro_id" });
            DropIndex("public.ticket", new[] { "tipo_incidencia_id" });
            DropIndex("public.sesion_usuario", new[] { "usuario_id" });
            DropIndex("public.persona_fisica_ctel", new[] { "ctel_id" });
            DropIndex("public.persona_fisica_ctel", new[] { "persona_fisica_id" });
            DropIndex("public.rol", new[] { "nombre" });
            DropIndex("public.permiso_rol", new[] { "rol_id" });
            DropIndex("public.permiso_rol", new[] { "accion_id" });
            DropIndex("public.movimiento", new[] { "destino_id" });
            DropIndex("public.movimiento", new[] { "origen_id" });
            DropIndex("public.item_movimiento", new[] { "activo_minga_id" });
            DropIndex("public.item_movimiento", new[] { "movimiento_id" });
            DropIndex("public.tipo_componente", new[] { "nombre" });
            DropIndex("public.activo_minga", new[] { "establecimiento_id" });
            DropIndex("public.ctel", new[] { "unidad_educativa_id" });
            DropIndex("public.ctel", new[] { "ctel_id" });
            DropIndex("public.unidad_educativa", new[] { "telecentro_id" });
            DropIndex("public.unidad_educativa", new[] { "ubicacion_id" });
            DropIndex("public.municipio", new[] { "nombre" });
            DropIndex("public.ubicacion", new[] { "municipio_id" });
            DropIndex("public.persona_juridica", new[] { "encargado_id" });
            DropIndex("public.persona_juridica", new[] { "tipo_empresa_id" });
            DropIndex("public.persona_juridica", new[] { "rubro_id" });
            DropIndex("public.establecimiento_minga", new[] { "ubicacion_id" });
            DropIndex("public.establecimiento_minga", new[] { "nombre" });
            DropIndex("public.permiso_global", new[] { "usuario_id" });
            DropIndex("public.permiso_global", new[] { "accion_id" });
            DropIndex("public.usuario", new[] { "username" });
            DropIndex("public.usuario", new[] { "usuario_id" });
            DropIndex("public.actividad", new[] { "telecentro_id" });
            DropIndex("public.actividad", new[] { "persona_encargada_id" });
            DropIndex("public.actividad", new[] { "usuario_creador_id" });
            DropIndex("public.actividad", new[] { "tipo_actividad_id" });
            DropTable("public.telecentro");
            DropTable("public.equipo");
            DropTable("public.componente");
            DropTable("public.almacen");
            DropTable("public.usuario_rol");
            DropTable("public.tipo_incidencia");
            DropTable("public.ticket");
            DropTable("public.sesion_usuario");
            DropTable("public.persona_fisica_ctel");
            DropTable("public.rol");
            DropTable("public.permiso_rol");
            DropTable("public.movimiento");
            DropTable("public.item_movimiento");
            DropTable("public.tipo_componente");
            DropTable("public.activo_minga");
            DropTable("public.tipo_actividad");
            DropTable("public.ctel");
            DropTable("public.unidad_educativa");
            DropTable("public.municipio");
            DropTable("public.ubicacion");
            DropTable("public.tipo_empresa");
            DropTable("public.rubro");
            DropTable("public.persona_juridica");
            DropTable("public.establecimiento_minga");
            DropTable("public.permiso_global");
            DropTable("public.usuario");
            DropTable("public.persona_fisica");
            DropTable("public.actividad");
            DropTable("public.accion");
        }
    }
}
