using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Solution1.Module.Enums
{
    public enum KayitDurumu
    {
        [ImageName("BO_Validation"), XafDisplayName("Aktif")]
        Aktif,
        [ImageName("State_Validation_Skipped"), XafDisplayName("Pasif")]
        Pasif
    }
}
