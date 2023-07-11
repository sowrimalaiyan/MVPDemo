//-----------------------------------------------------------------------
// <copyright file="ClientInfo.cs" company="My Own">
//     My Own copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace MVP.BusinessEntities
{
    using System;

    /// <summary>
    /// Basic client details
    /// </summary>
    public class ClientInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientInfo"/> class.
        /// </summary>
        public ClientInfo()
        {
            this.ConnectionString = string.Empty;
        }

        /// <summary>
        /// Gets or sets connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets Client ID
        /// </summary>
        public Guid ClientId { get; set; }


        /// <summary>
        /// Gets or sets Client User Id
        /// </summary>
        public Guid ClientUserId { get; set; }

        /// <summary>
        /// Gets or sets Language ID
        /// </summary>
        public Guid LanguageId { get; set; }
    }
}
