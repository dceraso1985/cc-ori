// <copyright file="IButtonClickLogService.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Button Click Log Service interface.
    /// </summary>
    public interface IButtonClickLogService
    {
        /// <summary>
        /// Add button click log in Table Storage.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="partitionKey">Partition Key.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task SaveButtonClickLogDataAsync(string userId, string partitionKey);
    }
}
