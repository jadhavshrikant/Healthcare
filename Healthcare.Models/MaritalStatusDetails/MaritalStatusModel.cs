#region Namespace
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Healthcare.Models.MaritalStatusDetails
{
    /// <summary>
    /// MaritalStatusModel
    /// </summary>
    public class MaritalStatusModel
    {
        #region Properties
        public int MaritalStatusId { get; set; }
        public string MaritalStatus { get; set; }
        #endregion
    }
}
