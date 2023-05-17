using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace HowToUseCriteriaPropertyEditors.Module {
    public class MyPerson : BaseObject {
        private string firstName;
        private string lastName;
        private string email;

        public MyPerson(Session session) : base(session) { }

        public string FirstName { get => firstName; set { SetPropertyValue(nameof(FirstName), ref firstName, value); } }
        public string LastName { get => lastName; set { SetPropertyValue(nameof(LastName), ref lastName, value); } }
        public string Email { get => email; set { SetPropertyValue(nameof(Email), ref email, value); } }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
