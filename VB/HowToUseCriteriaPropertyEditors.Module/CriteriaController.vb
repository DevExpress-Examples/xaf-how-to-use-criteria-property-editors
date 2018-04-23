Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Templates

Namespace HowToUseCriteriaPropertyEditors.Module
    Public Class CriteriaController
        Inherits ObjectViewController

        Private filteringCriterionAction As SingleChoiceAction
        Public Sub New()
            filteringCriterionAction = New SingleChoiceAction(Me, "FilteringCriterion", PredefinedCategory.Filters)
            AddHandler filteringCriterionAction.Execute, AddressOf FilteringCriterionAction_Execute
            TargetViewType = ViewType.ListView
        End Sub
        Protected Overrides Sub OnActivated()
            filteringCriterionAction.Items.Clear()
            For Each criterion As FilteringCriterion In ObjectSpace.GetObjects(Of FilteringCriterion)()
                If criterion.ObjectType.IsAssignableFrom(View.ObjectTypeInfo.Type) Then
                    filteringCriterionAction.Items.Add(New ChoiceActionItem(criterion.Description, criterion.Criterion))
                End If
            Next criterion
            If filteringCriterionAction.Items.Count > 0 Then
                filteringCriterionAction.Items.Add(New ChoiceActionItem("All", Nothing))
            End If
        End Sub
        Private Sub FilteringCriterionAction_Execute(ByVal sender As Object, ByVal e As SingleChoiceActionExecuteEventArgs)
            CType(View, ListView).CollectionSource.BeginUpdateCriteria()
            CType(View, ListView).CollectionSource.Criteria.Clear()
            CType(View, ListView).CollectionSource.Criteria(e.SelectedChoiceActionItem.Caption) = CriteriaEditorHelper.GetCriteriaOperator(TryCast(e.SelectedChoiceActionItem.Data, String), View.ObjectTypeInfo.Type, ObjectSpace)
            CType(View, ListView).CollectionSource.EndUpdateCriteria()
        End Sub
    End Class
End Namespace
