#region Namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Healthcare.Models.UserDetail
{
    /// <summary>
    /// UserDetail
    /// </summary>
    public class UserModel
    {
        #region Properties

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public int ResultType { get; set; }
        public DateTime TokenCreated { get; set; }
        public string Token { get; set; }

        #endregion
    }
}
