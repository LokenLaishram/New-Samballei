using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduAdmin
{

    [Serializable]
    public class UserCE : BaseData
    {
        public CreateUser objCreateUser { get; set; }
        public List<Role> RoleList { get; set; }
        public List<SiteMapData> SiteMapList
        {
            get;
            set;
        }
        public DataTable SiteMapDT
        {
            get;
            set;
        }
    }
}
