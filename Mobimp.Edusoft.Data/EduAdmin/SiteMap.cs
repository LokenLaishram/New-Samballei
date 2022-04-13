using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Mobimp.Edusoft.Data.Common;

namespace Mobimp.Edusoft.Data.EduAdmin
{
    [Serializable]
    public class SiteMapData : BaseData
    {
        [DataMember]
        public int SiteMapID
        { get; set; }
        [DataMember]
        public string Title
        { get; set; }
        [DataMember]
        public string Text
        { get; set; }
        [DataMember]
        public string Description
        { get; set; }
        [DataMember]
        public string Url
        { get; set; }
        [DataMember]
        public int ParentID
        { get; set; }
        [DataMember]
        public string CssFont
        { get; set; }
        [DataMember]
        public string DashboardImage
        { get; set; }
        [DataMember]
        public string Dashboardfootercolor
        { get; set; }
        [DataMember]
        public int PageID
        { get; set; }
        public int IsView
        { get; set; }
        public int IsMenuheader
        { get; set; }
        public string PageName
        { get; set; }
        
    }
}
