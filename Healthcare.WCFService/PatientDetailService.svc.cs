#region Namespace
using Healthcare.BusinessLayer.PatientDetail;
using Healthcare.Models.PatientDetail;
using Healthcare.Models.UserDetail;
using Healthcare.Utilities;
using Healthcare.WCFServiceInterface;
using Healthcare.WCFServiceInterface.PatientDetail;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
#endregion

namespace Healthcare.WCFService
{
    /// <summary>
    /// PatientDetailService
    /// </summary>
    public class PatientDetailService : IPatientDetailService, IValidateUserService
    {
        #region Properties
        /// <summary>
        /// patientDetailProvider
        /// </summary>
        private readonly IPatientDetailProvider patientDetailProvider;
        #endregion

        #region Constructor 

        /// <summary>
        /// PatientDetailService
        /// </summary>
        public PatientDetailService()
        {
            this.patientDetailProvider = new PatientDetailProvider();
        }

        #endregion

        #region Methods

        /// <summary>
        /// getPatients
        /// </summary>
        /// <returns></returns>
        public List<PatientModel> getPatients()
        {
            if (validateUser())
            {
                return patientDetailProvider.getPatients();
            }
            throw new FaultException("Service Authorization can not be done for unauthenticated user.");
        }

        /// <summary>
        /// getPatientDetail
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public PatientModel getPatientDetail(int patientId)
        {
            if (validateUser())
            {
                return patientDetailProvider.getPatientDetail(patientId);
            }
            throw new FaultException("Service Authorization can not be done for unauthenticated user.");
        }

        /// <summary>
        /// upsertPatientDetail
        /// </summary>
        /// <param name="patientModel"></param>
        /// <returns></returns>
        public string upsertPatientDetail(PatientModel patientModel)
        {
            if (validateUser())
            {
                return patientDetailProvider.upsertPatientDetail(patientModel);
            }
            throw new FaultException("Service Authorization can not be done for unauthenticated user.");
        }

        /// <summary>
        /// deletetPatientDetail
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public string deletetPatientDetail(int patientId)
        {
            if (validateUser())
            {
                return patientDetailProvider.deletetPatientDetail(patientId);
            }
            throw new FaultException("Service Authorization can not be done for unauthenticated user.");
        }
        #endregion

        #region Validate User

        /// <summary>
        /// validateUser
        /// </summary>
        /// <returns></returns>
        public bool validateUser()
        {
            bool isValid = true;
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string encUserDetail = headers["X-Token"];
            if (!string.IsNullOrEmpty(encUserDetail))
            {
                UserModel userModel = CommonMethod.ConvertJsonStringToObject<UserModel>(encUserDetail);
                if (null == userModel || userModel.UserId == 0)
                {
                    isValid = false;
                }
                else if (!TokenValidator.CheckTokenAlive(userModel.TokenCreated, DateTime.Now))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        #endregion
    }
}
