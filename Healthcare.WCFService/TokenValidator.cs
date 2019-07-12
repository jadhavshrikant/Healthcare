#region Namespace
using System;
#endregion

namespace Healthcare.WCFService
{
    /// <summary>
    /// TokenValidator
    /// </summary>
    public class TokenValidator
    {
        private const int aliveDurationMinutes = 15;

        /// <summary>
        /// Checks if the token is still alive with a 1-second tolerance.
        /// </summary>
        public static bool CheckTokenAlive(DateTime created, DateTime timeToCompare)
        {
            TimeSpan elapsedTime = timeToCompare - created;

            return (elapsedTime.TotalSeconds > -1 && elapsedTime.TotalSeconds < 0) // up to 1 second before
                   || (elapsedTime.TotalSeconds >= 0 && Math.Floor(elapsedTime.TotalSeconds) <= aliveDurationMinutes * 60); // up to 15 minutes later
        }
    }
}