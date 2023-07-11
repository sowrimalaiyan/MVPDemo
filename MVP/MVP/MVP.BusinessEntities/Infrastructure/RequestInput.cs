//-----------------------------------------------------------------------
// <copyright file="RequestInput.cs" company="My Own">
//     My Own copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace MVP.BusinessEntities
{
    /// <summary>
    /// Common input parameters
    /// </summary>
    /// <typeparam name="T">generic input type</typeparam>
    public class RequestInput<T>
    {
        /// <summary>
        /// Gets or sets generic input type
        /// </summary>
        public T Input { get; set; }

        /// <summary>
        /// Gets or sets Basic Client information
        /// </summary>
        public ClientInfo ClientUserInfo { get; set; }
    }
}
