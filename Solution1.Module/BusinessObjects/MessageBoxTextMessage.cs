using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace Solution1.Module.BusinessObjects
{
    [NonPersistent]
    [ImageName("BO_Attention")]//BO_Rules
    [ModelDefault("Caption", "DİKKAT!")]    
    public class MessageBoxTextMessage
    {
        private readonly string _Message;

        [ModelDefault("Caption", " ")]
        [Size(SizeAttribute.Unlimited)]
        public string Message
        {
            get { return _Message; }
        }

        public MessageBoxTextMessage(string Message)
        {
            _Message = Message;
        }
    }
}
