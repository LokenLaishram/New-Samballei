using Mobimp.Edusoft.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mobimp.Campusoft.Data.EduFeeUtility
{
    public class ExamGradeData : BaseData
    {
        /// <summary>
        /// THIS DATA LAYER USER IN DIFFERENT PAGES. LIST OF THE PAGES ARE GIVEN BELOW
        /// 1) SUBJECT GRADE MASTER PAGE
        /// 2) EXTRA CURICULAR GRADE MASTER PAGE
        /// </summary>
        
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int GradeID { get; set; }
        [DataMember]
        public string SubjectGrade { get; set; }
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public int GradeValue { get; set; }
    }
}
