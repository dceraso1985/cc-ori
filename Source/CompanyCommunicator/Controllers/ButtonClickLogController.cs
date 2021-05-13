namespace Microsoft.Teams.Apps.CompanyCommunicator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Teams.Apps.CompanyCommunicator.Common.Repositories;
    using Microsoft.Teams.Apps.CompanyCommunicator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller for the button click log data.
    /// </summary>
    [Route("api/buttonClickLog")]
    [ApiController]
    public class ButtonClickLogController : ControllerBase
    {
        private readonly IButtonClickLogRepository buttonClickLogDataRepository;

        // GET: api/<ButtonClickLogController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ButtonClickLogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        /*// PUT api/<ButtonClickLogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ButtonClickLogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
