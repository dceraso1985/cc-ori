// <copyright file="ButtonClickLog.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Models
{
    using System;

    /// <summary>
    /// Button Click Log model class.
    /// </summary>
    public class ButtonClickLog
    {
        /// <summary>
        /// Gets or sets Partition Key.
        /// </summary>
        public string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets Row Key.
        /// </summary>
        public string RowKey { get; set; }

        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public string ButtonLink { get; set; }

        /// <summary>
        /// Gets or sets Time Stamp.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
