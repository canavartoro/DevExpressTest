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
using Solution1.Module.BusinessObjects;
using System.IO;

namespace Solution1.Module.Web.Controllers
{
    public partial class BelgeKontrolViewController : ViewController
    {
        public BelgeKontrolViewController()
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

        private void actionKontrol_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (WebWindow.CurrentRequestWindow != null)
            {
                var ogrenci = e.CurrentObject as Module.BusinessObjects.Ogrenci;
                if (ogrenci != null)
                {
                    StringBuilder sbAlert = new StringBuilder();
                    List<Belgeler> belgeler = ogrenci.Belgeler.Cast<Belgeler>().ToList();
                    for (int i = 0; i < belgeler.Count; i++)
                    {
                        FileInfo f = new FileInfo(belgeler[i].DosyaAdi);
                        if (f.Exists)
                        {
                            sbAlert.AppendFormat("{0} var. ", belgeler[i].Ad);
                        }
                        else
                        {
                            sbAlert.AppendFormat("{0} yok! ", belgeler[i].Ad);
                        }
                    }
                    string popup = string.Format("alert('{0}');", sbAlert.ToString());
                    WebWindow.CurrentRequestWindow.RegisterClientScript("belgealert" + this.GetType().Name, popup);
                }


            }
        }
    }
}
