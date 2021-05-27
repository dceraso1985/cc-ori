// <copyright file="ButtonClickLogService.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories;

    /// <summary>
    /// Button Click Log service implementation.
    /// </summary>
    public class ButtonClickLogService : IButtonClickLogService
    {
        private readonly IButtonClickLogRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonClickLogService"/> class.
        /// </summary>
        /// <param name="repository">Button Click Log repository.</param>
        public ButtonClickLogService(IButtonClickLogRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Save Button Click Log.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="partitionKey">Partition Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SaveButtonClickLogDataAsync(string userId, string partitionKey)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var buttonClickLog = new ButtonClickLogEntity()
            {
                PartitionKey = partitionKey,
                RowKey = ButtonClickLogTableName.ServiceUrlRowKey,
                ButtonLink = userId,
                Timestamp = DateTimeOffset.UtcNow,
            };

            await this.repository.InsertOrMergeAsync(buttonClickLog);
        }
    }
}
