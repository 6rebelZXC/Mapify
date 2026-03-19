using MapifyBackend.Utility.Enums;

namespace MapifyBackend.database_files;

public class CategoryService
{
    private DatabaseService _db;

    public CategoryService(DatabaseService db)
    {
        _db = db;
    }
    public Category? GetCategoryById(int id)
    {
        return _db.GetCategoryById(id);
    }

    public List<Category> GetAllCategories()
    {
        return _db.GetAllCategories();
    }
    
    public void AddCategory(string name, Side side)
    {
        Category category = new Category(name, side);
        _db.AddCategory(category);
    }

    public bool DeleteCategory(int id)
    {
        if (GetCategoryById(id) == null) return false;
        
        _db.DeleteCategory(id);
        return true;
    }

    public string? GetCategoryNameById(int id)
    {
        return _db.GetCategoryNameById(id);
    }
}