using Mobimp.Campusoft.DataAccess.HRAndPayroll.Utility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mobimp.Campusoft.Data.HRAndPayroll.Utility.Roster;

namespace Mobimp.Campusoft.BussinessProcess.HRAndPayroll.Utility
{
   public class RosterBO
    {
        public int UpdateRoster(RosterData Objroster)
        {
            int result = 0;

            try
            {
                RosterDA ObjDA = new RosterDA();
                result = ObjDA.UpdateRoster(Objroster);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<RosterData> Searchroster(RosterData Objroster)
        {
            List<RosterData> result = null;
            try
            {
                RosterDA ObjDA = new RosterDA();
                result = ObjDA.Searchroster(Objroster);
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
