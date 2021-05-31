// <copyright file="IButtonClickLogRepository.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Button Click Log repository.
    /// </summary>
    public interface IButtonClickLogRepository : IRepository<ButtonClickLogEntity>
    {
        /*/// <summary>
        /// Gets table row key generator.
        /// </summary>
        public TableRowKeyGenerator TableRowKeyGenerator { get; }*/

        /// <summary>
        /// Create a Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task CreateButtonClickLogAsync(string partitionKey, string userId);

        /// <summary>
        /// Get a list of Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task<IEnumerable<ButtonClickLogEntity>> GetButtonClickLogAsync(string partitionKey);

        /// <summary>
        /// Get a Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task<ButtonClickLogEntity> GetButtonClickLogAsync(string partitionKey, string userId);

        /*/// <summary>
        /// Update an existing Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <param name="userId">User ID.</param>
        /// <param name="buttonLink">Button Link.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task CountButtonClickLogAsync(string partitionKey, string userId, string buttonLink);*/

        /// <summary>
        /// Get a Count Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task<IEnumerable<ButtonClickLogEntity>> GetClicksCount(string partitionKey);
    }
}
