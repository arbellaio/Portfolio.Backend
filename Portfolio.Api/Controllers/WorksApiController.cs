using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Database.Services.ContentServices;
using Portfolio.Domain.Helpers;

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksApiController : ControllerBase
    {
        #region Constructors Inits

        private readonly IWorkService _workService;

        public WorksApiController(IWorkService workService)
        {
            _workService = workService ?? throw new ArgumentNullException("Content Service");
        }

        #endregion


        #region Get Projects
        /// <summary>
        /// Api to get completed and ongoing projects
        /// </summary>
        /// <returns>Base Response with Projects</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse>> Projects()
        {
            var contentInDb = await _workService.GetProjects();
            if (contentInDb != null)
            {
                var baseResponse = new BaseResponse
                {
                    ContentCollection = contentInDb,
                    Response = new JsonResponseHandler
                    {
                        IsSuccess = true,
                        ErrorMessage = null,
                        Warning = null,
                    }
                };

                return baseResponse;
            }

            return BadRequest(new
            {
                Response = new JsonResponseHandler
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Warning = null,
                }
            });
        }
        #endregion



        [HttpGet]
        [Authorize]
        public async Task<ActionResult<BaseResponse>> AddProject()
        {
            return null;
        }
    }
}