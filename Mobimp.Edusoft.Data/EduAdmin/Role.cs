using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduAdmin
{
    [Serializable]
    public class Role : BaseData
    {
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string UserDescription { get; set; }
        public bool DataAccessPermisn { get; set; }
        public string Permission { get; set; }
        public bool ViewToAll { get; set; }
        public string View { get; set; }

        protected LoginToken LoginToken
        {
            get;
            set;
        }
    }  
}
