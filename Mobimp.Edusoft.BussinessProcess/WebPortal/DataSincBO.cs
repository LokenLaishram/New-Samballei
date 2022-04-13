using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.Data.WebPortal;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.DataAccess.WebPortal;

namespace Mobimp.Edusoft.BussinessProcess.WebPortal
{
    public class DataSincBO
    {
        public string GetAllData(DataSincData objdatasinc)
        {
            string result;

            try
            {
                DataSincDA objdataDA = new DataSincDA();
                result = objdataDA.GetAllData(objdatasinc);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<DataSincData> list(DataSincData objdata)
        {
            List<DataSincData> result = null;
            try
            {
                DataSincDA objDA = new DataSincDA();
                result = objDA.list(objdata);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
    
}
