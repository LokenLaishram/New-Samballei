using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobimp.Edusoft.Data.Common
{

    [Serializable]
    public class LookupItem : BaseData
    {
        public Int64 ItemId { get; set; }
        public string ItemName { get; set; }
    }
}
