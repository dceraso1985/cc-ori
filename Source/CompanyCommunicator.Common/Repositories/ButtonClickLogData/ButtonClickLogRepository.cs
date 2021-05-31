// <copyright file="ButtonClickLogRepository.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.ButtonClickLogData
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories;

    /// <summary>
    /// App configuration repository.
    /// </summary>
    public class ButtonClickLogRepository : BaseRepository<ButtonClickLogEntity>, IButtonClickLogRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonClickLogRepository"/> class.
        /// </summary>
        /// <param name="logger">The logging service.</param>
        /// <param name="repositoryOptions">Options used to create the repository.</param>
        public ButtonClickLogRepository(
            ILogger<ButtonClickLogRepository> logger,
            IOptions<RepositoryOptions> repositoryOptions)
            : base(
                  logger,
                  storageAccountConnectionString: repositoryOptions.Value.StorageAccountConnectionString,
                  tableName: ButtonClickLogTableName.TableName,
                  defaultPartitionKey: ButtonClickLogTableName.SettingsPartition,
                  ensureTableExists: repositoryOptions.Value.EnsureTableExists)
        {
            // this.TableRowKeyGenerator = tableRowKeyGenerator;
        }

        /*/// <inheritdoc/>
        public TableRowKeyGenerator TableRowKeyGenerator { get; }*/

        /// <summary>
        /// Create a Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public async Task CreateButtonClickLogAsync(
            string partitionKey,
            string userId)
        {
            try
            {
                var bcld = await this.GetButtonClickLogAsync(partitionKey, userId);

                if (bcld == null)
                {
                    var newButtonClickLogEntity = new ButtonClickLogEntity
                    {
                        PartitionKey = partitionKey,
                        RowKey = userId,
                        Timestamp = DateTimeOffset.UtcNow,
                    };

                    await this.CreateOrUpdateAsync(newButtonClickLogEntity);
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Get a Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task<ButtonClickLogEntity> GetButtonClickLogAsync(string partitionKey, string userId)
        {
            var result = this.GetAsync(partitionKey, userId);

            return result;
        }

        /// <summary>
        /// Get a list of Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task<IEnumerable<ButtonClickLogEntity>> GetButtonClickLogAsync(string partitionKey)
        {
            var result = this.GetAllAsync(partitionKey);

            return result;
        }

        /*/// <summary>
        /// Update an existing Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="buttonLink">Button Link.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public async Task CountButtonClickLogAsync(string partitionKey, string userId, string buttonLink)
        {
            try
            {
                var buttonClickLogEntity = new ButtonClickLogEntity
                {
                    PartitionKey = partitionKey,
                    RowKey = userId,
                    ButtonLink = buttonLink,
                    Timestamp = DateTimeOffset.UtcNow,
                };

                await this.CreateOrUpdateAsync(buttonClickLogEntity);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                throw;
            }
        }*/

        /// <summary>
        /// Get a Count Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task<IEnumerable<ButtonClickLogEntity>> GetClicksCount(string partitionKey)
        {
            var result = this.GetAllAsync(partitionKey);

            return result;
        }
    }
}
