using Microsoft.EntityFrameworkCore;
using proyecto.Accesos;
using proyecto.Alertas;
using proyecto.Busquedas;
using proyecto.Errores;
using proyecto.ListaNoticias;
using proyecto.noticias;
using proyecto.Notificaciones;
using proyecto.Usuarios;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace proyecto.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class proyectoDbContext :
    AbpDbContext<proyectoDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    /* Entidades de dominio */
    public DbSet<Noticia> Noticias { get; set; }
    public DbSet<Alerta> Alertas { get; set; }
    public DbSet<ListaNoticia> ListaNoticias { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }
    public DbSet<Error> Errores { get; set; }
    public DbSet<Busqueda> Busquedas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Acceso> Accesos { get; set; }

    
    public proyectoDbContext(DbContextOptions<proyectoDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(proyectoConsts.DbTablePrefix + "YourEntities", proyectoConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        #region Noticia

        // Builder Clase Noticia
        builder.Entity<Noticia>(b =>
        {
            b.ToTable("Noticias", proyectoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.fecha).IsRequired();
            b.Property(x => x.titulo).IsRequired().HasMaxLength(128);
            b.Property(x => x.autor).IsRequired().HasMaxLength(128);
            b.Property(x => x.descripcion).IsRequired().HasMaxLength(128);
            b.Property(x => x.url).IsRequired().HasMaxLength(128);
            b.Property(x => x.urlImagen).IsRequired().HasMaxLength(128);
            b.Property(x => x.Contenido).IsRequired().HasMaxLength(128);
            b.Property(x => x.tema).IsRequired().HasMaxLength(128);
            
        });

        #endregion

        #region Error

        builder.Entity<Error>(b =>
        {
            b.ToTable("Errores", proyectoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.descripcion).IsRequired().HasMaxLength(128);
        });

        builder.Entity<Error>()
            .HasOne<Acceso>(s => s.Acceso)
            .WithMany(g => g.Errores)
            .HasForeignKey(s => s.AccesoId);

        #endregion

        #region Acceso

        builder.Entity<Acceso>(b =>
        {
            b.ToTable("Accesos", proyectoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.fecha).IsRequired();
            b.Property(x => x.horaInicio).IsRequired();
            b.Property(x => x.horaFin).IsRequired();
        });

        builder.Entity<Acceso>()
            .HasOne<Usuario>(s => s.Usuario)
            .WithMany(g => g.Accesos)
            .HasForeignKey(s => s.UsuarioId);

        #endregion

        #region Usuario

        builder.Entity<Usuario>(b =>
        {
            b.ToTable("Usuario", proyectoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.nombre).IsRequired().HasMaxLength(128);
            b.Property(x => x.apellido).IsRequired().HasMaxLength(128);
            b.Property(x => x.mail).IsRequired().HasMaxLength(128);
        });

        #endregion

        #region Busqueda

        builder.Entity<Busqueda>(b =>
        {
            b.ToTable("Busquedas", proyectoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.parametro).IsRequired().HasMaxLength(128);
        });

        builder.Entity<Busqueda>()
            .HasOne<Usuario>(s => s.Usuario)
            .WithMany(g => g.Busquedas)
            .HasForeignKey(s => s.UsuarioId);

        #endregion
        



        #region Alerta

        builder.Entity<Alerta>(b =>
        {
            b.ToTable("Alertas", proyectoConsts.DbSchema);
            b.ConfigureByConvention(); 
            b.Property(x => x.fecha).IsRequired();
            b.Property(x => x.descripcion).IsRequired().HasMaxLength(128);
        });

        builder.Entity<Alerta>()
            .HasOne<ListaNoticia>(s => s.ListaNoticia)
            .WithMany(g => g.Alertas)
            .HasForeignKey(s => s.ListaNoticiaId);

        #endregion
        
        
        #region ListaNoticia

        // Builder Clase ListaNoticia
        builder.Entity<ListaNoticia>(b =>
        {
            b.ToTable("ListaNoticias", proyectoConsts.DbSchema);
            b.ConfigureByConvention(); 
            b.Property(x => x.nombreLista).IsRequired().HasMaxLength(128);
            
        });
        

        #endregion

        #region Notificacion

        //Builder clase Notificacion
        builder.Entity<Notificacion>(b =>
        {
            b.ToTable("Notificaciones", proyectoConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.descripcion).IsRequired().HasMaxLength(128);
            b.Property(x => x.link).IsRequired().HasMaxLength(128);
            b.Property(x => x.fecha).IsRequired();
        });

        builder.Entity<Notificacion>()
            .HasOne<Alerta>(s => s.Alerta)
            .WithMany(g => g.Notificaciones)
            .HasForeignKey(s => s.AlertaId);

        builder.Entity<Notificacion>()
            .HasOne<Usuario>(s => s.Usuario)
            .WithMany(g => g.Notificaciones)
            .HasForeignKey(s => s.UsuarioId);

        #endregion
        
    }
}
