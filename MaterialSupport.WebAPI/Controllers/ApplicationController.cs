using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using MaterialSupport.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MaterialSupport.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int applicationId)
        {
            try
            {
                var result = await _applicationService.GetById(applicationId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet("getByStatus")]
        public async Task<IActionResult> GetByStatus(Status status)
        {
            try
            {
                var result = await _applicationService.GetByStatus(status);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet("getDocuments")]
        public async Task<IActionResult> GetDocuments(int applicationId)
        {
            try
            {
                var result = await _applicationService.GetApplicationDocs(applicationId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet("getSupportTypes")]
        public async Task<IActionResult> GetSupportTypes(int applicationId)
        {
            try
            {
                var result = await _applicationService.GetApplicationSupportTypes(applicationId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] ApplicationFormDto application)
        {
            try
            {
                var result = await _applicationService.Add(UserId, application);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPut("accept")]
        public async Task<IActionResult> Accept(int applicationId)
        {
            try
            {
                var result = await _applicationService.Accept(applicationId);
                return Ok("Заявление успешно принято");
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPut("approve")]
        public async Task<IActionResult> Approve(int applicationId, int supportTypeId)
        {
            try
            {
                var result = await _applicationService.Approve(applicationId, supportTypeId);
                return Ok("Заявление успешно одобрено");
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPut("reject")]
        public async Task<IActionResult> Reject(int applicationId)
        {
            try
            {
                var result = await _applicationService.Reject(applicationId);
                return Ok("Заявление успешно отклонено");
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
