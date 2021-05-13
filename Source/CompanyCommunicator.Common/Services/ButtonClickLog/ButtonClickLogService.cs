// <copyright file="AppSettingsService.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories;

    public class ButtonClickLogService : IButtonClickLogService
    {
        private readonly IButtonClickLogRepository repository;


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
                UserId = userId,
                Timestamp = DateTime.Now 
            };

            await this.repository.InsertOrMergeAsync(buttonClickLog);
        }




    }
}
