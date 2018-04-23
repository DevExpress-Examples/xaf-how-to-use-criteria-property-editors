using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace HowToUseCriteriaPropertyEditors.Module {
    [DefaultClassOptions, ImageName("BO_Product")]
    public class Product : BaseObject {
        public Product(Session session) : base(session) { }
        public string Name {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue<string>("Name", value); }
        }
        public double Price {
            get { return GetPropertyValue<double>("Price"); }
            set { SetPropertyValue<double>("Price", value); }
        }
        public int Quantity {
            get { return GetPropertyValue<int>("Quantity"); }
            set { SetPropertyValue<int>("Quantity", value); }
        }
        public Person Manager {
            get { return GetPropertyValue<Person>("Manager"); }
            set { SetPropertyValue<Person>("Manager", value); }
        }
    }
}
