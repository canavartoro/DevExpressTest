using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using System.Xml.Serialization;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security.Strategy;
using Solution1.Module.Enums;

namespace Solution1.Module.BusinessObjects
{
    [CreatableItem(false)]
    [NavigationItem(true), ImageName("BO_Role")]
    [DeferredDeletion(false), OptimisticLocking(false)]
    [DefaultClassOptions, XafDefaultProperty("UserName")]    
    [ModelDefault("DefaultListViewShowAutoFilterRow", "True")]
    public class Kullanici : DevExpress.ExpressApp.Security.Strategy.SecuritySystemUser
    {
         public Kullanici() : base(Session.DefaultSession) { }
         public Kullanici(Session session) : base(session) { }

        //string password;
        //[XmlIgnore(), PasswordPropertyText(true), NonPersistent, VisibleInListView(false), VisibleInLookupListView(false)]
        //public string Parola
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(password))
        //            password = base.StoredPassword;
        //        return base.StoredPassword;
        //    }
        //    set { password = value; SetPassword(value); OnChanged("StoredPassword"); }
        //}



        #region Ortak Alanlar
        protected SecuritySystemUser fOlusturanKullanici;
        [ModelDefault("AllowEdit", "False")]
        [ReadOnly(true)]
        [XmlIgnore()]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [XafDisplayName("Oluşturan Kullanıcı")]
        public SecuritySystemUser OlusturanKullanici
        {
            get { return fOlusturanKullanici; }
            set { SetPropertyValue<SecuritySystemUser>("OlusturanKullanici", ref fOlusturanKullanici, value); }
        }

        protected DateTime fOlusturmaTarihi;
        [ModelDefault("AllowEdit", "False")]
        [ReadOnly(true)]
        [XmlIgnore()]
        [ModelDefault("DisplayFormat", "{0:dd MMM yyyy ddd HH:mm}")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [XafDisplayName("Oluşturma Tarihi")]
        public DateTime OlusturmaTarihi
        {
            get { return fOlusturmaTarihi; }
            set { SetPropertyValue<DateTime>("OlusturmaTarihi", ref fOlusturmaTarihi, value); }
        }

        protected SecuritySystemUser fGüncelleyenKullanici;
        [ModelDefault("AllowEdit", "False")]
        [ReadOnly(true)]
        [XmlIgnore()]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [XafDisplayName("Güncelleyen Kullanıcı")]
        public SecuritySystemUser GüncelleyenKullanici
        {
            get { return fGüncelleyenKullanici; }
            set { SetPropertyValue<SecuritySystemUser>("GüncelleyenKullanici", ref fGüncelleyenKullanici, value); }
        }

        protected DateTime fGuncellemeTarihi;
        [ModelDefault("AllowEdit", "False")]
        [ReadOnly(true)]
        [XmlIgnore()]
        [ModelDefault("DisplayFormat", "{0:dd MMM yyyy ddd HH:mm}")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [XafDisplayName("Güncelleme Tarihi")]
        public DateTime GuncellemeTarihi
        {
            get { return fGuncellemeTarihi; }
            set { SetPropertyValue<DateTime>("GuncellemeTarihi", ref fGuncellemeTarihi, value); }
        }
        #endregion



        protected override void OnSaving()
        {
            if (IsDeleted)
            {
            }
            else
            {
                Kullanici currentUser = SecuritySystem.CurrentUser as Kullanici;
                if (this.Session.IsNewObject(this))
                {
                    this.OlusturanKullanici = currentUser != null ? this.Session.GetObjectByKey<Kullanici>(currentUser.Oid) : this;
                    this.OlusturmaTarihi = DateTime.Now;
                }
                else
                {
                    this.GüncelleyenKullanici = this.Session.GetObjectByKey<Kullanici>(currentUser.Oid);
                    this.GuncellemeTarihi = DateTime.Now;
                }

                if (this.ChangePasswordOnFirstLogon)
                    this.SetPassword(string.Empty);
            }

            //if (this.IsDeleted)
            //{
            //    SecurityUserWithRolesBase usrRol = this.Session.GetObjectByKey<SecurityUserWithRolesBase>(base.Oid);
            //    if (!object.ReferenceEquals(null, usrRol)) usrRol.Delete();
            //    SecurityUserBase usrBase = this.Session.GetObjectByKey<SecurityUserBase>(base.Oid);
            //    if (!object.ReferenceEquals(null, usrBase)) usrBase.Delete();
            //    SecurityUser usr = this.Session.GetObjectByKey<SecurityUser>(base.Oid);
            //    if (!object.ReferenceEquals(null, usr)) usr.Delete();
            //}
            //else
            //{
            //    //Kullanici currentUser = SecuritySystem.CurrentUser as Kullanici;
            //}
            base.OnSaving();
        }

       
    }
}
