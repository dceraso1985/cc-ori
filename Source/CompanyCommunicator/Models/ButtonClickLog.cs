using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Teams.Apps.CompanyCommunicator.Models
{
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
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets Time Stamp.
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }
}
