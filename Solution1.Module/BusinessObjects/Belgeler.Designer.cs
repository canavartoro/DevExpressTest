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
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Solution1.Module.Enums;

namespace Solution1.Module.BusinessObjects
{
    [CreatableItem(false)]
    [Persistent("T_Belgeler")]
    [ModelDefault("Caption", "Belge Tanımları")]
    [OptimisticLocking(false)]
    [DeferredDeletion(false)]
    [DefaultClassOptions]
    [XafDefaultProperty("Ad")]
    [NavigationItem(false)]
    [ImageName("ModelEditor_DetailView")]
    [ModelDefault("DefaultListViewShowAutoFilterRow", "True")]
    [ModelDefault("IsCloneable", "False")]
    public partial class Belgeler
    {
        public Belgeler() { }
        public Belgeler(Session session) : base(session) { }

        [Size(250)]
        [NonCloneable]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [XafDisplayName("Dosya Adı")]
        [VisibleInLookupListView(true)]
        [RuleRequiredField("Belge Ad bilgisi zorunludur!", DefaultContexts.Save)]
        public string Ad { get; set; }


        [Size(400)]
        [NonCloneable]
        [ReadOnly(true)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [XafDisplayName("Dosya Adı")]
        [VisibleInLookupListView(true)]
        [ModelDefault("AllowEdit", "False")]
        public string DosyaAdi { get; set; }

        [Size(50)]
        [NonCloneable]
        [ReadOnly(true)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [VisibleInLookupListView(true)]
        [ModelDefault("AllowEdit", "False")]
        public string Uzanti { get; set; }

        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        [XafDisplayName("Dosya Boyutu")]
        public long Boyut { get; set; }

        #region Dosya
        private FileData fDosya;
        [XmlIgnore]
        //[FileTypeFilter("Resim Dosyasi (*.jpg)", 1, "*.jpg")]
        //[FileTypeFilter("Resim Dosyasi (*.jpeg)", 2, "*.Jpeg", "*.jpeg")]
        //[FileTypeFilter("Tum Dosyasi (*.*)", 3, "*.*")]
        [ExpandObjectMembers(ExpandObjectMembers.Never), VisibleInListView(false), VisibleInLookupListView(false)]
        public FileData Dosya
        {
            get { return fDosya; }
            set
            {
                SetPropertyValue<FileData>("Dosya", ref fDosya, value);
            }
        }
        #endregion


        [XmlIgnore()]
        [NonCloneable]
        [XafDisplayName("Oğrenci")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [Association("Belgeler.Ogrenciler")]
        public Ogrenci Ogrenci { get; set; }

    }
}