using MapifyBackend.database_files;
using Microsoft.AspNetCore.Mvc;

namespace MapifyBackend.Controllers;

public class CategoriesController : ControllerBase
{
    private readonly DatabaseService _db;
}