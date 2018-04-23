Imports System

Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.BaseImpl

Namespace HowToUseCriteriaPropertyEditors.Module
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            Dim samplePerson1 As Person = ObjectSpace.FindObject(Of Person)(CriteriaOperator.Parse("FullName == 'Mary Tellitson'"))
            If samplePerson1 Is Nothing Then
                samplePerson1 = ObjectSpace.CreateObject(Of Person)()
                samplePerson1.FirstName = "Mary"
                samplePerson1.LastName = "Tellitson"
                samplePerson1.Email = "mary@example.com"
                samplePerson1.Save()
            End If
            Dim samplePerson2 As Person = ObjectSpace.FindObject(Of Person)(CriteriaOperator.Parse("FullName == 'John Nilsen'"))
            If samplePerson2 Is Nothing Then
                samplePerson2 = ObjectSpace.CreateObject(Of Person)()
                samplePerson2.FirstName = "John"
                samplePerson2.LastName = "Nilsen"
                samplePerson2.Save()
            End If
            Dim sampleProduct1 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Geitost'"))
            If sampleProduct1 Is Nothing Then
                sampleProduct1 = ObjectSpace.CreateObject(Of Product)()
                sampleProduct1.Name = "Geitost"
                sampleProduct1.Price = 2
                sampleProduct1.Quantity = 25
                sampleProduct1.Manager = samplePerson1
                sampleProduct1.Save()
            End If
            Dim sampleProduct2 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Maxilaku'"))
            If sampleProduct2 Is Nothing Then
                sampleProduct2 = ObjectSpace.CreateObject(Of Product)()
                sampleProduct2.Name = "Maxilaku"
                sampleProduct2.Price = 16
                sampleProduct2.Quantity = 40
                sampleProduct2.Manager = samplePerson1
                sampleProduct2.Save()
            End If
            Dim sampleProduct3 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Queso Cabrales'"))
            If sampleProduct3 Is Nothing Then
                sampleProduct3 = ObjectSpace.CreateObject(Of Product)()
                sampleProduct3.Name = "Queso Cabrales"
                sampleProduct3.Price = 14
                sampleProduct3.Quantity = 12
                sampleProduct3.Manager = samplePerson2
                sampleProduct3.Save()
            End If
            Dim sampleProduct4 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Ravioli Angelo'"))
            If sampleProduct4 Is Nothing Then
                sampleProduct4 = ObjectSpace.CreateObject(Of Product)()
                sampleProduct4.Name = "Ravioli Angelo"
                sampleProduct4.Price = 15.6
                sampleProduct4.Quantity = 15
                sampleProduct4.Manager = samplePerson2
                sampleProduct4.Save()
            End If
            Dim sampleProduct5 As Product = ObjectSpace.FindObject(Of Product)(CriteriaOperator.Parse("Name == 'Tofu'"))
            If sampleProduct5 Is Nothing Then
                sampleProduct5 = ObjectSpace.CreateObject(Of Product)()
                sampleProduct5.Name = "Tofu"
                sampleProduct5.Price = 18.6
                sampleProduct5.Quantity = 9
                sampleProduct5.Manager = samplePerson2
                sampleProduct5.Save()
            End If
            Dim sampleCriterion As FilteringCriterion = ObjectSpace.FindObject(Of FilteringCriterion)(CriteriaOperator.Parse("Description == 'Low on stock'"))
            If sampleCriterion Is Nothing Then
                sampleCriterion = ObjectSpace.CreateObject(Of FilteringCriterion)()
                sampleCriterion.Description = "Low on stock"
                sampleCriterion.ObjectType = GetType(Product)
                sampleCriterion.Criterion = "[Quantity] < 10"
                sampleCriterion.Save()
            End If
            Dim sampleCriterion2 As FilteringCriterion = ObjectSpace.FindObject(Of FilteringCriterion)(CriteriaOperator.Parse("Description == 'Cheap'"))
            If sampleCriterion2 Is Nothing Then
                sampleCriterion2 = ObjectSpace.CreateObject(Of FilteringCriterion)()
                sampleCriterion2.Description = "Cheap"
                sampleCriterion2.ObjectType = GetType(Product)
                sampleCriterion2.Criterion = "[Price] < 5.0"
                sampleCriterion2.Save()
            End If
            Dim sampleCriterion3 As FilteringCriterion = ObjectSpace.FindObject(Of FilteringCriterion)(CriteriaOperator.Parse("Description == 'Expensive'"))
            If sampleCriterion3 Is Nothing Then
                sampleCriterion3 = ObjectSpace.CreateObject(Of FilteringCriterion)()
                sampleCriterion3.Description = "Expensive"
                sampleCriterion3.ObjectType = GetType(Product)
                sampleCriterion3.Criterion = "[Price] > 15.0"
                sampleCriterion3.Save()
            End If
            Dim sampleCriterion4 As FilteringCriterion = ObjectSpace.FindObject(Of FilteringCriterion)(CriteriaOperator.Parse("Description == 'Overstocked'"))
            If sampleCriterion4 Is Nothing Then
                sampleCriterion4 = ObjectSpace.CreateObject(Of FilteringCriterion)()
                sampleCriterion4.Description = "Overstocked"
                sampleCriterion4.ObjectType = GetType(Product)
                sampleCriterion4.Criterion = "[Quantity] > 30"
                sampleCriterion4.Save()
            End If
            Dim sampleCriterion5 As FilteringCriterion = ObjectSpace.FindObject(Of FilteringCriterion)(CriteriaOperator.Parse("Description == 'Manager is Mary Tellitson'"))
            If sampleCriterion5 Is Nothing Then
                sampleCriterion5 = ObjectSpace.CreateObject(Of FilteringCriterion)()
                sampleCriterion5.Description = "Manager is Mary Tellitson"
                sampleCriterion5.ObjectType = GetType(Product)
                sampleCriterion5.Criterion = "[Manager.FullName] == 'Mary Tellitson'"
                sampleCriterion5.Save()
            End If
            Dim sampleCriterion6 As FilteringCriterion = ObjectSpace.FindObject(Of FilteringCriterion)(CriteriaOperator.Parse("Description == 'Manager is John Nilsen'"))
            If sampleCriterion6 Is Nothing Then
                sampleCriterion6 = ObjectSpace.CreateObject(Of FilteringCriterion)()
                sampleCriterion6.Description = "Manager is John Nilsen"
                sampleCriterion6.ObjectType = GetType(Product)
                sampleCriterion6.Criterion = "[Manager.FullName] == 'John Nilsen'"
                sampleCriterion6.Save()
            End If

            Dim sampleCriterion7 As FilteringCriterion = ObjectSpace.FindObject(Of FilteringCriterion)(CriteriaOperator.Parse("Description == 'Has email'"))
            If sampleCriterion7 Is Nothing Then
                sampleCriterion7 = ObjectSpace.CreateObject(Of FilteringCriterion)()
                sampleCriterion7.Description = "Has email"
                sampleCriterion7.ObjectType = GetType(Person)
                sampleCriterion7.Criterion = "Not IsNullOrEmpty([Email])"
                sampleCriterion7.Save()
            End If
        End Sub
    End Class
End Namespace
