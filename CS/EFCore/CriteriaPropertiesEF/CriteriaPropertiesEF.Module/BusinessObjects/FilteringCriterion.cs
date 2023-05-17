using System;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using System.ComponentModel;
using DevExpress.Persistent.BaseImpl.EF;
using System.ComponentModel.DataAnnotations.Schema;

namespace HowToUseCriteriaPropertyEditors.Module {
    [DefaultClassOptions, ImageName("Action_Filter")]
    public class FilteringCriterion : BaseObject {
        public virtual string Description { get; set; }
        private Type fDataType;
        [ImmediatePostData]
        public virtual Type ObjectType {
            get { return fDataType; }
            set {
                if (fDataType == value) return;
                fDataType = value;
                Criterion = string.Empty;
            }
        }
        [CriteriaOptions("ObjectType")]
        [EditorAlias(EditorAliases.PopupCriteriaPropertyEditor)]
        public virtual string Criterion { get; set; }
    }
}
