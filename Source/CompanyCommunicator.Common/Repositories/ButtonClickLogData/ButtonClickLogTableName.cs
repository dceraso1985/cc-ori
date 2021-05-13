// <copyright file="ButtonClickLogTableName.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories
{
    /// <summary>
    /// Button Click Log table information.
    /// </summary>
    public class ButtonClickLogTableName
    {
        /// <summary>
        /// Table name for app config..
        /// </summary>
        public static readonly string TableName = "ButtonClickLogData";

        /// <summary>
        /// App settings partition.
        /// </summary>
        public static readonly string SettingsPartition = "Settings";

        /// <summary>
        /// Service url row key.
        /// </summary>
        public static readonly string ServiceUrlRowKey = "ServiceUrl";

        /// <summary>
        /// User app id row key.
        /// </summary>
        public static readonly string UserAppIdRowKey = "UserAppId";
    }
}
