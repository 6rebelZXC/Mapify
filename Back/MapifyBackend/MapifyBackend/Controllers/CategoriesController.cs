using MapifyBackend.database_files;
using MapifyBackend.Utility;
using MapifyBackend.Utility.DTOs;
using MapifyBackend.Utility.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MapifyBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly DatabaseService _db;
    private readonly CategoryService _categoryService;

    public CategoriesController(DatabaseService db, CategoryService categoryService)
    {
        _db = db;
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var allCategories = _categoryService.GetAllCategories();
        return Ok(allCategories); //status 200 and JSON data
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Category? category = _categoryService.GetCategoryById(id);
        if (category == null)
        {
            return NotFound(new { message = $"Category by ID {id} was not found" });
        }

        return Ok(category);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CategoryRequest request)
    {
        try
        {
            InputValidator.ValidateCategoryRequest(request);
            Side side = Enum.Parse<Side>(request.Side);
            _categoryService.AddCategory(request.Name, side);
            return Ok(new { message = "Category added" });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = "Error adding category" });
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_categoryService.DeleteCategory(id)) return NotFound(new {message = $"Category by id {id} was not found"});
        return Ok(new { message = "Category deleted" });
    }

    [HttpGet("category_name/{id}")]
    public IActionResult GetName(int id)
    {
        string? name = _categoryService.GetCategoryNameById(id);
        if (name == null)
            return NotFound(new { message = $"Category by id {id} was not found" });
        return Ok(new { name = name });
    }

    
}