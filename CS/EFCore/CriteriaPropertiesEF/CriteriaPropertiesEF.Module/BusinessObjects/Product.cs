using System;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;

namespace HowToUseCriteriaPropertyEditors.Module {
    [DefaultClassOptions, ImageName("BO_Product")]
    public class Product : BaseObject {

        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual int Quantity { get; set; }
        public virtual MyPerson Manager { get; set; }
    }
}
