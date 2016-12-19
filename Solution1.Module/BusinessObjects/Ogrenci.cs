using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace Solution1.Module.BusinessObjects
{

    public partial class Ogrenci : Tablo
    {
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Action(PredefinedCategory.Edit, Caption = "Tüm Belgeleri Sil", AutoCommit = true, TargetObjectsCriteria = "Belgeler.Count() > 0", ConfirmationMessage = "Tüm Belgeler Silinecek Onaylıyor musunuz?", ImageName = "Action_Delete", ToolTip = "Tüm Belgeleri Sil")]
        public void BelgeleriSil()
        {
            try
            {
                List<Belgeler> belgeler = this.Belgeler.Cast<Belgeler>().ToList();
                for (int i = belgeler.Count; i > 0; i--)
                {
                    belgeler[i - 1].Delete();
                }
            }
            catch (Exception) { }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }

        protected override void OnDeleting()
        {

            if (this.Belgeler.Count > 0)
            {
                XPCollection<Belgeler> tesisBelgeleri = new XPCollection<Belgeler>(this.Session, this.Belgeler);
                for (int i = tesisBelgeleri.Count; i > 0; i--)
                {
                    if (tesisBelgeleri[i - 1].Dosya != null)
                        tesisBelgeleri[i - 1].Dosya.Delete();
                    tesisBelgeleri[i - 1].Delete();
                }
            }
            this.Session.PurgeDeletedObjects();
            base.OnDeleting();
        }
    }
}
