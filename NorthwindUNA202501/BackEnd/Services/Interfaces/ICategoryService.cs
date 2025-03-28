using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetCategories();
        CategoryDTO GetCategoryById(int id);
        CategoryDTO AddCategory(CategoryDTO category);
        CategoryDTO UpdateCategory(CategoryDTO category);
        CategoryDTO DeleteCategory(int id);
    }
}
