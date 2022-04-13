using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.DataAccess.EduExam;

namespace Mobimp.Edusoft.BussinessProcess.EduExam
{
    public class SubjectMarkRangeBO
    {
        public List<Examdata> GetMarkList(Examdata objsubject)
        {

            List<Examdata> result = null;

            try
            {
                SubjectMarkRangeDA objsubjectDA = new SubjectMarkRangeDA();
                result = objsubjectDA.GetMarkList(objsubject);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
    }
}
