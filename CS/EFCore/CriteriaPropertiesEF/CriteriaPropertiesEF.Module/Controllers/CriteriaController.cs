using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace HowToUseCriteriaPropertyEditors.Module {
    public class CriteriaController : ViewController<ListView> {
        private SingleChoiceAction filteringCriterionAction;
        public CriteriaController() {
            filteringCriterionAction = new SingleChoiceAction(
                this, "FilteringCriterion", PredefinedCategory.Filters);
            filteringCriterionAction.Execute += FilteringCriterionAction_Execute;
        }
        protected override void OnActivated() {
            filteringCriterionAction.Items.Clear();
            foreach (FilteringCriterion criterion in ObjectSpace.GetObjects<FilteringCriterion>()) {
                if (criterion.ObjectType.IsAssignableFrom(View.ObjectTypeInfo.Type)) {
                    filteringCriterionAction.Items.Add(new ChoiceActionItem(criterion.Description, criterion.Criterion));
                }
            }
            if (filteringCriterionAction.Items.Count > 0) {
                filteringCriterionAction.Items.Add(new ChoiceActionItem("All", null));
            }
        }
        private void FilteringCriterionAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e) {
            var collectionSource = View.CollectionSource;
            collectionSource.BeginUpdateCriteria();
            collectionSource.Criteria.Clear();
            collectionSource.Criteria[e.SelectedChoiceActionItem.Caption] = ObjectSpace.ParseCriteria(e.SelectedChoiceActionItem.Data as string);
            collectionSource.EndUpdateCriteria();
        }
    }
}