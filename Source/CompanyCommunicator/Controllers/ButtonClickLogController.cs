// <copyright file="ButtonClickLogController.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories;
    using Microsoft.Teams.Apps.CompanyCommunicator.Models;

    /// <summary>
    /// Controller for the button click log data.
    /// </summary>
    [Route("api/buttonClickLog")]
    [ApiController]
    public class ButtonClickLogController : ControllerBase
    {
        private readonly IButtonClickLogRepository buttonClickLogDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonClickLogController"/> class.
        /// </summary>
        /// <param name="repository">Button Click Log repository.</param>
        public ButtonClickLogController(IButtonClickLogRepository repository)
        {
            this.buttonClickLogDataRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Create a new Button Click Log.
        /// </summary>
        /// <param name="partitionKey">Partition Key.</param>
        /// <returns>The created Button Click Log's id.</returns>
        [HttpPost]
        public async Task<ActionResult<string>> CreateButtonClickLogAsync([FromBody] string partitionKey)
        {
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }

            var userId = this.HttpContext.User.FindFirstValue(Common.Constants.ClaimTypeUserId);

            await this.buttonClickLogDataRepository.CreateButtonClickLogAsync(partitionKey, userId);

            return this.Ok();
        }

        /// <summary>
        /// Get a Button Click Log.
        /// </summary>
        /// <param name="pk">Partition Key.</param>
        /// <param name="rk">Row Key.</param>
        /// <returns>Return specific Button Click Log Data.</returns>
        [HttpGet("{pk}/{rk}")]
        public async Task<ButtonClickLog> GetButtonClickLogAsync(string pk, string rk)
        {
            if (pk == null)
            {
                throw new ArgumentNullException(nameof(pk));
            }

            if (rk == null)
            {
                throw new ArgumentNullException(nameof(rk));
            }

            var result = await this.buttonClickLogDataRepository.GetButtonClickLogAsync(pk, rk);

            ButtonClickLog ret = new ButtonClickLog
            {
                PartitionKey = result.PartitionKey,
                RowKey = result.RowKey,
                Timestamp = Convert.ToDateTime(result.Timestamp),
            };

            return ret;
        }

        /// <summary>
        /// Get a List of Button Click Log.
        /// </summary>
        /// <param name="pk">Partition Key.</param>
        /// <returns>Return a list of Button Click Log Data.</returns>
        [HttpGet("{pk}")]
        public async Task<List<ButtonClickLog>> GetButtonClickLogAsync(string pk)
        {
            if (pk == null)
            {
                throw new ArgumentNullException(nameof(pk));
            }

            var result = await this.buttonClickLogDataRepository.GetButtonClickLogAsync(pk);
            List<ButtonClickLog> ret = new List<ButtonClickLog>();

            foreach (ButtonClickLogEntity item in result)
            {
                ButtonClickLog aux = new ButtonClickLog
                {
                    PartitionKey = item.PartitionKey,
                    RowKey = item.RowKey,
                    Timestamp = Convert.ToDateTime(item.Timestamp),
                };

                ret.Add(aux);
            }

            return ret;
        }

        /*/// <summary>
        /// Update an existing Button Click Log.
        /// </summary>
        /// <param name="btnClickLog">An existing Button Click Log to be updated.</param>
        /// <returns>A task that represents the work queued to execute.</returns>
        [HttpPut]
        public async Task<IActionResult> CountButtonClickLogAsync([FromBody] ButtonClickLog btnClickLog)
        {
            if (btnClickLog == null)
            {
                throw new ArgumentNullException(nameof(btnClickLog));
            }

            await this.buttonClickLogDataRepository.CountButtonClickLogAsync(btnClickLog.PartitionKey, btnClickLog.RowKey, btnClickLog.ButtonLink);

            return this.Ok();
        }*/
    }
}
