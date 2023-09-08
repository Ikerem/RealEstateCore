using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateCore_Api.Dtos.CategoryDtos;
using RealEstateCore_Api.Repositories.CategoryRepositories;

namespace RealEstateCore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepositories _categoryRepositories;

        public CategoriesController(ICategoryRepositories categoryRepositories)
        {
            _categoryRepositories = categoryRepositories;
        }
        [HttpGet]
        public async Task<IActionResult> GettallCategories()
        {
            var values = await _categoryRepositories.GetAllCategoryAsync();
            return Ok(values);

        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepositories.CreateCategory(createCategoryDto);
            return Ok("Eklendi");

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryRepositories.DeleteCategory(id);
            return Ok("Silindi");

        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepositories.UpdateCategory(updateCategoryDto);
            return Ok("Güncellendi");

        }
        [HttpGet("id")]
        public async Task<IActionResult> GetBYCategoryDto(int id)
        {
            var values = await _categoryRepositories.GetBYCategoryDto(id);
            return Ok(values);

        }
    }
}
