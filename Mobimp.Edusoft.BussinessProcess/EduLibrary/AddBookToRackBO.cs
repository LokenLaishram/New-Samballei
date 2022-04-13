using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mobimp.Edusoft.DataAccess.EduUtility;
using Mobimp.Edusoft.Common.ExceptionHandler;
using Mobimp.Edusoft.Common.Logging;
using Mobimp.Edusoft.Data.EduLibrary;
using Mobimp.Edusoft.DataAccess.EduLibrary;

namespace Mobimp.Edusoft.BussinessProcess.EduLibrary
{
    public class AddBookToRackBO
    {
        public int UpdateAddBookToRack(AddBookToRackData objgrp)
        {
            int result = 0;

            try
            {
                AddBookToRackDA objgrpDA = new AddBookToRackDA();
                result = objgrpDA.UpdateAddBookToRack(objgrp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<AddBookToRackData> SearchAddBookToRack(AddBookToRackData objgrp)
        {
            List<AddBookToRackData> result = null;
            try
            {
                AddBookToRackDA objgrpDA = new AddBookToRackDA();
                result = objgrpDA.SearchAddBookToRack(objgrp);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;
        }
        public List<AddBookToRackData> GetAddBookToRackByID(AddBookToRackData objgrp)
        {
            List<AddBookToRackData> result = null;

            try
            {
                AddBookToRackDA objgrpDA = new AddBookToRackDA();
                result = objgrpDA.GetAddBookToRackByID(objgrp);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public int DeleteAddBookToRackByID(AddBookToRackData objgrp)
        {
            int result = 0;

            try
            {
                AddBookToRackDA objgrpDA = new AddBookToRackDA();
                result = objgrpDA.DeleteAddBookToRackByID(objgrp);
            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public int Activate(AddBookToRackData objgrp)
        {
            int result = 0;

            try
            {
                AddBookToRackDA objstdloyeeDA = new AddBookToRackDA();
                result = objstdloyeeDA.ActivateAddBookToRack(objgrp);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }

        public List<AddBookToRackData> GetBookDetailByID(AddBookToRackData objData)
        {

            List<AddBookToRackData> result = null;

            try
            {
                AddBookToRackDA objDA = new AddBookToRackDA();
                result = objDA.GetBookDetailByID(objData);

            }
            catch (Exception ex)
            {
                PolicyBasedExceptionHandler.HandleException(PolicyBasedExceptionHandler.PolicyName.BusinessProcessExceptionPolicy, ex, "4000001");
                LogManager.UpdateCmsErrorDetails(ex);
                throw new BusinessProcessException("4000001", ex);
            }
            return result;

        }
        public List<AddBookToRackData> GetAutoBookDetails(AddBookToRackData objitemName)
        {
            List<AddBookToRackData> result = null;

            try
            {
                AddBookToRackDA objitemDA = new AddBookToRackDA();
                result = objitemDA.GetAutoBookDetails(objitemName);

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
