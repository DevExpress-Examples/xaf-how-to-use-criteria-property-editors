using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using HowToUseCriteriaPropertyEditors.Module;

namespace HowToUseCriteriaPropertyEditors.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            HowToUseCriteriaPropertyEditorsWindowsFormsApplication winApplication = new HowToUseCriteriaPropertyEditorsWindowsFormsApplication();
            try {
                DevExpress.ExpressApp.Xpo.InMemoryDataStoreProvider.Register();
                winApplication.ConnectionString = DevExpress.ExpressApp.Xpo.InMemoryDataStoreProvider.ConnectionString;
                winApplication.Setup();
                winApplication.Start();
            }
            catch (Exception e) {
                winApplication.HandleException(e);
            }
        }
    }
}
