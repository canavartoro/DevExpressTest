using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Solution1.Module.Enums;

namespace Solution1.Module.BusinessObjects
{
    [CreatableItem(false)]
    [ListViewFilter("Tüm Ogrenci", "")]
    [ListViewFilter("Aktif Ogrenci", "[Durum] = 'Aktif'")]
    [ListViewFilter("Pasif Ogrenci", "[Durum] = 'Pasif'")]
    [Persistent("T_Ogrenciler")]
    [ModelDefault("Caption", "Ogrenciler")]
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [DefaultClassOptions]
    [XafDefaultProperty("OgrenciAdi")]
    [NavigationItem("Genel Tanımlar")]
    [ImageName("ModelEditor_DetailView")]
    [ModelDefault("DefaultListViewShowAutoFilterRow", "True")]
    [ModelDefault("IsCloneable", "False")]
    public partial class Ogrenci
    {
        public Ogrenci() { }
        public Ogrenci(Session session) : base(session) { }

        [Size(100)]
        [VisibleInLookupListView(true)]
        [RuleRequiredField("Ogrenci Adı Zorunludur!", DefaultContexts.Save)]
        [XafDisplayName("Ogrenci Adı")]
        public string OgrenciAdi { get; set; }

        [Size(100)]
        [VisibleInLookupListView(true)]
        [XafDisplayName("Ogrenci Soyadı")]
        public string OgrenciSoyadi { get; set; }

        [Size(15)]
        [NonCloneable]
        [XafDisplayName("Telefon 1")]
        public string Telefon1 { get; set; }

        [Size(15)]
        [NonCloneable]
        [XafDisplayName("Telefon 2")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string Telefon2 { get; set; }

        [Size(SizeAttribute.Unlimited)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [XafDisplayName("Adres")]
        public string Adres { get; set; }

        [NonCloneable]
        [NoForeignKey]
        [VisibleInDetailView(true)]
        [Association("Belgeler.Ogrenciler", typeof(Belgeler)), DevExpress.Xpo.Aggregated, XafDisplayName("Belgeler")]
        public XPCollection Belgeler
        {
            get { return GetCollection("Belgeler"); }
        }


        #region Operators
        public static explicit operator OgrenciInfo(Ogrenci c)
        {
            return new OgrenciInfo(c);
        }

        #endregion
    }

    [Serializable]
    public class OgrenciInfo : TabloInfo
    {
        public OgrenciInfo() { }
        public OgrenciInfo(Ogrenci c)
        {
            if (c != null)
            {
                Oid = c.Oid;
            }
        }

        public int Oid { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string Durum { get; set; }
    }
}