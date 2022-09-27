using finPal.WebPortal.Web.Resources;
using FinPalApp.Domain.BackgroundProcessManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace finPal.WebPortal.Web.Controllers
{
    /// <summary>
    /// A controller to work with backgroud processes
    /// </summary>  
    public class BackgroundProcessController : Controller
    {
        #region Members

        private IBackgroundProcessesService backgroundProcessesService;
        private IBackgroundProcessAssembler backgroundProcessAssembler;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundProcessController"/> class.
        /// </summary>
        /// <param name="backgroundProcessesService">The background processes service.</param>
        /// <param name="backgroundProcessAssembler">The background process assembler.</param>
        public BackgroundProcessController(IBackgroundProcessesService backgroundProcessesService,
            IBackgroundProcessAssembler backgroundProcessAssembler
            )
        {
            this.backgroundProcessesService = backgroundProcessesService;
            this.backgroundProcessAssembler = backgroundProcessAssembler;
        }

        #endregion

        /// <summary>
        /// Gets the background process information
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="processId">The process identifier.</param>
        [HttpGet]
        [Route("api/companies/{companyId}/[controller]/{processId}")]
        public IActionResult Get(Guid companyId, Guid processId)
        {
            var process = backgroundProcessesService.GetBackgroundProcess(companyId, processId);
            var resource = backgroundProcessAssembler.ToResource(process);

            return Json(resource);
        }
    }
}
