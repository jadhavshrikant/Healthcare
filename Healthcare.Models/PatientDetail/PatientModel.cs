#region Namespace
using System;
using System.Collections.Generic;
using System.Data;
#endregion

namespace Healthcare.Models.PatientDetail
{
    /// <summary>
    /// PatientModel
    /// </summary>
    public class PatientModel
    {
        #region Properties

        public int PatientId { get; set; }
        public int SalutationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int MaritalStatusId { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DateOfBirthString { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Occupation { get; set; }
        public string IsActive { get; set; }
        public int UserId { get; set; }
        public string AddedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedDateString { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// DataRowToObjectMapper
        /// </summary>
        /// <param name="dataTable"></param>
        public void DataRowToObjectMapper(DataRow row)
        {
            this.PatientId = row["PATIENT_ID"] as int? ?? 0;
            this.SalutationId = row["SALUTATION_ID"] as int? ?? 0;
            this.FirstName = row["FIRST_NAME"] as string ?? string.Empty;
            this.MiddleName = row["MIDDLE_NAME"] as string ?? string.Empty;
            this.LastName = row["LAST_NAME"] as string ?? string.Empty;
            this.MaritalStatusId = row["MARITAL_STATUS_ID"] as int? ?? 0;
            this.DateOfBirth = row["DATE_OF_BIRTH"] as DateTime? ?? null;
            this.Gender = row["GENDER"] as string ?? string.Empty;
            this.ContactNo = row["CONTACT_NO"] as string ?? string.Empty;
            this.Occupation = row["OCCUPATION"] as string ?? string.Empty;
        }

        #endregion
    }
}
