using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using HowToUseCriteriaPropertyEditors.Module;

namespace CriteriaProperties.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        var cnt = ObjectSpace.GetObjectsCount(typeof(Person), null);
        if(cnt > 0 ) {
            return;
        }
        Person samplePerson1 = ObjectSpace.FindObject<Person>(CriteriaOperator.Parse("FullName == 'Mary Tellitson'"));
        if (samplePerson1 == null) {
            samplePerson1 = ObjectSpace.CreateObject<Person>();
            samplePerson1.FirstName = "Mary";
            samplePerson1.LastName = "Tellitson";
            samplePerson1.Email = "mary@example.com";
        }
        Person samplePerson2 = ObjectSpace.FindObject<Person>(CriteriaOperator.Parse("FullName == 'John Nilsen'"));
        if (samplePerson2 == null) {
            samplePerson2 = ObjectSpace.CreateObject<Person>();
            samplePerson2.FirstName = "John";
            samplePerson2.LastName = "Nilsen";
        }
        Product sampleProduct1 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Geitost'"));
        if (sampleProduct1 == null) {
            sampleProduct1 = ObjectSpace.CreateObject<Product>();
            sampleProduct1.Name = "Geitost";
            sampleProduct1.Price = 2;
            sampleProduct1.Quantity = 25;
            sampleProduct1.Manager = samplePerson1;
        }
        Product sampleProduct2 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Maxilaku'"));
        if (sampleProduct2 == null) {
            sampleProduct2 = ObjectSpace.CreateObject<Product>();
            sampleProduct2.Name = "Maxilaku";
            sampleProduct2.Price = 16;
            sampleProduct2.Quantity = 40;
            sampleProduct2.Manager = samplePerson1;
        }
        Product sampleProduct3 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Queso Cabrales'"));
        if (sampleProduct3 == null) {
            sampleProduct3 = ObjectSpace.CreateObject<Product>();
            sampleProduct3.Name = "Queso Cabrales";
            sampleProduct3.Price = 14;
            sampleProduct3.Quantity = 12;
            sampleProduct3.Manager = samplePerson2;
        }
        Product sampleProduct4 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Ravioli Angelo'"));
        if (sampleProduct4 == null) {
            sampleProduct4 = ObjectSpace.CreateObject<Product>();
            sampleProduct4.Name = "Ravioli Angelo";
            sampleProduct4.Price = 15.6;
            sampleProduct4.Quantity = 15;
            sampleProduct4.Manager = samplePerson2;
        }
        Product sampleProduct5 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Tofu'"));
        if (sampleProduct5 == null) {
            sampleProduct5 = ObjectSpace.CreateObject<Product>();
            sampleProduct5.Name = "Tofu";
            sampleProduct5.Price = 18.6;
            sampleProduct5.Quantity = 9;
            sampleProduct5.Manager = samplePerson2;
        }
        FilteringCriterion sampleCriterion = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Low on stock'"));
        if (sampleCriterion == null) {
            sampleCriterion = ObjectSpace.CreateObject<FilteringCriterion>();
            sampleCriterion.Description = "Low on stock";
            sampleCriterion.ObjectType = typeof(Product);
            sampleCriterion.Criterion = "[Quantity] < 10";
        }
        FilteringCriterion sampleCriterion2 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Cheap'"));
        if (sampleCriterion2 == null) {
            sampleCriterion2 = ObjectSpace.CreateObject<FilteringCriterion>();
            sampleCriterion2.Description = "Cheap";
            sampleCriterion2.ObjectType = typeof(Product);
            sampleCriterion2.Criterion = "[Price] < 5.0";
        }
        FilteringCriterion sampleCriterion3 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Expensive'"));
        if (sampleCriterion3 == null) {
            sampleCriterion3 = ObjectSpace.CreateObject<FilteringCriterion>();
            sampleCriterion3.Description = "Expensive";
            sampleCriterion3.ObjectType = typeof(Product);
            sampleCriterion3.Criterion = "[Price] > 15.0";
        }
        FilteringCriterion sampleCriterion4 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Overstocked'"));
        if (sampleCriterion4 == null) {
            sampleCriterion4 = ObjectSpace.CreateObject<FilteringCriterion>();
            sampleCriterion4.Description = "Overstocked";
            sampleCriterion4.ObjectType = typeof(Product);
            sampleCriterion4.Criterion = "[Quantity] > 30";
        }
        FilteringCriterion sampleCriterion5 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Manager is Mary Tellitson'"));
        if (sampleCriterion5 == null) {
            sampleCriterion5 = ObjectSpace.CreateObject<FilteringCriterion>();
            sampleCriterion5.Description = "Manager is Mary Tellitson";
            sampleCriterion5.ObjectType = typeof(Product);
            sampleCriterion5.Criterion = "[Manager.FullName] == 'Mary Tellitson'";
        }
        FilteringCriterion sampleCriterion6 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Manager is John Nilsen'"));
        if (sampleCriterion6 == null) {
            sampleCriterion6 = ObjectSpace.CreateObject<FilteringCriterion>();
            sampleCriterion6.Description = "Manager is John Nilsen";
            sampleCriterion6.ObjectType = typeof(Product);
            sampleCriterion6.Criterion = "[Manager.FullName] == 'John Nilsen'";
        }

        FilteringCriterion sampleCriterion7 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Has email'"));
        if (sampleCriterion7 == null) {
            sampleCriterion7 = ObjectSpace.CreateObject<FilteringCriterion>();
            sampleCriterion7.Description = "Has email";
            sampleCriterion7.ObjectType = typeof(Person);
            sampleCriterion7.Criterion = "Not IsNullOrEmpty([Email])";
        }
        ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
        //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
        //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
        //}
    }
}
