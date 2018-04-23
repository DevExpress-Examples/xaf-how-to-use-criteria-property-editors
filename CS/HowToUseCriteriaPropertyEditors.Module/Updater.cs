using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;

namespace HowToUseCriteriaPropertyEditors.Module {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            Person samplePerson1 = ObjectSpace.FindObject<Person>(CriteriaOperator.Parse("FullName == 'Mary Tellitson'"));
            if (samplePerson1 == null) {
                samplePerson1 = ObjectSpace.CreateObject<Person>();
                samplePerson1.FirstName = "Mary";
                samplePerson1.LastName = "Tellitson";
                samplePerson1.Email = "mary@example.com";
                samplePerson1.Save();
            }
            Person samplePerson2 = ObjectSpace.FindObject<Person>(CriteriaOperator.Parse("FullName == 'John Nilsen'"));
            if (samplePerson2 == null) {
                samplePerson2 = ObjectSpace.CreateObject<Person>();
                samplePerson2.FirstName = "John";
                samplePerson2.LastName = "Nilsen";
                samplePerson2.Save();
            }
            Product sampleProduct1 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Geitost'"));
            if (sampleProduct1 == null) {
                sampleProduct1 = ObjectSpace.CreateObject<Product>();
                sampleProduct1.Name = "Geitost";
                sampleProduct1.Price = 2;
                sampleProduct1.Quantity = 25;
                sampleProduct1.Manager = samplePerson1;
                sampleProduct1.Save();
            }
            Product sampleProduct2 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Maxilaku'"));
            if (sampleProduct2 == null) {
                sampleProduct2 = ObjectSpace.CreateObject<Product>();
                sampleProduct2.Name = "Maxilaku";
                sampleProduct2.Price = 16;
                sampleProduct2.Quantity = 40;
                sampleProduct2.Manager = samplePerson1;
                sampleProduct2.Save();
            }
            Product sampleProduct3 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Queso Cabrales'"));
            if (sampleProduct3 == null) {
                sampleProduct3 = ObjectSpace.CreateObject<Product>();
                sampleProduct3.Name = "Queso Cabrales";
                sampleProduct3.Price = 14;
                sampleProduct3.Quantity = 12;
                sampleProduct3.Manager = samplePerson2;
                sampleProduct3.Save();
            }
            Product sampleProduct4 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Ravioli Angelo'"));
            if (sampleProduct4 == null) {
                sampleProduct4 = ObjectSpace.CreateObject<Product>();
                sampleProduct4.Name = "Ravioli Angelo";
                sampleProduct4.Price = 15.6;
                sampleProduct4.Quantity = 15;
                sampleProduct4.Manager = samplePerson2;
                sampleProduct4.Save();
            }
            Product sampleProduct5 = ObjectSpace.FindObject<Product>(CriteriaOperator.Parse("Name == 'Tofu'"));
            if (sampleProduct5 == null) {
                sampleProduct5 = ObjectSpace.CreateObject<Product>();
                sampleProduct5.Name = "Tofu";
                sampleProduct5.Price = 18.6;
                sampleProduct5.Quantity = 9;
                sampleProduct5.Manager = samplePerson2;
                sampleProduct5.Save();
            }
            FilteringCriterion sampleCriterion = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Low on stock'"));
            if (sampleCriterion == null) {
                sampleCriterion = ObjectSpace.CreateObject<FilteringCriterion>();
                sampleCriterion.Description = "Low on stock";
                sampleCriterion.ObjectType = typeof(Product);
                sampleCriterion.Criterion = "[Quantity] < 10";
                sampleCriterion.Save();
            }
            FilteringCriterion sampleCriterion2 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Cheap'"));
            if (sampleCriterion2 == null) {
                sampleCriterion2 = ObjectSpace.CreateObject<FilteringCriterion>();
                sampleCriterion2.Description = "Cheap";
                sampleCriterion2.ObjectType = typeof(Product);
                sampleCriterion2.Criterion = "[Price] < 5.0";
                sampleCriterion2.Save();
            }
            FilteringCriterion sampleCriterion3 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Expensive'"));
            if (sampleCriterion3 == null) {
                sampleCriterion3 = ObjectSpace.CreateObject<FilteringCriterion>();
                sampleCriterion3.Description = "Expensive";
                sampleCriterion3.ObjectType = typeof(Product);
                sampleCriterion3.Criterion = "[Price] > 15.0";
                sampleCriterion3.Save();
            }
            FilteringCriterion sampleCriterion4 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Overstocked'"));
            if (sampleCriterion4 == null) {
                sampleCriterion4 = ObjectSpace.CreateObject<FilteringCriterion>();
                sampleCriterion4.Description = "Overstocked";
                sampleCriterion4.ObjectType = typeof(Product);
                sampleCriterion4.Criterion = "[Quantity] > 30";
                sampleCriterion4.Save();
            }
            FilteringCriterion sampleCriterion5 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Manager is Mary Tellitson'"));
            if(sampleCriterion5 == null) {
                sampleCriterion5 = ObjectSpace.CreateObject<FilteringCriterion>();
                sampleCriterion5.Description = "Manager is Mary Tellitson";
                sampleCriterion5.ObjectType = typeof(Product);
                sampleCriterion5.Criterion = "[Manager.FullName] == 'Mary Tellitson'";
                sampleCriterion5.Save();
            }
            FilteringCriterion sampleCriterion6 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Manager is John Nilsen'"));
            if(sampleCriterion6 == null) {
                sampleCriterion6 = ObjectSpace.CreateObject<FilteringCriterion>();
                sampleCriterion6.Description = "Manager is John Nilsen";
                sampleCriterion6.ObjectType = typeof(Product);
                sampleCriterion6.Criterion = "[Manager.FullName] == 'John Nilsen'";
                sampleCriterion6.Save();
            }

            FilteringCriterion sampleCriterion7 = ObjectSpace.FindObject<FilteringCriterion>(CriteriaOperator.Parse("Description == 'Has email'"));
            if (sampleCriterion7 == null) {
                sampleCriterion7 = ObjectSpace.CreateObject<FilteringCriterion>();
                sampleCriterion7.Description = "Has email";
                sampleCriterion7.ObjectType = typeof(Person);
                sampleCriterion7.Criterion = "Not IsNullOrEmpty([Email])";
                sampleCriterion7.Save();
            }
        }
    }
}
