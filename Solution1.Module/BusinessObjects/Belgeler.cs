using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Solution1.Module.BusinessObjects
{
    [Serializable]
    public partial class Belgeler : Tablo
    {
        protected override void OnSaving()
        {
            if (IsDeleted == false)
            {
            }
        }

        protected override void OnDeleting()
        {
            base.OnDeleting();
        }
    }
}
