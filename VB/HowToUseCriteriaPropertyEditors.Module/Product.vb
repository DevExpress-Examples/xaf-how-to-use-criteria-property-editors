Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace HowToUseCriteriaPropertyEditors.Module
    <DefaultClassOptions, ImageName("BO_Product")> _
    Public Class Product
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property Name() As String
            Get
                Return GetPropertyValue(Of String)("Name")
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Name", value)
            End Set
        End Property
        Public Property Price() As Double
            Get
                Return GetPropertyValue(Of Double)("Price")
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Price", value)
            End Set
        End Property
        Public Property Quantity() As Integer
            Get
                Return GetPropertyValue(Of Integer)("Quantity")
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Quantity", value)
            End Set
        End Property
        Public Property Manager() As Person
            Get
                Return GetPropertyValue(Of Person)("Manager")
            End Get
            Set(ByVal value As Person)
                SetPropertyValue(Of Person)("Manager", value)
            End Set
        End Property
    End Class
End Namespace
