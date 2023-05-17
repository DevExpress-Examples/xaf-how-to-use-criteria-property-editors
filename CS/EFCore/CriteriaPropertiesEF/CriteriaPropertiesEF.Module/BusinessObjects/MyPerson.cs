using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.EF;
using System.ComponentModel.DataAnnotations.Schema;

namespace HowToUseCriteriaPropertyEditors.Module {
    public class MyPerson : BaseObject {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
 
    }
}
