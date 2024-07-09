using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System.ComponentModel;

namespace HowToUseCriteriaPropertyEditors.Module {
    [DefaultClassOptions, ImageName("Action_Filter")]
    public class FilteringCriterion : BaseObject {
        public FilteringCriterion(Session session) : base(session) { }

        private string description;
        public string Description {
            get { return description; }
            set { SetPropertyValue<string>(nameof(Description), ref description, value); }
        }

        private string objectTypeName;
        [Browsable(false)]
        public string ObjectTypeName {
            get { return objectTypeName; }
            set {
                Type type = XafTypesInfo.Instance.FindTypeInfo(value) == null ? null :
                    XafTypesInfo.Instance.FindTypeInfo(value).Type;
                if (objectType != type) {
                    objectType = type;
                }
                if (!IsLoading && value != objectTypeName) {
                    Criterion = string.Empty;
                }
                SetPropertyValue<string>(nameof(ObjectTypeName), ref objectTypeName, value);
            }
        }

        private Type objectType;
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        [ImmediatePostData, NonPersistent]
        public Type ObjectType {
            get { return objectType; }
            set {
                if (objectType != value) {
                    objectType = value;
                    ObjectTypeName = (value == null) ? null : value.FullName;
                }
            }
        }

        private string criterion;
        [CriteriaOptions(nameof(ObjectType))]
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
        public string Criterion {
            get { return criterion; }
            set { SetPropertyValue<string>(nameof(Criterion), ref criterion, value); }
        }
    }
}
