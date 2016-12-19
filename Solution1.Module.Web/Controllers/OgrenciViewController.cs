using System;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using Solution1.Module.BusinessObjects;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;

namespace Solution1.Module.Web.Controllers
{
    public partial class OgrenciViewController : ViewController
    {
        private DeleteObjectsViewController controller;

        public OgrenciViewController()
        {
            InitializeComponent();
            RegisterActions(components);
            TargetObjectType = typeof(Ogrenci);
            TargetViewNesting = Nesting.Root;
        }

        protected override void OnFrameAssigned()
        {
            base.OnFrameAssigned();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            controller = Frame.GetController<DeleteObjectsViewController>();
            if (controller != null)
            {
                controller.DeleteAction.Executing += DeleteAction_Executing;
            }
        }

        void DeleteAction_Executing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool iscancel = false;

            if (View.SelectedObjects.Cast<Ogrenci>().Where(f => f.Belgeler.Count > 0).Count() > 0)
                iscancel = true;

            if (View.CurrentObject != null && ((Ogrenci)View.CurrentObject).Belgeler.Count > 0)
                iscancel = true;

            if (iscancel)
            {
                WebApplication application = WebApplication.Instance;
                IObjectSpace objectSpace = application.CreateObjectSpace();
                View detailView = application.CreateDetailView(objectSpace, new MessageBoxTextMessage("S›L›NMEK ›STEN›LEN ÷–RENC› ALTINDA S›STEMDE TANIMLI BELGE KAYDI BULUNMAKTADIR. \n÷–RENC›YLE B›RL›KTE TANIMLI T‹M BELGELER› S›LMEK ›STED›–›N›ZDEN EM›N M›S›N›Z?"), false);
                ShowViewParameters showViewParameters = new ShowViewParameters(detailView);
                showViewParameters.Context = TemplateContext.PopupWindow;
                showViewParameters.TargetWindow = TargetWindow.NewModalWindow;
                DialogController h = application.CreateController<DialogController>();
                h.SaveOnAccept = false;
                h.CanCloseWindow = true;
                h.Accepting += h_Accepting;
                h.Cancelling += h_Cancelling;
                showViewParameters.Controllers.Add(h);

                ShowViewSource viewSource = new ShowViewSource(WebWindow.CurrentRequestWindow, null);
                application.ShowViewStrategy.ShowView(showViewParameters, viewSource);
                e.Cancel = true;
            }
        }

        void h_Cancelling(object sender, EventArgs e)
        {
            View.ObjectSpace.Rollback();
            viewClose();
        }        

        void h_Accepting(object sender, DialogControllerAcceptingEventArgs e)
        {
            if (View.CurrentObject != null)
            {
                if (((Ogrenci)View.CurrentObject).Belgeler.Count > 0)
                {
                    XPCollection<Belgeler> OgrenciBelgeleri = new XPCollection<Belgeler>(((XPObjectSpace)View.ObjectSpace).Session, ((Ogrenci)View.CurrentObject).Belgeler);
                    for (int i = OgrenciBelgeleri.Count; i > 0; i--)
                    {
                        if (OgrenciBelgeleri[i - 1].Dosya != null)
                            OgrenciBelgeleri[i - 1].Dosya.Delete();
                        OgrenciBelgeleri[i - 1].Delete();
                    }
                }
                ((Ogrenci)View.CurrentObject).Delete();
            }
            else if (View.SelectedObjects.Count > 0)
            {
                List<Ogrenci> ogrenciler = View.SelectedObjects.Cast<Ogrenci>().ToList();
                for (int i = ogrenciler.Count; i > 0; i--)
                {
                    if (ogrenciler[i - 1].Belgeler.Count > 0)
                    {
                        XPCollection<Belgeler> tesisBelgeleri = new XPCollection<Belgeler>(ogrenciler[i - 1].Session, ogrenciler[i - 1].Belgeler);
                        for (int l = tesisBelgeleri.Count; l > 0; l--)
                        {
                            if (tesisBelgeleri[l - 1].Dosya != null)
                                tesisBelgeleri[l - 1].Dosya.Delete();
                            tesisBelgeleri[l - 1].Delete();
                        }
                    }
                    ogrenciler[i - 1].Delete();
                }
            }

            ((XPObjectSpace)View.ObjectSpace).Session.PurgeDeletedObjects();
            View.ObjectSpace.CommitChanges();
            viewClose();
        }

        private void viewClose()
        {
            if (View is ListView && ((ListView)View).CanClose())
            {
                ((ListView)View).Close();
            }
            else if (View is DetailView && ((DetailView)View).CanClose())
            {
                ((DetailView)View).Close();
            }
            else
            {
                View.Refresh();
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            if (controller != null)
            {
                controller.DeleteAction.Executing -= DeleteAction_Executing;
            }
            controller = null;  
        }

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

    }
}
