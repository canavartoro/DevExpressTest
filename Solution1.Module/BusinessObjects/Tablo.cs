using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security.Strategy;
using Solution1.Module.Enums;

namespace Solution1.Module.BusinessObjects
{
    [CreatableItem(false)]
    [NonPersistent]
    [NavigationItem(false)]
    [ModelDefault("Caption", "Kayıt Bilgisi")]
    [XafDisplayName("Kayıt Bilgisi")]
    public class Tablo : XPObject
    {
        public Tablo() { }
        public Tablo(Session session) : base(session) { }

        [Size(250)]
        [VisibleInListView(false)]        
        [XafDisplayName("Açıklama")]
        [VisibleInLookupListView(true)]
        public string Aciklama { get; set; }

        [Size(250)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [XafDisplayName("Açıklama 2")]
        public string Aciklama2 { get; set; }

        protected SecuritySystemUser fOlusturanKullanici;                
        [XmlIgnore()]
        [NoForeignKey]
        [ReadOnly(true)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Oluşturan Kullanıcı")]
        public SecuritySystemUser OlusturanKullanici
        {
            get { return fOlusturanKullanici; }
            set { SetPropertyValue<SecuritySystemUser>("OlusturanKullanici", ref fOlusturanKullanici, value); }
        }

        protected DateTime fOlusturmaTarihi;                
        [XmlIgnore()]
        [ReadOnly(true)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Oluşturma Tarihi")]
        [ModelDefault("DisplayFormat", "{0:dd MMM yyyy ddd HH:mm}")]
        public DateTime OlusturmaTarihi
        {
            get { return fOlusturmaTarihi; }
            set { SetPropertyValue<DateTime>("OlusturmaTarihi", ref fOlusturmaTarihi, value); }
        }

        protected SecuritySystemUser fGüncelleyenKullanici;               
        [XmlIgnore()]
        [NoForeignKey]
        [ReadOnly(true)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Güncelleyen Kullanıcı")]
        public SecuritySystemUser GüncelleyenKullanici
        {
            get { return fGüncelleyenKullanici; }
            set { SetPropertyValue<SecuritySystemUser>("GüncelleyenKullanici", ref fGüncelleyenKullanici, value); }
        }

        protected DateTime fGuncellemeTarihi;                
        [XmlIgnore()]
        [ReadOnly(true)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Güncelleme Tarihi")]
        [ModelDefault("DisplayFormat", "{0:dd MMM yyyy ddd HH:mm}")]
        public DateTime GuncellemeTarihi
        {
            get { return fGuncellemeTarihi; }
            set { SetPropertyValue<DateTime>("GuncellemeTarihi", ref fGuncellemeTarihi, value); }
        }

        protected KayitDurumu fDurum = KayitDurumu.Aktif;
        [Indexed]
        [VisibleInListView(true)]
        [VisibleInLookupListView(true)]
        [XafDisplayName("Kayıt Durumu")]
        public KayitDurumu Durum
        {
            get { return fDurum; }
            set { SetPropertyValue<KayitDurumu>("Durum", ref fDurum, value); }
        }

        #region Operators
        public static implicit operator bool(Tablo tbl)
        {
            return (tbl != null && tbl.Durum == KayitDurumu.Aktif);
        }
        public static explicit operator string(Tablo tbl)
        {
            return (tbl != null) ? tbl.Aciklama : "";
        }
        #endregion

        protected override void OnSaving()
        {
            if (!IsDeleted)
            {
                Kullanici currentUser = SecuritySystem.CurrentUser as Kullanici;
                if (this.Session.IsNewObject(this))
                {
                    this.fOlusturmaTarihi = DateTime.Now;
                    if (SecuritySystem.CurrentUser != null)
                        this.fOlusturanKullanici = currentUser != null ? this.Session.GetObjectByKey<SecuritySystemUser>(currentUser.Oid) : null;
                }
                else
                {
                    this.fGuncellemeTarihi = DateTime.Now;
                    if (SecuritySystem.CurrentUser != null)
                        this.fGüncelleyenKullanici = currentUser != null ? this.Session.GetObjectByKey<SecuritySystemUser>(currentUser.Oid) : null;
                }
            }
            base.OnSaving();
        }
    }

    [Serializable]
    public abstract class TabloInfo
    {
        public TabloInfo() { }

        public string Aciklama { get; set; }
        public string Aciklama2 { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}
