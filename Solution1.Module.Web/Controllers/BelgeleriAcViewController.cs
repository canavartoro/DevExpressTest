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
using DevExpress.ExpressApp.Web;

namespace Solution1.Module.Web.Controllers
{
    public partial class BelgeleriAcViewController : ViewController
    {
        public BelgeleriAcViewController()
        {
            InitializeComponent();
            RegisterActions(components);
            // For instance, you can specify activation conditions of a Controller or create its Actions (http://documentation.devexpress.com/#Xaf/CustomDocument2622).
            //TargetObjectType = typeof(DomainObject1);
            //TargetViewType = ViewType.DetailView;
            //TargetViewId = "DomainObject1_DetailView";
            //TargetViewNesting = Nesting.Root;
            //SimpleAction myAction = new SimpleAction(this, "MyActionId", DevExpress.Persistent.Base.PredefinedCategory.RecordEdit);
        }

        protected override void OnFrameAssigned()
        {
            base.OnFrameAssigned();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        private void actionBelgeAc_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (WebWindow.CurrentRequestWindow != null)
            {
                var ogrenci = e.CurrentObject as Module.BusinessObjects.Ogrenci;
                if (ogrenci != null)
                {
                    string popup = string.Format("window.open('belge.aspx?id={0}', 'Öðrenci Belgeleri', 'width=600, height=440',resizable=0);", ogrenci.Oid);
                    WebWindow.CurrentRequestWindow.RegisterClientScript("dosyaform" + this.GetType().Name, popup);
                }


            }
        }
    }
}
