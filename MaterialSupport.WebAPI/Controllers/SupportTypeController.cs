﻿using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MaterialSupport.WebAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin, Moderator")]
    [Route("[controller]")]
    public class SupportTypeController : ControllerBase
    {
        private readonly ISupportTypeService _supportTypeService;

        public SupportTypeController(ISupportTypeService supportTypeService)
        {
            _supportTypeService = supportTypeService;
        }

        [HttpGet("getByid")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _supportTypeService.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _supportTypeService.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SupportTypeDto supportType)
        {
            try
            {
                var result = await _supportTypeService.Add(supportType);
                return Created("", result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(SupportTypeDto supportType)
        {
            try
            {
                var result = await _supportTypeService.Edit(supportType);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(int supportTypeId)
        {
            try
            {
                var result = await _supportTypeService.Remove(supportTypeId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
