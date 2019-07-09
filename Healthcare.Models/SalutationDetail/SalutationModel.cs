#region Namespace
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Healthcare.Models.SalutationDetail
{
    /// <summary>
    /// SalutationModel
    /// </summary>
    public class SalutationModel
    {
        #region Properties
        public int SalutationId { get; set; }
        public string Salutation { get; set; }
        #endregion
    }
}
