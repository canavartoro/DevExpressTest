//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Actions;
//using DevExpress.ExpressApp.SystemModule;
//using DevExpress.Xpo;
//using Mikrobar.Module.BusinessObjects;

//namespace Mikrobar.Module.Controllers
//{
//    [NonPersistent]
//    public class GenericMessageBox
//    {
//        public delegate void MessageBoxEventHandler(object sender, ShowViewParameters e);

//        private event MessageBoxEventHandler localAccept;
//        private event EventHandler localCancel;

//        public GenericMessageBox(ShowViewParameters svp, XafApplication app, string Message, MessageBoxEventHandler Accept, EventHandler Cancel)
//        {
//            CreateDetailView(svp, app, Message);
//            AttachDialogController(svp, app, Accept, Cancel);
//        }

//        public GenericMessageBox(ShowViewParameters svp, XafApplication app, string Message, MessageBoxEventHandler Accept)
//        {
//            CreateDetailView(svp, app, Message);
//            AttachDialogController(svp, app, Accept);
//        }

//        private void AttachDialogController(ShowViewParameters svp, XafApplication app, MessageBoxEventHandler Accept, EventHandler Cancel)
//        {
//            localAccept = Accept;
//            localCancel = Cancel;
//            DialogController dc = app.CreateController<DialogController>();
//            dc.AcceptAction.Execute += AcceptAction_Execute;
//            dc.Cancelling += dc_Cancelling;
//            svp.Controllers.Add(dc);
//        }

//        private void AttachDialogController(ShowViewParameters svp, XafApplication app, MessageBoxEventHandler Accept)
//        {
//            localAccept = Accept;
//            DialogController dc = app.CreateController<DialogController>();
//            dc.AcceptAction.Execute += AcceptAction_Execute;
//            dc.CancelAction.Enabled.SetItemValue("Cancel Disabled", false);
//            dc.CancelAction.Active.SetItemValue("Cancel Disabled", false);
//            svp.Controllers.Add(dc);
//        }

//        private void AttachDialogController(ShowViewParameters svp, XafApplication app)
//        {
//            DialogController dc = app.CreateController<DialogController>();
//            dc.AcceptAction.Execute += AcceptAction_Execute;
//            dc.CancelAction.Enabled.SetItemValue("Cancel Disabled", false);
//            dc.CancelAction.Active.SetItemValue("Cancel Disabled", false);
//            svp.Controllers.Add(dc);
//        }

//        private static void CreateDetailView(ShowViewParameters svp, XafApplication app, string Message)
//        {
//            svp.CreatedView = app.CreateDetailView(app.CreateObjectSpace(), new MessageBoxTextMessage(Message)); ;
//            svp.TargetWindow = TargetWindow.NewModalWindow;
//            svp.Context = TemplateContext.PopupWindow;
//            svp.CreateAllControllers = true;
//        }

//        void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e)
//        {
//            if (localAccept != null)
//                localAccept(this, e.ShowViewParameters);
//        }

//        void dc_Cancelling(object sender, EventArgs e)
//        {
//            if (localCancel != null)
//                localCancel(this, e);
//        }

//        /*
//         new GenericMessageBox.GenericMessageBox(e, Application, "Ok button pressed");
//         new GenericMessageBox.GenericMessageBox(e.ShowViewParameters, Application, "Just to said something");
//         new GenericMessageBox.GenericMessageBox(e.ShowViewParameters, Application, "Just to said something and act when Ok clicked", Ok_Click_at_InfoDialog);
//         new GenericMessageBox.GenericMessageBox(e.ShowViewParameters, Application, "Press Ok or press cancel, both have something to said", Ok_Click, Cancel_Click);
//         * 
//         * 
//         WebApplication application = WebApplication.Instance;
//         IObjectSpace objectSpace = application.CreateObjectSpace();
//         View detailView = application.CreateDetailView(objectSpace, new MessageBoxTextMessage("dikkat"), false);
//         ShowViewParameters showViewParameters = new ShowViewParameters(detailView);
//         showViewParameters.Context = TemplateContext.PopupWindow;
//         showViewParameters.TargetWindow = TargetWindow.NewModalWindow;
//         DialogController h = application.CreateController<DialogController>();
//         h.SaveOnAccept = false;
//         h.CanCloseWindow = true;
//         h.Accepting += h_Accepting;
//         showViewParameters.Controllers.Add(h);

//         ShowViewSource viewSource = new ShowViewSource(WebWindow.CurrentRequestWindow, null);
//         application.ShowViewStrategy.ShowView(showViewParameters, viewSource);
//         */
//    }
//}
