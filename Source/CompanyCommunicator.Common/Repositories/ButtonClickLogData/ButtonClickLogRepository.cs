// <copyright file="ButtonClickLogRepository.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories.ButtonClickLogData
{
    using System;
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
        /// <param name="tableRowKeyGenerator">Table row key generator service.</param>
        public ButtonClickLogRepository(
            ILogger<ButtonClickLogRepository> logger,
            IOptions<RepositoryOptions> repositoryOptions,
            TableRowKeyGenerator tableRowKeyGenerator)
            : base(
                  logger,
                  storageAccountConnectionString: repositoryOptions.Value.StorageAccountConnectionString,
                  tableName: ButtonClickLogTableName.TableName,
                  defaultPartitionKey: ButtonClickLogTableName.SettingsPartition,
                  ensureTableExists: repositoryOptions.Value.EnsureTableExists)
        {
            this.TableRowKeyGenerator = tableRowKeyGenerator;
        }

        /// <inheritdoc/>
        public TableRowKeyGenerator TableRowKeyGenerator { get; }

        /// <inheritdoc/>
        public async Task CreateButtonClickLogAsync(
            string partitionKey,
            string userId)
        {
            try
            {
                var newId = this.TableRowKeyGenerator.CreateNewKeyOrderingOldestToMostRecent();

                // TODO: Set the string "(copy)" in a resource file for multi-language support.
                var newButtonClickLogEntity = new ButtonClickLogEntity
                {
                    PartitionKey = partitionKey,
                    RowKey = newId,
                    UserId = userId,
                    Timestamp = DateTime.UtcNow,
                };

                await this.CreateOrUpdateAsync(newButtonClickLogEntity);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
