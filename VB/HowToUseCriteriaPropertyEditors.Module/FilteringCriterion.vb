Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils
Imports System.ComponentModel

Namespace HowToUseCriteriaPropertyEditors.Module
    <DefaultClassOptions, ImageName("Action_Filter")> _
    Public Class FilteringCriterion
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Property Description() As String
            Get
                Return GetPropertyValue(Of String)("Description")
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", value)
            End Set
        End Property
        <ValueConverter(GetType(TypeToStringConverter)), ImmediatePostData, TypeConverter(GetType(LocalizedClassInfoTypeConverter))> _
        Public Property ObjectType() As Type
            Get
                Return GetPropertyValue(Of Type)("ObjectType")
            End Get
            Set(ByVal value As Type)
                SetPropertyValue(Of Type)("ObjectType", value)
                Criterion = String.Empty
            End Set
        End Property
        <CriteriaOptions("ObjectType"), Size(SizeAttribute.Unlimited), EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)> _
        Public Property Criterion() As String
            Get
                Return GetPropertyValue(Of String)("Criterion")
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Criterion", value)
            End Set
        End Property
    End Class
End Namespace
