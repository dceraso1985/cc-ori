// <copyright file="IButtonClickLogRepository.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Button Click Log repository.
    /// </summary>
    public interface IButtonClickLogRepository : IRepository<ButtonClickLogEntity>
    {
        /// <summary>
        /// Gets table row key generator.
        /// </summary>
        public TableRowKeyGenerator TableRowKeyGenerator { get; }

        /// <summary>
        /// Create a Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <param name="userId">User ID.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        public Task CreateButtonClickLogAsync(string partitionKey, string userId);
    }
}
