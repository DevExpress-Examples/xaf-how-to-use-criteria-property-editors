using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using HowToUseCriteriaPropertyEditors.Module;
using DevExpress.Persistent.Base;

namespace CriteriaPropertiesEF.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class CriteriaPropertiesEFContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<CriteriaPropertiesEFEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new CriteriaPropertiesEFEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class CriteriaPropertiesEFDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CriteriaPropertiesEFEFCoreDbContext> {
	public CriteriaPropertiesEFEFCoreDbContext CreateDbContext(string[] args) {
		throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
		//var optionsBuilder = new DbContextOptionsBuilder<CriteriaPropertiesEFEFCoreDbContext>();
		//optionsBuilder.UseSqlServer("Integrated Security=SSPI;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CriteriaPropertiesEF");
        //optionsBuilder.UseChangeTrackingProxies();
        //optionsBuilder.UseObjectSpaceLinkProxies();
		//return new CriteriaPropertiesEFEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(CriteriaPropertiesEFContextInitializer))]
public class CriteriaPropertiesEFEFCoreDbContext : DbContext {
	public CriteriaPropertiesEFEFCoreDbContext(DbContextOptions<CriteriaPropertiesEFEFCoreDbContext> options) : base(options) {
	}
    public DbSet<Product> Products { get; set; }
    public DbSet<MyPerson> MyPersons { get; set; }
    public DbSet<FilteringCriterion> FilteringCriteria { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.Entity<FilteringCriterion>().Property(e => e.ObjectType).HasConversion(v => v.FullName, v => ReflectionHelper.FindType((string)v));
    }
}
