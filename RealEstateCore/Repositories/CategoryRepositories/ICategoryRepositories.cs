using RealEstateCore_Api.Dtos.CategoryDtos;

namespace RealEstateCore_Api.Repositories.CategoryRepositories
{
    public interface ICategoryRepositories
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto  updateCategory);
        Task<GetBYCategoryDto> GetBYCategoryDto(int id);
    }
}
