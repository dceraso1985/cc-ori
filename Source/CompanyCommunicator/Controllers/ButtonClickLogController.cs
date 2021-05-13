// <copyright file="ButtonClickLogController.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// </copyright>

namespace Microsoft.Teams.Apps.CompanyCommunicator.Controllers
{
    using System;
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
        /// <param name="buttonClickLog">Partition Key and User Id.</param>
        /// <returns>The created Button Click Log's id.</returns>
        [HttpPost]
        public async Task<ActionResult<string>> CreateButtonClickLogAsync([FromBody] ButtonClickLog buttonClickLog)
        {
            if (buttonClickLog == null)
            {
                throw new ArgumentNullException(nameof(buttonClickLog));
            }

            await this.buttonClickLogDataRepository.CreateButtonClickLogAsync(buttonClickLog.PartitionKey, buttonClickLog.UserId);

            return this.Ok();
        }
    }
}
