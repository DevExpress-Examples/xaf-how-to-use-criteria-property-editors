using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using System.ComponentModel;

namespace HowToUseCriteriaPropertyEditors.Module {
    [DefaultClassOptions, ImageName("Action_Filter")]
    public class FilteringCriterion : BaseObject {
        public FilteringCriterion(Session session) : base(session) { }
        public string Description {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue<string>("Description", value); }
        }
        [ValueConverter(typeof(TypeToStringConverter)), ImmediatePostData]
        [TypeConverter(typeof(LocalizedClassInfoTypeConverter))]
        public Type ObjectType {
            get { return GetPropertyValue<Type>("ObjectType"); }
            set {
                SetPropertyValue<Type>("ObjectType", value); 
                Criterion = String.Empty;
            }
        }
        [CriteriaOptions("ObjectType"), Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
        public string Criterion {
            get { return GetPropertyValue<string>("Criterion"); }
            set { SetPropertyValue<string>("Criterion", value); }
        }
    }
}
