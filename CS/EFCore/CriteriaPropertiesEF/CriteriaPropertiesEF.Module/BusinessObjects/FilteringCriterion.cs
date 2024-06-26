using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HowToUseCriteriaPropertyEditors.Module {
    [DefaultClassOptions, ImageName("Action_Filter")]
    public class FilteringCriterion : BaseObject {
        private Type objectType;

        public virtual string Description { get; set; }

        [Browsable(false)]
        public virtual string ObjectTypeName {
            get { return objectType == null ? string.Empty : objectType.FullName; }
            set {
                ITypeInfo typeInfo = XafTypesInfo.Instance.FindTypeInfo(value);
                objectType = typeInfo == null ? null : typeInfo.Type;
            }
        }

        [NotMapped, ImmediatePostData]
        public virtual Type ObjectType {
            get { return objectType; }
            set {
                if (objectType == value)
                    return;
                objectType = value;
                Criterion = string.Empty;
            }
        }

        [CriteriaOptions(nameof(ObjectType))]
        [FieldSize(FieldSizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
        public virtual string Criterion { get; set; }
    }
}