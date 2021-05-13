// <copyright file="AppConfigEntity.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories
{
    using Microsoft.Azure.Cosmos.Table;
    using System;

    /// <summary>
    /// Button Click Log entity.
    /// </summary>
    public class ButtonClickLogEntity : TableEntity
    {
        /// <summary>
        /// Gets or sets the User Id value.
        /// </summary>
        public string UserId { get; set; }

    }
}
