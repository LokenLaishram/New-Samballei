using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;
using System.Runtime.Serialization;

namespace Mobimp.Edusoft.Data.EduAdmin
{
    [Serializable]
   public class SideMenu : BaseData
    {
        [DataMember]
        public int RoleID { get; set; }
        [DataMember]
        public int MenuitemID { get; set; }
        [DataMember]
        public string MenuItemName { get; set; }


    }
}
