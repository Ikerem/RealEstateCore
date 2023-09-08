using Dapper;
using RealEstateCore_Api.Dtos.CategoryDtos;
using RealEstateCore_Api.Models.ModelsContext;


namespace RealEstateCore_Api.Repositories.CategoryRepositories
{
    public class CategoryRepositories : ICategoryRepositories
    {
        private readonly Context _context;

        public CategoryRepositories(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category(CategoryName,CategoryStatus) values(@CategoryName,@CategoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", categoryDto.CategoryName);
            parameters.Add("@CategoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID ";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {

                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select* From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetBYCategoryDto> GetBYCategoryDto(int id)
        {
            string query = "Selecet From Category Where CategoryID ";
            var paramaters = new DynamicParameters();
            paramaters.Add("CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetBYCategoryDto>(query, paramaters);
                return values;

            }


        }

        public async void UpdateCategory(UpdateCategoryDto updateCategory)
        {
            string query = "Update Category Set CategoryName=@categoryName,CategoryStatus=@CategoryStatus where CategoryID=@CategoryID ";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", updateCategory.CategoryName);
            parameters.Add("@CategoryStatus", updateCategory.CategoryStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };

        }
    }
}
