using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MaterialSupport.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet("getByid")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _categoriesService.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [Authorize(Roles = "Admin, Moderator, Student")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _categoriesService.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            try
            {
                var result = await _categoriesService.Add(category);
                return Created("", result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPut("edit")]
        public async Task<IActionResult> Edit(CategoryDto category)
        {
            try
            {
                var result = await _categoriesService.Edit(category);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(int categoryId)
        {
            try
            {
                var result = await _categoriesService.Remove(categoryId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
